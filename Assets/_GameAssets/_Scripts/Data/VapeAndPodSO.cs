using System;
using UnityEngine;

[CreateAssetMenu(fileName = "VapeAndPodSO", menuName = "DataSO/VapeAndPodSO")]
public class VapeAndPodSO : ScriptableObject
{
    public VapeAndPodData[] vapeAndPodData;
}

[Serializable]
public class VapeAndPodData : ObjectDataBase
{
    public GameObject prefab;
}