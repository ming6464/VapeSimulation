using System;
using UnityEngine;

public class ObjectSimulationContainer : MonoBehaviour
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RenderTexture _renderTexture;
    [SerializeField]
    private Camera _camera;
    
    private ObjectSimulationType _objectSimulationType;
    private int _selectedObjectIndex;

    private void Awake()
    {
        EventManager.selectedObjectIndex += selectedObjectIndex;
    }

    private void OnDisable()
    {
        EventManager.selectedObjectIndex -= selectedObjectIndex;
    }

    private void Start()
    {
        _objectSimulationType = EventManager.getSelectedObjectType();
        _selectedObjectIndex = EventManager.getSelectedObjectIndex();
        ChangeObjectSimulation();
        UpdateRenderTextureSize();
    }
    
    private void UpdateRenderTextureSize()
    {
        if (!_renderTexture || !_camera)
        {
            return;
        }
        
        _camera.targetTexture = null;
        _renderTexture.width  = Screen.width;
        _renderTexture.height = Screen.height;
        _renderTexture.Release();
        _renderTexture.Create();
        _camera.targetTexture = _renderTexture;
    }
    
    private void selectedObjectIndex(int obj)
    {
        if(_selectedObjectIndex == obj) return;
        _selectedObjectIndex = obj;
        ChangeObjectSimulation();
    }

    private void ChangeObjectSimulation()
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
                prefab = DataGame.Instance.GetScifiData(_selectedObjectIndex)?.prefab;
                break;
            case ObjectSimulationType.MachineGun: 
                prefab = DataGame.Instance.GetMachineData(_selectedObjectIndex)?.prefab;
                break;
            case ObjectSimulationType.VapeAndPod:
                prefab = DataGame.Instance.GetVapeData(_selectedObjectIndex)?.prefab;
                break;
            case ObjectSimulationType.LightSaber: 
                prefab = DataGame.Instance.GetLightSaberData(_selectedObjectIndex)?.prefab;
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
        _content.localPosition = Vector3.zero;
        _content.localRotation = Quaternion.identity;
        EventDispatcher.Instance.PostEvent(EventID.DefaultMode);
        EventDispatcher.Instance.PostEvent(EventID.ChangeMode,0);
    }

    private void ChangeObjectSimulation(GameObject prefab)
    {
        var objNew = Instantiate(prefab, _content);
        objNew.transform.localPosition = Vector3.zero;
        objNew.transform.localRotation = Quaternion.identity;
        objNew.transform.localScale = Vector3.one;
    }
}