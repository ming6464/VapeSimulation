using DG.Tweening;
using UnityEngine;

public class DotweenAnimationBase : MonoBehaviour
{
    [SerializeField]
    protected float _duration;
    [SerializeField]
    protected float _delay;
    [SerializeField]
    protected bool _ignoreTimeScale;
    [SerializeField]
    protected Ease _easeType = Ease.OutQuad;
}