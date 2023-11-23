using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Lobby : MonoBehaviour
{
    [SerializeField] private NetworkMode networkMode;
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
    }
}
