using UnityEngine;

public class Test2 : MonoBehaviour
{
    private void Start()
    {
        EventManager.goToMenuScene?.Invoke();
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10));
    }
}