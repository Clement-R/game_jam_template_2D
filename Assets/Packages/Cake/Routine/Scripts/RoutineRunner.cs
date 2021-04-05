using System.Collections;

using UnityEngine;

using Cake.Utils;

namespace Cake.Routine
{
    public class RoutineRunner : Singleton<RoutineRunner>
    {
        public Coroutine StartRoutine(IEnumerator p_method)
        {
            return StartCoroutine(p_method);
        }

        public void StopRoutine(Coroutine p_coroutine)
        {
            StopCoroutine(p_coroutine);
        }
    }
}