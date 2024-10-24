using System;
using DG.Tweening;
using UnityEngine;
using VInspector;

public abstract class DOTweenAnimationBase : MonoBehaviour
{
    [Foldout("Manager")]
    
    [SerializeField]
    private ActionVisualKey _onEnable = ActionVisualKey.PlayForward;
    [SerializeField]
    private ActionVisualKey _onDisable = ActionVisualKey.Rewind;
    [SerializeField]
    private ActionVisualKey _onStart = ActionVisualKey.Restart;
    
    [EndFoldout]
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

    protected bool    _hasTarget;
    protected Tweener _currentTween;
    protected bool    _isSetup;

    #region Unity Func

    protected virtual void Awake()
    {
        _hasTarget = _target;
        if(!_hasTarget) return;
        SetupAwake();
    }

    
    
    protected virtual void OnValidate()
    {
        if (!_target)
        {
            _target = gameObject;
        }
    }

    protected virtual void OnEnable()
    {
        PlayActionVisual(_onEnable);
    }
    
    protected virtual void OnDisable()
    {
        PlayActionVisual(_onDisable);
    }

    protected virtual void Start()
    {
        SetupStart();
        PlayActionVisual(_onStart);
    }

    
    
    protected virtual void Update()
    {
        
    }
    
    protected virtual void LateUpdate()
    {
        
    }
    
    protected virtual void FixedUpdate()
    {
        
    }

    protected virtual void OnDestroy()
    {
        
    }

    #endregion
    
    protected virtual void SetupAwake()
    {
        _isSetup = true;
    }
    
    protected virtual void SetupStart()
    {
        _isSetup = true;
    }
    
    protected virtual void PlayActionVisual(ActionVisualKey actionVisualKey)
    {
        if(!_isSetup) return;
        if(actionVisualKey == ActionVisualKey.None) return;
        switch (actionVisualKey)
        {
            case ActionVisualKey.PlayForward:
                PlayForward();
                break;
            case ActionVisualKey.PlayBackward:
                PlayBackward();
                break;
            case ActionVisualKey.Rewind:
                Rewind();
                break;
            case ActionVisualKey.Restart:
                Restart();
                break;
            case ActionVisualKey.Pause:
                Pause();
                break;
            case ActionVisualKey.Kill:
                KillCurrentTween();
                break;
            case ActionVisualKey.DestroyGameObject:
                DestroyImmediate(gameObject);
                break;
        }
    }
    protected virtual void KillCurrentTween()
    {
        if (_currentTween.IsActive())
        {
            _currentTween.Kill();
        }
    }

    #region Public Methods

    public abstract void PlayForward();

    public abstract void PlayBackward();
    
    public abstract void Rewind();

    public virtual void Restart()
    {
        if(!_hasTarget) return;
        Rewind();
        PlayForward();
    }

    public virtual void Pause()
    {
        KillCurrentTween();
    }

    #endregion
    
    #region Enum

    [Serializable]
    public enum ActionVisualKey
    {
        None,
        PlayForward,
        PlayBackward,
        Rewind,
        Restart,
        Pause,
        Kill,
        DestroyGameObject
    }

    #endregion
}

