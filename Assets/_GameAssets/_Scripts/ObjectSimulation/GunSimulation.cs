using System;
using System.Collections;
using UnityEngine;
using UnityHelper;

namespace _GameAssets._Scripts.ObjectSimulation
{
    public class GunSimulation : ObjectSimulationBase
    {
        #region Properties
        
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private string _shootingNameAnimation;
        [SerializeField]
        private string _reloadNameAnimation;

        [SerializeField]
        private float _delayPlaySmokeEffect = 0.4f;
        //
        private MachineData _machineData;
        private float       _currentShootingMode;
        private float       _nextShootingMode;
        private bool        _isShooting;
        private bool        _isReloading;
        private int         _countShooting = 1;
        private float       _delayShooting;
        private Coroutine   _delayShootingCoroutine;
        private Coroutine   _delayPlaySmokeEffectCoroutine;
        #endregion

        #region Implement
        
        protected override void OnEnable()
        {
            base.OnEnable();
            EventDispatcher.Instance.RegisterListener(EventID.ChangeMode,OnChangeMode);
            EventManager.onPointerDown   += OnPointerDown;
            EventManager.onShake         += OnShake;
        }
        

        protected override void OnDisable()
        {
            base.OnDisable();
            EventDispatcher.Instance.RemoveListener(EventID.ChangeMode,OnChangeMode);
            EventManager.onPointerDown   -= OnPointerDown;
            EventManager.onShake         -= OnShake;
            if(_delayShootingCoroutine != null)
            {
                StopCoroutine(_delayShootingCoroutine);
            }
        }
        

        protected override void GetObjectBase()
        {
            if(!DataGame.Instance) return;
            _machineData = DataGame.Instance.GetMachineData(EventManager.getSelectedObjectIndex());
            _capacity    = _machineData.capacity;
        }
        
        private void Update()
        {
            CheckAndUpdateShootingMode();
            CheckAndReload();
            CheckAndAutoShootingMode();
        }

        #endregion

        #region Func Animation Reference
        
        public void OnShooting()
        {
            if (_capacity <= 0 || _countShooting <= 0)
            {
                _countShooting = 0;
                 return;
            }
            _capacity--;
            _countShooting--;
            
            EventDispatcher.Instance.PostEvent(EventID.Shooting);
        }
        
        public void OnShootingEnd()
        {
            if (_countShooting > 0)
            {
                _delayShootingCoroutine = StartCoroutine(DelayShootingNextFrame());
                return;
            }
            _isShooting = false;
            if(_delayPlaySmokeEffectCoroutine != null)
            {
                StopCoroutine(_delayPlaySmokeEffectCoroutine);
            }
            _delayPlaySmokeEffectCoroutine = StartCoroutine(DelayPlaySmokeEffect(_delayPlaySmokeEffect));
        }
        
        public override void OnReload()
        {
            _capacity    = _machineData.capacity;
            _isReloading = false;
            EventDispatcher.Instance.PostEvent(EventID.Reload);
        }
        

        #endregion
        
        private void CheckAndUpdateShootingMode()
        {
            if(_isShooting && _countShooting > 0) return;
            if(_currentShootingMode - _nextShootingMode == 0) return;
            _currentShootingMode = _nextShootingMode;
        }

        private void CheckAndAutoShootingMode()
        {
            if(!CheckCanShooting()) return;
            
            if (_currentShootingMode - 2 != 0 || !EventManager.onMouseInteract())
            {
                return;
            }
            _countShooting = 1;
            _delayShooting = _machineData.autoDelay;
            PlayShootingAnimation("Auto");
        }
        
        private void CheckAndReload()
        {
            if(_isShooting || _isReloading) return;
            if(_capacity > 0) return;
            _isReloading = true;
            PlayAnimation(_reloadNameAnimation);
        }
        
        private void OnChangeMode(object obj)
        {
            _nextShootingMode = (int)obj;
        }

        private void OnShake()
        {
            if(!CheckCanShooting()) return;
            if(_currentShootingMode - 3 != 0) return;
            _delayShooting = 0;
            _countShooting = 1;
            PlayShootingAnimation();
        }

        private void OnPointerDown(Vector2 obj)
        {
            if(!CheckCanShooting()) return;
            
            _countShooting = 0;

            if (_currentShootingMode == 0)
            {
                _delayShooting = 0;
                _countShooting = 1;
            }else if (_currentShootingMode - 1 == 0)
            {
                _delayShooting = _machineData.burstDelay;
                _countShooting = 5;
            }

            if (_countShooting > 0)
            {
                PlayShootingAnimation();
            }
            
        }

        private void PlayShootingAnimation(string check = "")
        {
            if(_delayPlaySmokeEffectCoroutine != null)
            {
                StopCoroutine(_delayPlaySmokeEffectCoroutine);
                _delayPlaySmokeEffectCoroutine = null;
            }

            if (_onRotateMode)
            {
                _isShooting = false;
                _countShooting = 0;
                return;
            }
            _isShooting = true;
            PlayAnimation(_shootingNameAnimation);
            
        }

        private IEnumerator DelayShootingNextFrame()
        {
            yield return new WaitForEndOfFrame();
            PlayShootingAnimation();
        }
        private IEnumerator DelayPlaySmokeEffect(float delay)
        {
            yield return new WaitForSeconds(delay);
            EventDispatcher.Instance.PostEvent(EventID.PlaySmokeEffect);
        }
        
        private void PlayAnimation(string name)
        {
            if (!_animator)
            {
                Debug.LogError("Animator bị null");
            }
            _animator.Play(name);
        }

        private bool CheckCanShooting()
        {
            var check = !_isReloading && !_isShooting;
            if(_countShooting <= 0)
            {
                _delayShooting -= Time.deltaTime;
            }

            return check && _delayShooting <= 0;
        }
        
    }
}