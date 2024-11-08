using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class VapeAndPodSimulationContainer : MonoBehaviour
{
    #region Properties

    [SerializeField]
    private Transform _tipPosition;
    
    [SerializeField]
    private Transform _tankPosition;
    
    [SerializeField]
    private Material _juiceMaterial;
    
    [SerializeField]
    private Transform _vapePosition;
    
    [SerializeField]
    private int _capacity;
    
    //
    private int _currentTipIndex;
    private int _currentTankIndex;
    private int _currentVapeIndex;
    private int _currentJuiceIndex = -1;

    private int _tipLength;
    //
    private                 GameObject _currentTip;
    private                 GameObject _currentTank;
    private                 GameObject _currentVape;
    
    // KEY
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
    
    #endregion

    private void OnEnable()
    {
        EventManager.changeObjectSimulation += ChangeObjectSimulation;
        EventManager.changeTank             += ChangeTank;
        EventManager.changeJuice            += ChangeJuice;
    }
    

    private void OnDisable()
    {
        EventManager.changeObjectSimulation -= ChangeObjectSimulation;
        EventManager.changeTank -= ChangeTank;
        EventManager.changeJuice -= ChangeJuice;
    }
    

    private void Start()
    {
        _currentVapeIndex = EventManager.getSelectedObjectIndex();

        if (DataGame.Instance)
        {
            _tipLength         = DataGame.Instance.DripTips.Length;   
            var vapeData = DataGame.Instance.GetVapeData(_currentVapeIndex);
            _currentTankIndex = vapeData?.defaultTank ?? 0;
        }

        BuildVapeAndPod();
    }

    

    private void ResetTransform(Transform tf)
    {
        tf.localPosition = Vector3.zero;
        tf.localRotation = Quaternion.identity;
        tf.localScale = Vector3.one;
    }
    
    private void ChangeTank()
    {
        var index = EventManager.getSelectedTankIndex();
        if (index == _currentTankIndex) return;
        _currentTankIndex = index;
        BuildTank();
        BuildRandomTip();
    }
    
    private void ChangeJuice()
    {
        _currentJuiceIndex = EventManager.getSelectedJuiceIndex();
        BuildJuice();
    }

    private void ChangeObjectSimulation()
    {
        _currentVapeIndex = EventManager.getSelectedObjectIndex();
        BuildBox();
        BuildRandomTip();
    }

    private void BuildVapeAndPod()
    {
        BuildRandomTip();
        BuildTank();
        BuildJuice(true);
        BuildBox();
    }
    
    private void BuildTip()
    {
        if(!DataGame.Instance) return;
        if(_currentTip) Destroy(_currentTip);
        var tips = DataGame.Instance.DripTips;
        _currentTip = Instantiate(tips[_currentTipIndex].prefab, _tipPosition);
        ResetTransform(_currentTip.transform);
    }

    private void BuildTank()
    {
        if(!DataGame.Instance) return;
        if(_currentTank) Destroy(_currentTank);
        var tankData = DataGame.Instance.GetTank(_currentTankIndex);
        _currentTank = Instantiate(tankData.prefab, _tankPosition);
        ResetTransform(_currentTank.transform);
    }
    
    private void BuildJuice(bool isDefault = false)
    {
        if(!DataGame.Instance) return;
        Color color;

        if (isDefault)
        {
            color = DataGame.Instance.JuiceDefaultColor;
        }
        else
        {
            var juiceData = DataGame.Instance.Juices[_currentJuiceIndex];
            color = juiceData.color;
        }
        _juiceMaterial.SetColor(BaseColor, color);
    }
    
    private void BuildBox()
    {
        if(!DataGame.Instance) return;
        if(_currentVape) Destroy(_currentVape);
        var vapeData = DataGame.Instance.GetVapeData(_currentVapeIndex);
        _currentVape = Instantiate(vapeData.prefab, _vapePosition);
        ResetTransform(_currentVape.transform);
    }
    //
    
    private void BuildRandomTip()
    {
        if(!DataGame.Instance || _tipLength == 0) return;
        
        var index = Random.Range(0, _tipLength);
        if (_tipLength > 1 && index == _currentTipIndex)
        {
            BuildRandomTip();
            return;
        }

        _currentTipIndex = index;
        BuildTip();
    }
    
}