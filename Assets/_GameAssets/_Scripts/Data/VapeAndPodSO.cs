using System;
using UnityEngine;

[CreateAssetMenu(fileName = "VapeAndPodSO", menuName = "DataSO/VapeAndPodSO")]
public class VapeAndPodSO : ScriptableObject
{
    public VapeAndPodData[] vapeAndPodData;
    public DripTip[]        dripTips;
    public Tank[]           tanks;
    public Juice[]          juices;
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
public struct Tank
{
    public Sprite     icon;
    public GameObject prefab;
}

//Tinh dầu
[Serializable]
public struct Juice
{
    public Sprite icon;
    public Color color;
}