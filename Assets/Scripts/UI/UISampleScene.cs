using Cysharp.Threading.Tasks;
using Fusion;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UISampleScene : MonoBehaviour
{
    [SerializeField] private NetworkMode networkMode;
    [SerializeField] private Button btnStartGame;
    [SerializeField] private Button btnJoinGame;
    
    private NetworkRunner _runner;

    private void Awake()
    {
        Init();
    }

    async void Init()
    {
        NetworkManager.Instance.playerPre = await Addressables.LoadAssetAsync<GameObject>("Player");
        _runner = NetworkManager.Instance.Runner;
        NetworkManager.Instance.NetworkMode = networkMode;
        NetworkManager.Instance.Connect();
        SetAddListener();
        
    }

    void SetAddListener()
    {
        btnStartGame.onClick.AddListener((async () =>
        {
            if (!_runner.LobbyInfo.IsValid)
            {
                return;
            }
        
            var startGameArgs = new StartGameArgs()
            {
                GameMode = GameMode.Host,
                SessionName = $"test_{Random.Range(1, 50)}",
                PlayerCount = 2,
                IsOpen = true,
                Scene = SceneManager.GetActiveScene().buildIndex,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            };
            await _runner.StartGame(startGameArgs);
        }));
        
        btnJoinGame.onClick.AddListener((async () =>
        {
            if (NetworkManager.Instance.sessionList.Count == 0 || !_runner.LobbyInfo.IsValid)
            {
                print("입장불가");
                return;
            }
            
            var startGameArgs = new StartGameArgs()
            {
                GameMode = GameMode.Client,
                Scene = SceneManager.GetActiveScene().buildIndex,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            };
            await _runner.StartGame(startGameArgs);
        }));
    }

    public void CreateAvatar()
    {
        var go = NetworkManager.Instance.playerPre;
        var playerGo = _runner.Spawn(go, Vector3.up, quaternion.identity);
    }
    
}
