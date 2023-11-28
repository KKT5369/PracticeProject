using System.Collections;
using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Lobby : NetworkSceneManagerBase
{
    [SerializeField] private NetworkMode networkMode;
    [SerializeField] private SceneRef sceneRef;
    private NetworkRunner _runner;
    
    
    void Start()
    {
        Init();
    }

    async void Init()
    {
        NetworkManager.Instance.playerPre = await Addressables.LoadAssetAsync<GameObject>("Player");
        _runner = NetworkManager.Instance.Runner;
        NetworkManager.Instance.NetworkMode = networkMode;
        NetworkManager.Instance.Connect();
        UIManager.Instance.OpenUI<UILobby>();
        InputManager.Instance.Init();
    }

    protected override IEnumerator SwitchScene(SceneRef prevScene, SceneRef newScene, FinishedLoadingDelegate finished)
    {
        throw new System.NotImplementedException();
    }
}
