using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityHelper;

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