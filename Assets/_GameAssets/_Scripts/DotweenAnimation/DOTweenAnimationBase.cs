using System;
using DG.Tweening;
using UnityEngine;

public class DOTweenAnimationBase : MonoBehaviour
{
    [SerializeField]
    protected GameObject _target;
    [SerializeField]
    protected float _duration;
    [SerializeField]
    protected float _delay;
    [SerializeField]
    protected bool _ignoreTimeScale;
    [SerializeField]
    protected Ease _easeType = Ease.OutQuad;


    protected virtual void OnValidate()
    {
        if (!_target)
        {
            _target = gameObject;
        }
    }
}