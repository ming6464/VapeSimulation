using UnityEngine;
using UnityHelper;

namespace _GameAssets._Scripts
{
    public class GameState : Singleton<GameState>
    {
        #region Properties
        private int                  _objectSelectedIndex;
        private ObjectSimulationType _objectSimulationType;
        //Vape And Pod
        private int                  _tankSelectedIndex;
        private int                  _juiceSelectedIndex;
        #endregion
        public int objectSelectedIndex;
        public ObjectSimulationType objectSimulationType;
        [Header("Vape And Pod")]
        public int tankSelectedIndex;

        public override void Awake()
        {
            _objectSelectedIndex = objectSelectedIndex;
            _objectSimulationType = objectSimulationType;
            _tankSelectedIndex = tankSelectedIndex;
            //
            EventManager.selectedObjectIndex    += SetObjectSelectedIndex;
            EventManager.selectedObjectType     += SetObjectSimulationType;
            EventManager.getSelectedObjectIndex += GetObjectSelectedIndex;
            EventManager.getSelectedObjectType  += SetObjectSimulationType;
            //VApe And Pod
            EventManager.selectedTankIndex    += SetTankSelectedIndex;
            EventManager.getSelectedTankIndex += GetTankSelectedIndex;
            EventManager.selectedJuiceIndex   += SetJuiceSelectedIndex;
            EventManager.getSelectedJuiceIndex += GetJuiceSelectedIndex;
        }

        

        private void OnDestroy()
        {
            EventManager.selectedObjectIndex    -= SetObjectSelectedIndex;
            EventManager.selectedObjectType     -= SetObjectSimulationType;
            EventManager.getSelectedObjectIndex -= GetObjectSelectedIndex;
            EventManager.getSelectedObjectType  -= SetObjectSimulationType;
            //Vape And Pod
            EventManager.selectedTankIndex    -= SetTankSelectedIndex;
            EventManager.getSelectedTankIndex -= GetTankSelectedIndex;
            EventManager.selectedJuiceIndex   -= SetJuiceSelectedIndex;
            EventManager.getSelectedJuiceIndex -= GetJuiceSelectedIndex;
        }

        #region VapeAndPod Func

        private void SetTankSelectedIndex(int obj)
        {
            if(_tankSelectedIndex == obj) return;
            _tankSelectedIndex = obj;
            EventManager.changeTank?.Invoke();
            EventDispatcher.Instance.PostEvent(EventID.ChangeTank);
        }
        
        private int GetTankSelectedIndex()
        {
            return _tankSelectedIndex;
        }
        
        private void SetJuiceSelectedIndex(int obj)
        {
            if(_juiceSelectedIndex == obj) return;
            _juiceSelectedIndex = obj;
            EventManager.changeJuice?.Invoke();
            EventDispatcher.Instance.PostEvent(EventID.ChangeJuice);
        }
        
        private int GetJuiceSelectedIndex()
        {
            return _juiceSelectedIndex;
        }

        #endregion
        


        private void SetObjectSimulationType(ObjectSimulationType obj)
        {
            _objectSimulationType = obj;
        }

        private void SetObjectSelectedIndex(int obj)
        {
            if(_objectSelectedIndex == obj) return;
            _objectSelectedIndex = obj;
            EventManager.changeObjectSimulation?.Invoke();
            EventDispatcher.Instance.PostEvent(EventID.ChangeObjectSimulation);
        }

        private ObjectSimulationType SetObjectSimulationType()
        {
            return _objectSimulationType;
        }

        private int GetObjectSelectedIndex()
        {
            return _objectSelectedIndex;
        }
        
    }
}