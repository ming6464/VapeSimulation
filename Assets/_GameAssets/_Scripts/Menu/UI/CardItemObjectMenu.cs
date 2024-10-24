using ComponentUtilitys;
using UnityEngine;

public class CardItemObjectMenu : CardBase
{
    public override void OnClick()
    {
        EventManager.selectedObjectIndex?.Invoke(_cardID);
        EventManager.goToGamePlayScene?.Invoke();
    }
}