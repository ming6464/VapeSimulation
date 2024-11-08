using System;
using UnityEngine;
using UnityHelper;

namespace _GameAssets._Scripts.ObjectSimulation
{
    public abstract class ObjectSimulationBase : MonoBehaviour
    {
        protected bool  _ísReload;
        protected float _capacity;
        protected bool  _onRotateMode;

        protected virtual void OnEnable()
        {
            EventDispatcher.Instance.RegisterListener(EventID.RotateMode, OnRotateMode);
            EventDispatcher.Instance.RegisterListener(EventID.DefaultMode, OnDefaultMode);
            GetObjectBase();
        }

       

        protected virtual void OnDisable()
        {
            EventDispatcher.Instance.RemoveListener(EventID.RotateMode, OnRotateMode);
            EventDispatcher.Instance.RemoveListener(EventID.DefaultMode, OnDefaultMode);
        }
        
        private void OnDefaultMode(object obj)
        {
            _onRotateMode = false;
        }

        private void OnRotateMode(object obj)
        {
            _onRotateMode = true;
        }

        protected abstract void GetObjectBase();
        public abstract void OnReload();
    }
}