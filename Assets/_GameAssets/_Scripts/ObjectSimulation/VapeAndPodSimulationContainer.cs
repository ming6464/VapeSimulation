using System;
using UnityEngine;

public class VapeAndPodSimulationContainer : MonoBehaviour
{
    #region Properties

    [SerializeField]
    private Transform _content;
    [SerializeField]
    private int _capacity;

    #endregion
    

    private void Start()
    {
        Debug.Log("VapeAndPodSimulationContainer Start");
    }
}