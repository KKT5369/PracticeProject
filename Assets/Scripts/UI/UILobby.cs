using System;
using Fusion;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UILobby : UIbase<UILobby>
{
    public TMP_Text roomCount;
    public TMP_Text serverRemoteStatus;

    [SerializeField] private Button btnCreateRoom;
    [SerializeField] private Button btnJoinRoom;
    [SerializeField] private Button btnOption;
    [SerializeField] private Button btnExit;

    private NetworkRunner _runner;

    private new void Awake()
    {
        base.Awake();
        _runner = NetworkManager.Instance.Runner;
        SetAddListener();
    }

    void SetAddListener()
    {
        btnCreateRoom.onClick.AddListener(CreateRoom);
        btnJoinRoom.onClick.AddListener((() =>
        {
            Debug.Log("방입장 clicked");

            if (NetworkManager.Instance.sessionList.Count == 0 || !_runner.LobbyInfo.IsValid)
            {
                print("입장불가");
                return;
            }
            
            var startGameArgs = new StartGameArgs()
            {
                GameMode = GameMode.Client,
                Scene = SceneManager.GetActiveScene().buildIndex,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
            };
            NetworkManager.Instance.testAction = (v) => { roomCount.text = v; };
            _runner.StartGame(startGameArgs);
        }));
        btnExit.onClick.AddListener((() => Application.Quit()));
        btnOption.onClick.AddListener((() =>
        {
            
        }));
    }
    
    void CreateRoom()
    {
        if (!_runner.LobbyInfo.IsValid)
        {
            return;
        }
        
        var startGameArgs = new StartGameArgs()
        {
            GameMode = GameMode.Host,
            SessionName = $"test_{Random.Range(1,50)}",
            PlayerCount = 2,
            IsOpen = true,
            Scene = SceneManager.GetActiveScene().buildIndex,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
        };
        _runner.StartGame(startGameArgs);
    }
}
