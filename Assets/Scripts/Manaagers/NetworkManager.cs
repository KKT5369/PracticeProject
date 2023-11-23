using System;
using System.Collections.Generic;
using Data;
using Fusion;
using Fusion.Photon.Realtime;
using Fusion.Sockets;
using UnityEngine;

public class NetworkManager : SingleTon<NetworkManager> , INetworkRunnerCallbacks
{
    private NetworkRunner _runner;

    public NetworkRunner Runner
    {
        get
        {
            if (!_runner)
            {
                _runner = gameObject.AddComponent<NetworkRunner>();
                _runner.ProvideInput = true;
            }
            return _runner;
        }
    }
    
    public NetworkMode NetworkMode { get;  set; }
    
    public List<SessionInfo> sessionList = new();
    public Action testAction;
    public GameObject playerPre;
    public async void Connect()
    {
        var networkVersion = Convert.ToString($"{NetworkMode}_{Const.NETWORKVERSION}");
        PhotonAppSettings.Instance.AppSettings.AppVersion = networkVersion;
        await _runner.JoinSessionLobby(SessionLobby.Custom,lobbyID:"Lobby");
    }

    #region 네트워크 콜백 함수

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        print($"플레이어 입장.. ");
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        print($"플레이어 퇴장.. "); 
    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        Debug.Log("InputMissing");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Debug.Log($"OnShutdown >>> { shutdownReason }");

    }
    
    public void OnConnectedToServer(NetworkRunner runner)
    {
        print($"서버 연결 ");
        print(runner.SessionInfo.Name);
        var ui = UIManager.Instance.GetUI<UILobby>();
        ui.serverRemoteStatus.text = "서버에 연결됨";
    }
    
    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        print($"서버 연결 해제.. ");
        var ui = UIManager.Instance.GetUI<UILobby>();
        ui.serverRemoteStatus.text = "연결 끊김";
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        Debug.Log("OnConnectRequest");
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        Debug.Log("입장 실패");
        Debug.Log(reason.ToString());
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        throw new NotImplementedException();
    }
    
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        // JoinSessionLobby 실행 될때 마다 호출 되는거 확인
        // 다른 방법으로 호출 되는지 체크 필요 리스트 리플레시 기능 
        Debug.Log($"세션 리스트 업데이트");
        this.sessionList = sessionList;
        // var ui = UIManager.Instance.GetUI<UILobby>();
        // ui.roomCount.text = string.Format($"{sessionList.Count}");
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        throw new NotImplementedException();
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        throw new NotImplementedException();
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        throw new NotImplementedException();
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        Debug.Log("씬로드 done");
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        Debug.Log("씬로드 start");
    }
    #endregion
    
}
