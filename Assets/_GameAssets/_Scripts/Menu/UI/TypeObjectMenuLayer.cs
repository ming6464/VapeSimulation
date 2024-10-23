using ComponentUtilitys;
using UnityEngine;

public class TypeObjectMenuLayer : LayerBase
{
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
}