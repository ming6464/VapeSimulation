using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundSO", menuName = "DataSO/BackgroundSO")]
public class BackgroundSO : ScriptableObject
{
    public BackgroundData[] backgrounds;
}
    
[Serializable]
public class BackgroundData : ObjectDataBase
{
    public Sprite  sprite;
    public Vector2 resolution;
}