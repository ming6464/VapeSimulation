using System;
using UnityEngine;

public static class EventManager
{
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

    public static Func<int> defaultSelectedObjectIndex;

    public static Func<ObjectSimulationType> selectedObjectType;

    #region InGame

    public static Action<int> selectedObjectInGame;
    public static Action<int> selectedBackgroundInGame;

    #endregion
}