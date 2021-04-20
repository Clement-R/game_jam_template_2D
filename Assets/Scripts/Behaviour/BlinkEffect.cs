using UnityEngine;

using DG.Tweening;

public class BlinkEffect : MonoBehaviour
{
    private Material m_spriteMaterial;

    private void Start()
    {
        var sr = GetComponent<SpriteRenderer>();
        m_spriteMaterial = sr.material;
    }

    public Tween Play(float p_duration, float p_strenght, Color? p_color = null, Ease p_ease = Ease.Linear)
    {
        var color = p_color ?? Color.white;

        m_spriteMaterial.SetColor("BlinkColor", color);
        return m_spriteMaterial.DOFloat(p_strenght, "BlinkAmount", p_duration / 2f).SetEase(p_ease).SetLoops(2, LoopType.Yoyo);
    }
}