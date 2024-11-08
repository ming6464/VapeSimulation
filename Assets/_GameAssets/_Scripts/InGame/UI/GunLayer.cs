using TMPro;
using UnityEngine;
using UnityHelper;

namespace _GameAssets._Scripts.InGame.UI
{
    public class GunLayer : MonoBehaviour
    {
        [Header("Capacity")]
        [SerializeField]
        private TMP_Text _capacityText;

        private int _capacityDelta;
        private int _capacity;

        private void OnEnable()
        {
            EventManager.selectedObjectIndex += SelectedObjectIndex;
            EventDispatcher.Instance.RegisterListener(EventID.Shooting, OnShooting);
            EventDispatcher.Instance.RegisterListener(EventID.Reload, OnReload);
        }

        

        private void OnDisable()
        {
            EventManager.selectedObjectIndex -= SelectedObjectIndex;
            EventDispatcher.Instance.RemoveListener(EventID.Shooting, OnShooting);
            EventDispatcher.Instance.RemoveListener(EventID.Reload, OnReload);
        }

        private void Start()
        {
            SelectedObjectIndex(EventManager.getSelectedObjectIndex());
        }

        private void SelectedObjectIndex(int obj)
        {
            _capacity = 0;
            switch (EventManager.getSelectedObjectType())
            {
                case ObjectSimulationType.MachineGun:
                    _capacity = DataGame.Instance.GetMachineData(obj).capacity;
                    break;
                case ObjectSimulationType.ScifiGun:
                    _capacity = DataGame.Instance.GetScifiData(obj).capacity;
                    break;
            }
            _capacityDelta = _capacity;
            UpdateCapacityText();
        }
        
        private void UpdateCapacityText()
        {
            _capacityText.text = $"x {_capacityDelta}";
        }
        
        private void OnReload(object obj)
        {
            _capacityDelta = _capacity;
            UpdateCapacityText();
        }

        private void OnShooting(object obj)
        {
            if(_capacityDelta <= 0) return;
            _capacityDelta--;
            UpdateCapacityText();
        }
    }
}