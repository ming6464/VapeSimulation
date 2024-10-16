using UnityEngine;
using UnityEngine.UI;

namespace ComponentUtilitys
{
    public abstract class CardBase : MonoBehaviour,IOnClick
    {
        [SerializeField]
        protected Image _cardImage;
        
        protected int _cardID;
        
        public void SetUp(int id, Sprite sprite)
        {
            _cardID = id;
            SetCardImage(sprite);
        }
        
        protected void SetCardImage(Sprite sprite)
        {
            _cardImage.sprite = sprite;
        }

        public abstract void OnClick();
    }
}