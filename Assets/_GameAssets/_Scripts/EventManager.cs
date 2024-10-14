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
}