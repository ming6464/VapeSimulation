using System;
using UnityEngine;
using UnityHelper;

public class LayerControllerInMenu : MonoBehaviour
{

    #region Properties

    [Header("Reference")]
    
    [SerializeField]
    private LayerBase _typeObjectMenu;
    
    [SerializeField]
    private LayerBase _objectMenu;
    
    
    #endregion
    
    private void OnEnable()
    {
        EventDispatcher.Instance.RegisterListener(EventID.GoToObjectMenu, GoToObjectMenu);
        EventDispatcher.Instance.RegisterListener(EventID.GoToTypeObjectMenu, GoToTypeObjectMenu);
    }

    private void OnDisable()
    {
        EventDispatcher.Instance.RemoveListener(EventID.GoToObjectMenu, GoToObjectMenu);
        EventDispatcher.Instance.RemoveListener(EventID.GoToTypeObjectMenu, GoToTypeObjectMenu);
    }

    private void GoToTypeObjectMenu(object obj)
    {
        _typeObjectMenu.Init();
        OpenLayer(_typeObjectMenu.Open);
    }

    private void GoToObjectMenu(object obj)
    {
        if(obj == null) return;
        var type = (ObjectSimulationType)obj;
        EventManager.selectedObjectType?.Invoke(type);
        _objectMenu.Init();
        OpenLayer(_objectMenu.Open);
    }
    
    private void OpenLayer(Action action)
    {
        EventManager.loadLayer?.Invoke(CloseAllLayer, action);
    }
    
    private void CloseAllLayer()
    {
        _typeObjectMenu.Close();
        _objectMenu.Close();
    }
}