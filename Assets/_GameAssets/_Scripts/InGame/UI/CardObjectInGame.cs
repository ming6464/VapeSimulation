using ComponentUtilitys;

public class CardObjectInGame : CardBase
{
    public override void OnClick()
    {
        EventManager.selectedObjectIndex?.Invoke(_cardID);
    }
}