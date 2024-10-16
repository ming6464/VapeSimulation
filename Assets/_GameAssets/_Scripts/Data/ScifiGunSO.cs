using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ScifiGunSO", menuName = "DataSO/ScifiGunSO")]
public class ScifiGunSO : ScriptableObject
{
    public ScifiData[] scifiData;
}

[Serializable]
public class ScifiData : ObjectDataBase
{
    public GameObject prefab;
}