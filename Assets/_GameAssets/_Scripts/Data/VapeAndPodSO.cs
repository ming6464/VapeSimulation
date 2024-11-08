using System;
using UnityEngine;

[CreateAssetMenu(fileName = "VapeAndPodSO", menuName = "DataSO/VapeAndPodSO")]
public class VapeAndPodSO : ScriptableObject
{
    public VapeAndPodData[] vapeAndPodData;
    public DripTip[]        dripTips;
    public Tank[]           tanks;
    public Juice[]          juices;

    [Header("--")]
    public Color juiceDefault;
}

[Serializable]
public class VapeAndPodData : ObjectDataBase
{
    public GameObject prefab;
    public int        defaultTank;
}

//Đầu đốt tinh dầu
[Serializable]
public struct DripTip
{
    public GameObject prefab;
}

//Buồng chứa tinh dầu
[Serializable]
public class Tank : ObjectDataBase
{
    public GameObject prefab;
}

//Tinh dầu
[Serializable]
public class Juice : ObjectDataBase
{
    public Color color;
}