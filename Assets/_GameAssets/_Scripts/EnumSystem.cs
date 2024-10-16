using System;

[Serializable]
public enum PrimitiveDataType
{
    Int,
    Float,
    String,
    Bool,
    None
}

[Serializable]
public enum Axis
{
    X,
    Y,
    Z
}

[Serializable]
public enum ObjectSimulationType
{
    VapeAndPod,
    MachineGun,
    ScifiGun,
    LightSaber,
}