using UnityEngine;

namespace _GameAssets._Scripts.Data
{
    [CreateAssetMenu(fileName = "ObjectSimulationDataSO", menuName = "DataSO/ObjectSimulationDataSO", order = 0)]
    public class ObjectSimulationDataSO : ScriptableObject
    {
        public VapeAndPodSO       vapeAndPodSo;
        public MachineGunSO machineGunSO;
        public ScifiGunSO   scifiGunSO;
        public LightSaberSO lightSaberSO;
        public BackgroundSO backgroundSO;
    }
}