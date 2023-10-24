using Fusion;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    [SerializeField] private NetworkMode networkMode;
    private NetworkRunner _runner;
    
    
    void Start()
    {
        Init();
    }

    void Init()
    {
        _runner = NetworkManager.Instance.Runner;
        UIManager.Instance.OpenUI<UILobby>();
        NetworkManager.Instance.NetworkMode = networkMode;
        NetworkManager.Instance.Connect();
    }
}
