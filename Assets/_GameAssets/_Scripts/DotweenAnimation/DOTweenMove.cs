using System;
using DG.Tweening;
using UnityEngine;
using VInspector;

[AddComponentMenu("DOTween Animation Custom/DOTween Move")]
public class DOTweenMove : DOTweenAnimationBase
{
    [SerializeField, Variants("From","To", "From - To")]
    private string _moveWay;
    [SerializeField,Variants("XYZ","XY","YZ","ZX","X","Y","Z")]
    private string _axisValue;
    
    [SerializeField, ShowIfAny("_moveWay", "From","_moveWay","From - To")]
    private Vector3 _from;
    [SerializeField, ShowIfAny("_moveWay", "To","_moveWay","From - To")]
    private Vector3 _to;

    private Transform _targetTf;
    private RectTransform _targetRt;
    private bool _isRectTransform;

    protected override void SetupAwake()
    {
    }

    protected override void SetupStart()
    {
        base.SetupStart();
        if(!_hasTarget) return;
        _isRectTransform = _target.TryGetComponent(out _targetRt);

        if (!_isRectTransform)
        {
            _targetTf = _target.transform;
        }

        switch (_moveWay)
        {
            case "To":
                _from = _isRectTransform ? _targetRt.anchoredPosition3D : _targetTf.position;
                break;
            case "From":
                _to = _isRectTransform ? _targetRt.anchoredPosition3D : _targetTf.position;
                break;
        }
        
        var oldValue = _isRectTransform ? _targetRt.anchoredPosition3D : _targetTf.position;
        
        _from = LoadValueAxis(oldValue, _from, _axisValue);
        _to = LoadValueAxis(oldValue, _to, _axisValue);
        
    }
    
    private Vector3 LoadValueAxis(Vector3 oldValue, Vector3 newValue,string axisValue)
    {

        if (!axisValue.Contains("X"))
        {
            newValue.x = oldValue.x;
        }
        if (!axisValue.Contains("Y"))
        {
            newValue.y = oldValue.y;
        }
        if (!axisValue.Contains("Z"))
        {
            newValue.z = oldValue.z;
        }
        
        return newValue;
    }
    
    public override void PlayForward()
    {
        try
        {
            if (!_hasTarget)
                return;
            KillCurrentTween();

            if (_isRectTransform)
            {
                if (_targetRt.anchoredPosition3D.Equals(_to))
                    return;
                _targetRt.anchoredPosition3D = _from;
                _currentTween = _targetRt.DOAnchorPos3D(_to, _duration).SetDelay(_delay).SetEase(_easeType)
                                         .SetUpdate(_ignoreTimeScale);
            }
            else
            {
                if (_targetTf.position.Equals(_to))
                    return;
                _targetTf.position = _from;
                _currentTween = _targetTf.DOMove(_to, _duration).SetDelay(_delay).SetEase(_easeType)
                                         .SetUpdate(_ignoreTimeScale);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            
            throw;
        }
    }
    
    public override void PlayBackward()
    {
        if(!_hasTarget) return;
        KillCurrentTween();
        if (_isRectTransform)
        {
            if(_targetRt.anchoredPosition3D.Equals(_from)) return;
            _targetRt.anchoredPosition3D = _to;
            _currentTween = _targetRt.DOAnchorPos3D(_from, _duration).SetDelay(_delay).SetEase(_easeType).SetUpdate(_ignoreTimeScale);
        }
        else
        {
            if(_targetTf.position.Equals(_from)) return;
            _targetTf.position = _to;
            _currentTween = _targetTf.DOMove(_from, _duration).SetDelay(_delay).SetEase(_easeType).SetUpdate(_ignoreTimeScale);
        }
    }

    public override void Rewind()
    {
        if(!_hasTarget) return;
        KillCurrentTween();

        if (_isRectTransform)
        {
            _targetRt.anchoredPosition3D = _from; 
        }
        else
        {
            _targetTf.position = _from;
        }
    }
}