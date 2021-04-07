///
/// Simple pooling for Unity.
///   Author: Martin "quill18" Glaude (quill18@quill18.com)
///   Latest Version: https://gist.github.com/quill18/5a7cfffae68892621267
///   License: CC0 (http://creativecommons.org/publicdomain/zero/1.0/)
///   UPDATES:
/// 	2015-04-16: Changed Pool to use a Stack generic.
/// 
/// Usage:
/// 
///   There's no need to do any special setup of any kind.
/// 
///   Instead of calling Instantiate(), use this:
///       SimplePool.Spawn(somePrefab, somePosition, someRotation);
/// 
///   Instead of destroying an object, use this:
///       SimplePool.Despawn(myGameObject);
/// 
///   If desired, you can preload the pool with a number of instances:
///       SimplePool.Preload(somePrefab, 20);
/// 
/// Remember that Awake and Start will only ever be called on the first instantiation
/// and that member variables won't be reset automatically.  You should reset your
/// object yourself after calling Spawn().  (i.e. You'll have to do things like set
/// the object's HPs to max, reset animation states, etc...)
/// 
/// 
/// 

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Cake.Pooling
{
    public static class SimplePool
    {
        private static Transform m_poolsParent = null;

        // You can avoid resizing of the Stack's internal data by
        // setting this to a number equal to or greater to what you
        // expect most of your pool sizes to be.
        // Note, you can also use Preload() to set the initial size
        // of a pool -- this can be handy if only some of your pools
        // are going to be exceptionally large (for example, your bullets.)
        const int DEFAULT_POOL_SIZE = 3;

        /// <summary>
        /// The Pool class represents the pool for a particular prefab.
        /// </summary>
        public class Pool
        {
            // We append an id to the name of anything we instantiate.
            // This is purely cosmetic.
            int nextId = 1;

            // The structure containing our inactive objects.
            // Why a Stack and not a List? Because we'll never need to
            // pluck an object from the start or middle of the array.
            // We'll always just grab the last one, which eliminates
            // any need to shuffle the objects around in memory.
            Stack<GameObject> inactive = null;
            // The List containing all the objects.
            List<GameObject> objects = null;

            // The prefab that we are pooling
            GameObject prefab;

            // The parent of the prefabs where are spawning
            Transform parent;

            // Constructor
            public Pool(GameObject prefab, int initialQty)
            {
                this.prefab = prefab;

                if (m_poolsParent == null)
                {
                    m_poolsParent = new GameObject("[ POOLS ]").transform;
                    m_poolsParent.SetParent(null);
                    GameObject.DontDestroyOnLoad(m_poolsParent.gameObject);
                }

                GameObject parentGO = new GameObject("[POOL] " + prefab.name);
                parentGO.transform.SetParent(m_poolsParent, false);

                parent = parentGO.transform;

                // If Stack uses a linked list internally, then this
                // whole initialQty thing is a placebo that we could
                // strip out for more minimal code. But it can't *hurt*.
                inactive = new Stack<GameObject>(initialQty);
                objects = new List<GameObject>(initialQty);
            }

            // Spawn an object from our pool
            public GameObject Spawn(Vector3 pos, Quaternion rot)
            {
                GameObject obj;
                if (inactive.Count == 0)
                {
                    // We don't have an object in our pool, so we
                    // instantiate a whole new object.
                    obj = prefab.Instantiate(parent);
                    obj.name = $"{prefab.name} ({nextId++})";
                    obj.transform.localScale = prefab.transform.localScale;
                    // Add a PoolMember component so we know what pool
                    // we belong to.
                    obj.AddComponent<PoolMember>().myPool = this;
                    objects.Add(obj);
                }
                else
                {
                    // Grab the last object in the inactive array
                    obj = inactive.Pop();

                    if (obj == null)
                    {
                        // The inactive object we expected to find no longer exists.
                        // The most likely causes are:
                        //   - Someone calling Destroy() on our object
                        //   - A scene change (which will destroy all our objects).
                        //     NOTE: This could be prevented with a DontDestroyOnLoad
                        //	   if you really don't want this.
                        // No worries -- we'll just try the next one in our sequence.

                        return Spawn(pos, rot);
                    }
                }

                obj.transform.position = pos;
                obj.transform.rotation = rot;
                obj.SetActive(true);
                return obj;

            }

            // Return an object to the inactive pool.
            public void Despawn(GameObject obj)
            {
                if (obj.activeInHierarchy)
                {
                    obj.SetActive(false);

                    // Since Stack doesn't have a Capacity member, we can't control
                    // the growth factor if it does have to expand an internal array.
                    // On the other hand, it might simply be using a linked list 
                    // internally.  But then, why does it allow us to specify a size
                    // in the constructor? Maybe it's a placebo? Stack is weird.
                    inactive.Push(obj);
                }
            }

            public void Destroy(bool p_destroyElementsOneByOne = false)
            {
                if (p_destroyElementsOneByOne)
                {
                    for (int i = 0; i < objects.Count; ++i)
                        UnityEngine.Object.DestroyImmediate(objects[i]);
                }

                objects.Clear();

                if (parent != null)
                    UnityEngine.Object.DestroyImmediate(parent.gameObject);
            }
        }

        /// <summary>
        /// Added to freshly instantiated objects, so we can link back
        /// to the correct pool on despawn.
        /// </summary>
        public class PoolMember : MonoBehaviour
        {
            public Pool myPool;
        }

        // All of our pools
        static Dictionary<GameObject, Pool> pools;

        /// <summary>
        /// Initialize our dictionary.
        /// </summary>
        static void Init(GameObject prefab = null, int qty = DEFAULT_POOL_SIZE)
        {
            if (pools == null)
            {
                pools = new Dictionary<GameObject, Pool>();
            }
            if (prefab != null && pools.ContainsKey(prefab) == false)
            {
                pools[prefab] = new Pool(prefab, qty);
            }
        }

        /// <summary>
        /// If you want to preload a few copies of an object at the start
        /// of a scene, you can use this. Really not needed unless you're
        /// going to go from zero instances to 100+ very quickly.
        /// Could technically be optimized more, but in practice the
        /// Spawn/Despawn sequence is going to be pretty darn quick and
        /// this avoids code duplication.
        /// </summary>
        public static void Preload(GameObject prefab, int qty = 1)
        {
            Init(prefab, qty);

            // Make an array to grab the objects we're about to pre-spawn.
            GameObject[] obs = new GameObject[qty];
            for (int i = 0; i < qty; i++)
            {
                obs[i] = Spawn(prefab, Vector3.zero, Quaternion.identity);
            }

            // Now despawn them all.
            for (int i = 0; i < qty; i++)
            {
                Despawn(obs[i]);
            }
        }

        public static T Spawn<T>(T p_prefab) where T : MonoBehaviour
        {
            return Spawn(p_prefab, p_prefab.transform.position, p_prefab.transform.rotation);
        }

        public static T Spawn<T>(T p_prefab, Vector3 p_pos, Quaternion p_rot) where T : MonoBehaviour
        {
            return Spawn(p_prefab.gameObject, p_pos, p_rot).GetComponent<T>();
        }

        public static GameObject Spawn(GameObject p_prefab)
        {
            return Spawn(p_prefab, p_prefab.transform.position, p_prefab.transform.rotation);
        }

        /// <summary>
        /// Spawns a copy of the specified prefab (instantiating one if required).
        /// NOTE: Remember that Awake() or Start() will only run on the very first
        /// spawn and that member variables won't get reset.  OnEnable will run
        /// after spawning -- but remember that toggling IsActive will also
        /// call that function.
        /// </summary>
        public static GameObject Spawn(GameObject p_prefab, Vector3 p_pos, Quaternion p_rot)
        {
            Init(p_prefab);

            return pools[p_prefab].Spawn(p_pos, p_rot);
        }

        public static void Despawn<T>(T p_element) where T : MonoBehaviour
        {
            Despawn(p_element.gameObject);
        }

        /// <summary>
        /// Despawn the specified gameobject back into its pool.
        /// </summary>
        public static void Despawn(GameObject p_obj)
        {
            if (p_obj != null)
            {
                PoolMember pm = p_obj.GetComponent<PoolMember>();
                if (pm == null)
                {
                    GameObject.Destroy(p_obj);
                }
                else
                {
                    pm.myPool.Despawn(p_obj);
                }
            }
        }

        /// <summary>
        /// Despawn the specified gameobject back into its pool after a given delay.
        /// </summary>
        // public static void Despawn(GameObject p_obj, float p_delay)
        // {
        //     new JCoroutine(_DespawnDelayed(p_obj, p_delay));
        // }

        // private static IEnumerator _DespawnDelayed(GameObject p_obj, float p_delay)
        // {
        //     yield return new WaitForSeconds(p_delay);
        //     Despawn(p_obj);
        // }

        public static void Destroy(GameObject p_prefab, bool p_destroyElementsOneByOne = false)
        {
            if (pools != null)
            {
                if (pools.ContainsKey(p_prefab))
                {
                    pools[p_prefab].Destroy(p_destroyElementsOneByOne);
                    pools.Remove(p_prefab);
                }

                if (pools.Count == 0 && m_poolsParent != null)
                    UnityEngine.Object.DestroyImmediate(m_poolsParent.gameObject);
            }
        }
    }
}