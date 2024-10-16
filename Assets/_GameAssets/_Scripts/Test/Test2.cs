using UnityEngine;

public class Test2 : MonoBehaviour
{
    private void Start()
    {
        if(!DataGame.Instance) return;
        if(DataGame.Instance.MachineData == null) return;

        foreach (var gun in DataGame.Instance.MachineData)
        {
            var gunObject = Instantiate(gun.prefab, GetRandomPosition(), Quaternion.identity);
        }
        
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
    }
}