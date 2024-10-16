using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyBoardAction : MonoBehaviour
{
    public string[] nameSceneSwitch;
        
    private int index;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            index++;
            if (index >= nameSceneSwitch.Length)
            {
                index = 0;
            }
            SceneSwitch();
        }
    }

    private void SceneSwitch()
    {
        SceneManager.LoadScene(nameSceneSwitch[index]);
    }
}