
namespace ComponentUtilitys
{
    public class CardObjectInGame : CardBase
    {
        public override void OnClick()
        {
            EventManager.selectedObjectInGame?.Invoke(_cardID);
        }
    }
}