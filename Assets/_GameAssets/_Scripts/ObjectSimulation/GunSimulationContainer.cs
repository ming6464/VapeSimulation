using System;
using UnityEngine;
using UnityHelper;

public class GunSimulationContainer : MonoBehaviour
{
    [SerializeField]
    private Transform _content;
    
    private int _selectedObjectIndex;
    
    private ObjectSimulationType _objectSimulationType;
    
    private void OnEnable()
    {
        EventManager.changeObjectSimulation += ChangeObjectSimulation;
    }

    private void OnDisable()
    {
        EventManager.changeObjectSimulation -= ChangeObjectSimulation;
    }

    private void Start()
    {
        _objectSimulationType = EventManager.getSelectedObjectType();
        _selectedObjectIndex  = EventManager.getSelectedObjectIndex();
        ChangeObjectSimulation(_selectedObjectIndex);
    }
    
    private void ChangeObjectSimulation()
    {
        var index = EventManager.getSelectedObjectIndex();
        if(_selectedObjectIndex == index) return;
        _selectedObjectIndex = index;
        ChangeObjectSimulation(_selectedObjectIndex);
    }

    private void ChangeObjectSimulation(int index)
    {
        foreach(Transform child in _content)
        {
            DestroyImmediate(child.gameObject);
        }
        if(!DataGame.Instance) return;

        GameObject prefab = null;
        
        switch (_objectSimulationType)
        {
            case ObjectSimulationType.ScifiGun:
                prefab = DataGame.Instance.GetScifiData(index)?.prefab;
                break;
            case ObjectSimulationType.MachineGun: 
                prefab = DataGame.Instance.GetMachineData(index)?.prefab;
                break;
        }

        if (prefab)
        {
            ChangeObjectSimulation(prefab);
        }
        
        ResetState();
    }

    private void ResetState()
    {
        _content.localRotation = Quaternion.identity;
        EventDispatcher.Instance.PostEvent(EventID.ChangeMode,0);
    }

    private void ChangeObjectSimulation(GameObject prefab)
    {
        var objNew = Instantiate(prefab, _content);
        objNew.transform.localPosition = Vector3.zero;
        objNew.transform.localRotation = Quaternion.identity;
        objNew.transform.localScale    = Vector3.one;
    }
    
}