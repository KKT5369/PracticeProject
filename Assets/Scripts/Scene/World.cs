using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class World : NetworkBehaviour
{
    [SerializeField] private TMP_Text txtServerStatus;
    [SerializeField] private TMP_Text txtPlayerCount;
    [SerializeField] private TMP_Text txtRoomCount;

    private NetworkObject _networkObject;
    
    private NetworkRunner _runner;
    void Start()
    {
        var gameArg = new StartGameArgs() { GameMode = GameMode.Server, SessionName = "Test" };
        _runner = NetworkManager.Instance.Runner;
        _runner.StartGame(gameArg);
        NetworkManager.Instance.testAction = Test;
    }

    public void Test()
    {
        txtServerStatus.text = _runner.IsServer ? "호스트" : "게스트";
        txtPlayerCount.text = Convert.ToString(_runner.SessionInfo.PlayerCount);
        
    }
}
