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

    [SerializeField] private Button btnStartGame;

    private NetworkObject _networkObject;
    
    private NetworkRunner _runner;
    void Start()
    {
        // _runner = NetworkManager.Instance.Runner;
        // _runner.JoinSessionLobby(SessionLobby.Custom,lobbyID:"test");
        // var gameArg = new StartGameArgs() { GameMode = GameMode.Host, SessionName = "로비룸"};
        // _runner.StartGame(gameArg);
        //NetworkManager.Instance.testAction = Test;
        
        btnStartGame.onClick.AddListener((() =>
        {
            
        }));
    }

    public void Test()
    {
        txtServerStatus.text = _runner.IsServer ? "호스트" : "게스트";
        txtPlayerCount.text = Convert.ToString(_runner.SessionInfo.PlayerCount);
        txtRoomCount.text = _runner.SessionInfo.Name;

    }
}
