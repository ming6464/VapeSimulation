using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VInspector;

public class DOTweenScale : DOTweenAnimationBase
{
    [SerializeField,Variants("Value","Curve")]
    private string _scaleType;
    
    [SerializeField,ShowIf("_scaleType","Value")]
    private Vector3 _from;
    [SerializeField,ShowIf("_scaleType","Value")]
    private Vector3 _to;
    
    [SerializeField,ShowIf("_scaleType","Curve")]
    private AnimationCurve _curve;

    private Transform _targetTf;
    private float     _timeCurve;
    private Coroutine _coroutine;

    private void Awake()
    {
        _targetTf = _target.transform;
    }
    

    public void PlayForward()
    {
        if(!_targetTf) return;

        if (_scaleType.Equals("Value"))
        {
            if(_targetTf.localScale.Equals(_to)) return;
            _targetTf.localScale = _from;
            _targetTf.DOScale(_to, _duration).SetDelay(_delay).SetEase(_easeType).SetUpdate(_ignoreTimeScale);
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _timeCurve = 0;
            _coroutine = StartCoroutine(PlayForwardEnumerator());
        }
    }
    
    public void PlayBackward()
    {
        if(!_targetTf) return;

        if (_scaleType.Equals("Value"))
        {
            if(_targetTf.localScale.Equals(_from)) return;
            _targetTf.localScale = _to;
            _targetTf.DOScale(_from, _duration).SetDelay(_delay).SetEase(_easeType).SetUpdate(_ignoreTimeScale);
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _timeCurve = 1;
            _coroutine = StartCoroutine(PlayBackwardEnumerator());
        }
    }

    private IEnumerator PlayBackwardEnumerator()
    {
        
        while(_timeCurve > 0)
        {
            _timeCurve           -= Time.deltaTime / _duration;
            _timeCurve           =  Mathf.Clamp01(_timeCurve);
            _targetTf.localScale =  _curve.Evaluate(_timeCurve) * Vector3.one;
            yield return null;
        }
        _coroutine           =  null;
    }


    private IEnumerator PlayForwardEnumerator()
    {
        while(_timeCurve < 1)
        {
            _timeCurve           += Time.deltaTime / _duration;
            _timeCurve           =  Mathf.Clamp01(_timeCurve);
            _targetTf.localScale =  _curve.Evaluate(_timeCurve) * Vector3.one;
            yield return null;
        }
        _coroutine           =  null;
    }


}