using _GameAssets._Scripts.Data;
using UnityEngine;

public class DataGame : Singleton<DataGame>
{
    #region Properties
    //Vape And Pod {
    public VapeAndPodData[]       VapeAndPodData       { get; private set;}
    public Tank[]          Tanks           { get; private set;}
    public Juice[]         Juices          { get; private set;}
    public DripTip[]       DripTips        { get; private set;}
    
    public Color JuiceDefaultColor { get; private set; }

    
    //Vape And Pod }
    
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
        //Vape And Pod {
        VapeAndPodData = _objectSimulationDataSO.vapeAndPodSo.vapeAndPodData;
        Tanks          = _objectSimulationDataSO.vapeAndPodSo.tanks;
        Juices         = _objectSimulationDataSO.vapeAndPodSo.juices;
        DripTips       = _objectSimulationDataSO.vapeAndPodSo.dripTips;
        JuiceDefaultColor = _objectSimulationDataSO.vapeAndPodSo.juiceDefault;
        //Vape And Pod }
        MachineData    = _objectSimulationDataSO.machineGunSO.machineData;
        ScifiData      = _objectSimulationDataSO.scifiGunSO.scifiData;
        LightSaberData = _objectSimulationDataSO.lightSaberSO.lightSaberData;
        BackgroundData = _objectSimulationDataSO.backgroundSO.backgrounds;
    }

    #endregion

    #region Public Func

    //Vape And Pod {
    public VapeAndPodData GetVapeData(int index)
    {
        if (!_hasData) return default;
        return VapeAndPodData[index];
    }
    
    public Tank GetTank(int index)
    {
        if (!_hasData) return default;
        return Tanks[index];
    }
    
    public Juice GetJuice(int index)
    {
        if (!_hasData) return default;
        return Juices[index];
    }
    
    public DripTip GetDripTip(int index)
    {
        if (!_hasData) return default;
        return DripTips[index];
    }
    
    //Vape And Pod }
    
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