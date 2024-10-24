using System.Collections;
using DG.Tweening;
using UnityEngine;
using VInspector;

[AddComponentMenu("DOTween Animation Custom/DOTween Scale")]
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

    protected override void SetupAwake()
    {
        base.SetupAwake();
        _targetTf = _target.transform;
    }


    public override void PlayForward()
    {
        if(!_hasTarget) return;
        
        KillCurrentTween();
        if (_scaleType.Equals("Value"))
        {
            if(_targetTf.localScale.Equals(_to)) return;
            _targetTf.localScale = _from;
            _currentTween = _targetTf.DOScale(_to, _duration).SetDelay(_delay).SetEase(_easeType).SetUpdate(_ignoreTimeScale);
        }
        else
        {
            _timeCurve = 0;
            _coroutine = StartCoroutine(PlayForwardEnumerator());
        }
    }
    
    public override void PlayBackward()
    {
        if(!_hasTarget) return;
        KillCurrentTween();
        if (_scaleType.Equals("Value"))
        {
            if(_targetTf.localScale.Equals(_from)) return;
            _targetTf.localScale = _to;
            _targetTf.DOScale(_from, _duration).SetDelay(_delay).SetEase(_easeType).SetUpdate(_ignoreTimeScale);
        }
        else
        {
            _timeCurve = 1;
            _coroutine = StartCoroutine(PlayBackwardEnumerator());
        }
    }

    protected override void KillCurrentTween()
    {
        base.KillCurrentTween();
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    public override void Rewind()
    {
        if(!_hasTarget) return;
        KillCurrentTween();
        if (_scaleType.Equals("Value"))
        {
            _targetTf.localScale = _from;
        }
        else
        {
            _timeCurve = 0;
            _targetTf.localScale = _curve.Evaluate(_timeCurve) * Vector3.one;
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