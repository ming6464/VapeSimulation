using System.Collections;
using DG.Tweening;
using UnityEngine;
using VInspector;

namespace UnityHelper
{
    [AddComponentMenu("DOTween Animation Custom/DOTween Scale Test")]
    public class DOTweenScaleTest : DOTweenAnimationBase
    {
        [SerializeField,Variants("From","To", "From - To","Curve")]
        private string _scaleType;
        [SerializeField,ShowIfAny("_scaleType","From","_scaleType","From - To")]
        private Vector3 _from;
        [SerializeField,ShowIfAny("_scaleType","To","_scaleType","From - To")]
        private Vector3 _to;
    
        [SerializeField,ShowIf("_scaleType","Curve")]
        private AnimationCurve _curve;

        private float     _timeCurve;
        private Coroutine _coroutine;

        protected override void Awake()
        {
            base.Awake();
            GenerationTween();
        }

        protected override void GenerationTween()
        {
            if(!_hasTarget || _tweenGenerationCalled) return;
            
            if (!_scaleType.Equals("Curve"))
            {
                if(_scaleType.Equals("To"))
                {
                    _from = _targetTf.localScale;
                }
                else if(_scaleType.Equals("From"))
                {
                    _to = _targetTf.localScale;
                }
                
                _targetTf.localScale = _from;

                _currentTween = _targetTf.DOScale(_to, _duration);
                
                if(_currentTween == null) return;
                
                _currentTween.SetTarget(_target).SetDelay(_delay).SetUpdate(_ignoreTimeScale).SetAutoKill(_autoKill).OnKill(() =>
                {
                    _currentTween = null;
                });
                
                if (_easeType == Ease.INTERNAL_Custom)
                {
                    _currentTween.SetEase(_easeCurve);
                }
                else
                {
                    _currentTween.SetEase(_easeType);
                }
                _currentTween.Pause();
            }
            else
            {
                _currentTween = null;
                Rewind();
            }
            
            _tweenGenerationCalled = true;
        }
        
        public override void PlayForward()
        {
            base.PlayForward();
        
            if (_scaleType.Equals("Curve"))
            {
                StopCoroutine();
                _coroutine = StartCoroutine(PlayForwardEnumerator());
            }
        }
    
        public override void PlayBackward()
        {
            base.PlayBackward();
            if (_scaleType.Equals("Curve"))
            {
                StopCoroutine();
                _coroutine = StartCoroutine(PlayBackwardEnumerator());
            }
        }

        private void StopCoroutine()
        {

            if (_coroutine == null)
            {
                return;
            }

            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        public override void Rewind()
        {
            base.Rewind();
            if (_scaleType.Equals("Curve"))
            {
                StopCoroutine();
                _timeCurve           = 0;
                _targetTf.localScale = _curve.Evaluate(_timeCurve) * Vector3.one;
            }
        }

        private IEnumerator PlayBackwardEnumerator()
        {
            if(!_hasTarget) yield break;
            _timeCurve = Mathf.Clamp01(_timeCurve);
            while(_timeCurve > 0)
            {
                _timeCurve           -= Time.deltaTime / _duration;
                _timeCurve           =  Mathf.Clamp01(_timeCurve);
                _targetTf.localScale =  _curve.Evaluate(_timeCurve) * Vector3.one;
                yield return null;
            }
            _coroutine = null;
        }


        private IEnumerator PlayForwardEnumerator()
        {
            if(!_hasTarget) yield break;
            _timeCurve = Mathf.Clamp01(_timeCurve);
            while(_timeCurve < 1)
            {
                _timeCurve           += Time.deltaTime / _duration;
                _timeCurve           =  Mathf.Clamp01(_timeCurve);
                _targetTf.localScale =  _curve.Evaluate(_timeCurve) * Vector3.one;
                yield return null;
            }
            _coroutine = null;
        }

    }
}