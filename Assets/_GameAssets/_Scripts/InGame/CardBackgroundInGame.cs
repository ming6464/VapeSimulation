using UnityEngine;

namespace ComponentUtilitys
{
    public class CardBackgroundInGame : CardBase
    {
        public override void OnClick()
        {
            EventManager.selectedBackgroundInGame?.Invoke(_cardID);
        }
    }
}