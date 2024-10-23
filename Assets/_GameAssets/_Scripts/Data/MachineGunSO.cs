using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MachineGunSO", menuName = "DataSO/MachineGunSO")]
public class MachineGunSO : ScriptableObject
{
    public MachineData[] machineData;
}

[Serializable]
public class MachineData : ObjectDataBase
{
    public GameObject prefab;
    [Header("Info")]
    public int   capacity;
    public float burstDelay;
    public float autoDelay;
    [Header("Mode")]
    public bool auto;
    public bool burst;
}