using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Fusion;
using Fusion.Photon.Realtime;
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
        var networkVersion = Convert.ToString($"{networkMode}_{Data.Const.NETWORKVERSION}");
        PhotonAppSettings.Instance.AppSettings.AppVersion = networkVersion;
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
