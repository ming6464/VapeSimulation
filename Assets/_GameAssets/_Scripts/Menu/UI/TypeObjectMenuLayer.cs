using System;
using System.Collections;
using ComponentUtilitys;
using UnityEngine;
using UnityEngine.UI;

public class TypeObjectMenuLayer : LayerBase
{
    [SerializeField]
    private LayoutGroup _layoutGroup;
    [SerializeField]
    private DOTweenMove[] _buttonDOTweenMoveAnimaitonArr;
    public override void Init()
    {
        
    }

    public override void Open()
    {
        _content.SetActive(true);
    }

    public override void Close()
    {
        _content.SetActive(false);
    }

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        _layoutGroup.enabled = false;
        foreach(var button in _buttonDOTweenMoveAnimaitonArr)
        {
            button.enabled = true;
        }
    }
}