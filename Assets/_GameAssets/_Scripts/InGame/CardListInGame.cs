using _GameAssets._Scripts;
using ComponentUtilitys;
using UnityEngine;
using VInspector;

public class CardListInGame : MonoBehaviour
{
    [Variants("Object Simulation","Background")]
    public string type;
    [Space(10)]
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private CardBase _cardPrefab;
    
    private void Start()
    {
        if (!_content)
            return;
        var objectDataBases = GetDataList();
        if(objectDataBases == null) return;
        SpawnCard(objectDataBases);
        
    }

    private ObjectDataBase[] GetDataList()
    {
        if (!DataGame.Instance || !GameState.Instance)
        {
            return null;
        }
        ObjectDataBase[] objectDataBases = null;
        
        if(type.Equals("Background"))
        {
            objectDataBases = DataGame.Instance.BackgroundData;
        }
        else
        {
            switch (GameState.Instance.objectSimulationType)
            {
                case ObjectSimulationType.VapeAndPod:
                    objectDataBases = DataGame.Instance.VapeAndPodData;
                    break;
                case ObjectSimulationType.ScifiGun:
                    objectDataBases = DataGame.Instance.ScifiData;
                    break;
                case ObjectSimulationType.LightSaber:
                    objectDataBases = DataGame.Instance.LightSaberData;
                    break;
                default:
                    objectDataBases = DataGame.Instance.MachineData;
                    break;
            }
        }
        
        

        return objectDataBases;
    }

    private void SpawnCard(ObjectDataBase[] objectDataBases)
    {
        for(var i = 0; i < objectDataBases.Length; i++)
        {
            var card = Instantiate(_cardPrefab, _content);
            card.SetUp(i, objectDataBases[i].icon);
        }
    }
}