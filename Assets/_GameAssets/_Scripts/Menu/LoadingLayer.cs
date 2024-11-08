using System;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityHelper;

public class LoadingLayer : LayerBase
{
    #region Properties

    [Header("Reference")]
    [SerializeField]
    private CanvasGroup _canvasGroup;

    [Header("Data")]
    [SerializeField]
    private string _menuSceneName = "Menu";

    [SerializeField]
    private string _gamePlaySceneName = "GamePlay";

    #endregion

    private void OnEnable()
    {
        EventManager.loadLayer         += LoadLayer;
        EventManager.goToGamePlayScene += GoToGamePlayScene;
        EventManager.goToMenuScene     += GoToMenuScene;
        EventDispatcher.Instance.RegisterListener(EventID.GoToGamePlayScene,GoToGamePlayScene);
        EventDispatcher.Instance.RegisterListener(EventID.GoToMenuScene,GoToMenuScene);
    }

    private void OnDisable()
    {
        EventManager.loadLayer         -= LoadLayer;
        EventManager.goToGamePlayScene -= GoToGamePlayScene;
        EventManager.goToMenuScene     -= GoToMenuScene;
    }
    
    private void GoToMenuScene(object obj)
    {
        GoToMenuScene();
    }
    
    private void GoToGamePlayScene(object obj)
    {
        GoToGamePlayScene();
    }
    
    private void GoToMenuScene()
    {
        LoadingScene(_menuSceneName);
    }

    private void GoToGamePlayScene()
    {
        LoadingScene(_gamePlaySceneName);
    }
    
    private async void LoadingScene(string sceneName)
    {
        Open();
        _canvasGroup.DOFade(1f, 0.3f);
        await Task.Delay(300);
        var loadingScene = await LoadSceneAsyncDontActive(sceneName);
        await Task.Delay(1000);
        loadingScene.allowSceneActivation = true;
        _canvasGroup.DOFade(0f, 0.3f).OnComplete(() =>
        {
            Close();
        });
    }

    private async Task<AsyncOperation> LoadSceneAsyncDontActive(string sceneName)
    {
        var loading = SceneManager.LoadSceneAsync(sceneName);
        loading.allowSceneActivation = false;

        while (loading.progress < 0.9f)
        {
            await Task.Yield();
        }

        return loading;
    }

    private void LoadLayer(Action arg1, Action arg2)
    {
        Open(arg1);
        DOVirtual.DelayedCall(1f, () =>
        {
            Close(arg2);
        });
    }

    public override void Init()
    {
        
    }

    private void Open(Action action)
    {
        Open();
        _canvasGroup.DOFade(1f, 0.3f).OnComplete(() =>
        {
            action?.Invoke();
        });
    }

    private void Close(Action action)
    {
        action?.Invoke();
        _canvasGroup.DOFade(0f, 0.3f).OnComplete(() =>
        {
            Close();
        });
    }

    public override void Open()
    {
        _content.SetActive(true);
    }

    public override void Close()
    {
        _content.SetActive(false);
    }
}