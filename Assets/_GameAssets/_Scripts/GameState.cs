using UnityEngine;

namespace _GameAssets._Scripts
{
    public class GameState : Singleton<GameState>
    {
        #region Properties
        
        //private
        private int _objectSelectedIndex;
        private ObjectSimulationType _objectSimulationType;

        #endregion
        [Header("Test")]
        public int objectSelectedIndex;
        public ObjectSimulationType objectSimulationType;

        private void Awake()
        {
            _objectSelectedIndex = objectSelectedIndex;
            _objectSimulationType = objectSimulationType;
            //
            EventManager.selectedObject += SetObjectSelectedIndex;
            EventManager.selectedObjectType += SetObjectSimulationType;
            EventManager.defaultSelectedObjectIndex += GetObjectSelectedIndex;
        }
        
        private void OnDestroy()
        {
            EventManager.selectedObject -= SetObjectSelectedIndex;
            EventManager.selectedObjectType -= SetObjectSimulationType;
            EventManager.defaultSelectedObjectIndex -= GetObjectSelectedIndex;
        }

        private ObjectSimulationType SetObjectSimulationType()
        {
            return _objectSimulationType;
        }

        private int GetObjectSelectedIndex()
        {
            return _objectSelectedIndex;
        }
        

        private void SetObjectSelectedIndex(int arg1, ObjectSimulationType arg2)
        {
            _objectSelectedIndex = arg1;
            _objectSimulationType = arg2;
        }
    }
}