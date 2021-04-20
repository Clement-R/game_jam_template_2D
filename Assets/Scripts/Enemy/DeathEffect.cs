using System.Collections;

using UnityEngine;

using Cake.Genoise;

using DG.Tweening;

public class DeathEffect : MonoBehaviour
{
    private BlinkEffect m_blinkEffect;

    private void Start()
    {
        m_blinkEffect = GetComponent<BlinkEffect>();
    }

    public void Death()
    {
        Routine.Start(_Play());
    }

    private IEnumerator _Play()
    {
        yield return m_blinkEffect.Play(0.1f, 1f).WaitForCompletion();
        Destroy(gameObject);
    }
}