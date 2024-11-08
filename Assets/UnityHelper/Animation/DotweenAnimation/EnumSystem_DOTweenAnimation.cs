using System;

namespace UnityHelper
{
    [Serializable]
    public enum ActionVisualKey
    {
        None,
        PlayForward,
        PlayBackward,
        Rewind,
        Restart,
        Pause,
        DestroyGameObject,
    }

    [Serializable]
    public enum AxisValue
    {
        XYZ,
        XY,
        YZ,
        ZX,
        X,
        Y,
        Z
    }
}