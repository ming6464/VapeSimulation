using System.Collections.Generic;
using UnityEngine;
using UnityHelper;

public class ObjectMenuLayer : LayerBase
{
    #region Properties
    [Header("Reference")]
    [SerializeField]
    private Transform _objectListContent;

    [SerializeField]
    private CardItemObjectMenu _cardPrefab;
    
    private List<CardItemObjectMenu> _cardItems = new();
    
    #endregion
    
    
    private void CreateCardItem(ObjectDataBase[] objectData)
    {
        if (objectData == null)
        {
            Debug.LogError("ObjectData is null");
            return;
        }

        var childLength = _cardItems.Count;
        var i = 0;
        for (;i < objectData.Length; i++)
        {
            CardItemObjectMenu child;
            if (i < childLength)
            {
                child = _cardItems[i];
                child.gameObject.SetActive(true);
            }
            else
            {
                child = Instantiate(_cardPrefab, _objectListContent);
                _cardItems.Add(child);
            }
            child.SetUp(i, objectData[i].icon);
        }
        for(;i < _cardItems.Count; i++)
        {
            _cardItems[i].gameObject.SetActive(false);
        }
    }

    public override void Init()
    {
        ObjectDataBase[] objectData;

        switch (EventManager.getSelectedObjectType())
        {
            case ObjectSimulationType.VapeAndPod:
                objectData = DataGame.Instance.VapeAndPodData;
                break;
            case ObjectSimulationType.MachineGun:
                objectData = DataGame.Instance.MachineData;
                break;
            case ObjectSimulationType.ScifiGun: 
                objectData = DataGame.Instance.ScifiData;
                break;
            default: 
                objectData = DataGame.Instance.LightSaberData;
                break;
        }
        CreateCardItem(objectData);
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