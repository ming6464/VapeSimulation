using System;
using UnityEngine;

public static class EventManager
{
    /// <summary>
    /// Hàm được gọi để kiểm tra xem có sự rung lắc hay không.
    /// </summary>
    public static Action onShake;
    
    /// <summary>
    /// Hàm được gọi để kiểm tra xem có sự tương tác của chuột hay không.
    /// </summary>
    public static Func<bool> onMouseInteract;

    /// <summary>
    /// Hành động được gọi khi sự kiện thả chuột xảy ra.
    /// </summary>
    public static Action<Vector2> onPointerUp;

    /// <summary>
    /// Hành động được gọi khi sự kiện nhấn chuột xảy ra.
    /// </summary>
    public static Action<Vector2> onPointerDown;

    /// <summary>
    /// Hành động được gọi khi sự kiện kéo chuột xảy ra.
    /// Nghĩa cuả biến là: startPosition, previousPosition, currentPosition
    /// </summary>
    public static Action<Vector2, Vector2, Vector2> onDrag;

    public static Action<int, ObjectSimulationType> selectedObject;

    public static Action<ObjectSimulationType> selectedObjectType;

    public static Action<int> selectedObjectIndex;

    public static Action changeObjectSimulation;

    public static Func<ObjectSimulationType> getSelectedObjectType;

    public static Func<int> getSelectedObjectIndex;
    
    public static Action playGame;

    public static Action<Action,Action> loadLayer;

    #region InGame

    public static Action<int> selectedBackgroundInGame;

    #endregion
    
    
}