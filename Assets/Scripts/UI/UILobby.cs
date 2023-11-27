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
        btnJoinRoom.onClick.AddListener((async () =>
        {
            Debug.Log("방입장 clicked");

            if (NetworkManager.Instance.sessionList.Count == 0 || !_runner.LobbyInfo.IsValid)
            {
                print("입장불가");
                return;
            }
            NetworkManager.Instance.gameMode = GameMode.Client;
            SceneManager.LoadScene("GameScene");

        }));
        btnExit.onClick.AddListener((() => Application.Quit()));
        btnOption.onClick.AddListener((() =>
        {
            
        }));
    }

    async void CreateRoom()
    {
        if (!_runner.LobbyInfo.IsValid)
        {
            return;
        }

        NetworkManager.Instance.gameMode = GameMode.Host;
        SceneManager.LoadScene("GameScene");
    }

    public void SetRemoteStatus(string status,string count)
    {
        serverRemoteStatus.text = status;
        roomCount.text = count;
    }
}
