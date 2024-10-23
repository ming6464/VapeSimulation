using System;
using ComponentUtilitys;
using DG.Tweening;
using UnityEngine;

public class LoadingLayer : LayerBase
{
    #region Properties

    [Header("Reference")]
    [SerializeField]
    private CanvasGroup _canvasGroup;

    #endregion

    private void OnEnable()
    {
        EventManager.loadLayer += LoadLayer;
    }

    private void OnDisable()
    {
        EventManager.loadLayer -= LoadLayer;
    }

    private void LoadLayer(Action arg1, Action arg2)
    {
        Open(arg1);
        DOVirtual.DelayedCall(1f, () =>
        {
            Close(arg2);
        });
    }

    public override void Init()
    {
        
    }

    private void Open(Action action)
    {
        Open();
        _canvasGroup.DOFade(1f, 0.3f).OnComplete(() =>
        {
            action?.Invoke();
        });
    }

    private void Close(Action action)
    {
        action?.Invoke();
        _canvasGroup.DOFade(0f, 0.3f).OnComplete(() =>
        {
            Close();
        });
    }

    public override void Open()
    {
        _content.SetActive(true);
    }

    public override void Close()
    {
        _content.SetActive(false);
    }
}