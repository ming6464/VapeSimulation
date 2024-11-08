using UnityEngine;

namespace UnityHelper
{
    public abstract class LayerBase : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _content;

        protected virtual void OnValidate()
        {
            if (!_content)
            {
                _content = gameObject;
            }
        }

        public abstract void Init();

        public abstract void Open();

        public abstract void Close();

    }
}