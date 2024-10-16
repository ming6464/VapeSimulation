using System;
using UnityEngine;

[CreateAssetMenu(menuName = "DataSO/Test")]
public class Test : ScriptableObject
{
    public TestData[] testDatas;
}

[Serializable]
public class TestData
{
    public GameObject gameObject;
    public int        index;
}