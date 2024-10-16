using _GameAssets._Scripts.Data;
using UnityEngine;

public class DataGame : Singleton<DataGame>
{
    #region Properties
    public VapeAndPodData[]       VapeAndPodData       { get; private set;}
    public MachineData[]    MachineData   { get; private set;}
    public ScifiData[]      ScifiData      { get; private set;}
    public LightSaberData[] LightSaberData { get; private set;}
    
    public BackgroundData[] BackgroundData { get; private set; }
    
    [SerializeField]
    private ObjectSimulationDataSO _objectSimulationDataSO;

    private bool _hasData;
    #endregion

    #region Unity Func

    public override void Awake()
    {
        base.Awake();
        _hasData = _objectSimulationDataSO != null;
        if (!_hasData) return;
        VapeAndPodData = _objectSimulationDataSO.vapeAndPodSo.vapeAndPodData;
        MachineData    = _objectSimulationDataSO.machineGunSO.machineData;
        ScifiData      = _objectSimulationDataSO.scifiGunSO.scifiData;
        LightSaberData = _objectSimulationDataSO.lightSaberSO.lightSaberData;
        BackgroundData = _objectSimulationDataSO.backgroundSO.backgrounds;
    }

    #endregion

    #region Public Func

    public VapeAndPodData GetVapeData(int index)
    {
        if (!_hasData) return default;
        return VapeAndPodData[index];
    }
    
    public MachineData GetMachineData(int index)
    {
        if (!_hasData) return default;
        return MachineData[index];
    }
    
    public ScifiData GetScifiData(int index)
    {
        if (!_hasData) return default;
        return ScifiData[index];
    }
    
    public LightSaberData GetLightSaberData(int index)
    {
        if (!_hasData) return default;
        return LightSaberData[index];
    }
    
    public BackgroundData GetBackgroundData(int index)
    {
        if (!_hasData) return default;
        return BackgroundData[index];
    }

    #endregion

}