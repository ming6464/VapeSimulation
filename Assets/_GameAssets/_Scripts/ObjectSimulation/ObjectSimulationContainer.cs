using System;
using UnityEngine;

public class ObjectSimulationContainer : MonoBehaviour
{
    #region Properties

    [SerializeField]
    private RenderTexture _renderTexture;
    [SerializeField]
    private Camera _camera;
    [Space(3)]
    [SerializeField]
    private VapeAndPodSimulationContainer _vapeAndPodSimulationContainer;
    [SerializeField]
    private GunSimulationContainer _gunSimulationContainer;
    [SerializeField]
    private LightSaberSimulationContainer _lightSaberSimulationContainer;
    
    #endregion
    
    
    private void Start()
    {
        var objectType = EventManager.getSelectedObjectType();
        UpdateRenderTextureSize();
        switch (objectType)
        {
            case ObjectSimulationType.VapeAndPod:
                _vapeAndPodSimulationContainer.enabled = true;
                break;
            case ObjectSimulationType.MachineGun:
                _gunSimulationContainer.enabled = true;
                break;
            case ObjectSimulationType.ScifiGun: 
                _gunSimulationContainer.enabled = true;
                break;
            case ObjectSimulationType.LightSaber: 
                _lightSaberSimulationContainer.enabled = true;
                break;
        }
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
    
}