using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameTool : EditorWindow
{
    private string sceneName;

    [MenuItem("Tools/Play Game Tool")]
    public static void ShowWindow()
    {
        GetWindow<PlayGameTool>("Play Game Tool");
    }

    private void OnGUI()
    {
        GUILayout.Label("Enter Scene Name", EditorStyles.boldLabel);
        sceneName = EditorGUILayout.TextField("Scene Name", sceneName);

        if (GUILayout.Button("Run"))
        {
            PlayGame();
        }
    }

    private void PlayGame()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            EditorApplication.isPlaying            =  true;
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name cannot be empty.");
        }
    }
}