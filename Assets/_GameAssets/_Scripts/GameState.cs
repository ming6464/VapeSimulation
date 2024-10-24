using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GameAssets._Scripts
{
    public class GameState : Singleton<GameState>
    {
        #region Properties
        private int _objectSelectedIndex;
        private ObjectSimulationType _objectSimulationType;

        #endregion
        [Header("Test")]
        public int objectSelectedIndex;
        public ObjectSimulationType objectSimulationType;
        public string GAMEPLAYNAME = "GamePlay";
        
        private void Awake()
        {
            _objectSelectedIndex = objectSelectedIndex;
            _objectSimulationType = objectSimulationType;
            //
            EventManager.selectedObject         += SetObjectSelected;
            EventManager.selectedObjectIndex    += SetObjectSelectedIndex;
            EventManager.selectedObjectType     += SetObjectSimulationType;
            EventManager.getSelectedObjectIndex += GetObjectSelectedIndex;
            EventManager.getSelectedObjectType  += SetObjectSimulationType;
            EventManager.playGame               += playGame;
        }

        private void OnDestroy()
        {
            EventManager.selectedObject         -= SetObjectSelected;
            EventManager.selectedObjectIndex    -= SetObjectSelectedIndex;
            EventManager.selectedObjectType     -= SetObjectSimulationType;
            EventManager.getSelectedObjectIndex -= GetObjectSelectedIndex;
            EventManager.getSelectedObjectType  -= SetObjectSimulationType;
            EventManager.playGame               -= playGame;
        }
        

        private void SetObjectSimulationType(ObjectSimulationType obj)
        {
            _objectSimulationType = obj;
        }

        private void SetObjectSelectedIndex(int obj)
        {
            _objectSelectedIndex = obj;
            EventManager.changeObjectSimulation?.Invoke();
        }

        private ObjectSimulationType SetObjectSimulationType()
        {
            return _objectSimulationType;
        }

        private int GetObjectSelectedIndex()
        {
            return _objectSelectedIndex;
        }

        private void SetObjectSelected(int arg1, ObjectSimulationType arg2)
        {
            _objectSelectedIndex = arg1;
            _objectSimulationType = arg2;
        }
        
        private void playGame()
        {
            SceneManager.LoadScene(GAMEPLAYNAME);
        }
        
    }
}