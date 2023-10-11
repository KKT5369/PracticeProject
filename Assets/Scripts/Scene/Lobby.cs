using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    private NetworkRunner _runner;
    
    void Start()
    {
        _runner = NetworkManager.Instance.Runner;
        JoinLobby();
    }

    async void JoinLobby()
    {
        var result = _runner.JoinSessionLobby(SessionLobby.Custom,lobbyID:"TestLobby");
        await UniTask.WaitUntil(() => result.IsCompleted);
        UIManager.Instance.OpenUI<UILobby>();
    }
    
}
