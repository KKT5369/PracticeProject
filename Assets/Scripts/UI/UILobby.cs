using Fusion;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILobby : UIbase<UILobby>
{
    public TMP_Text roomCount;
    public TMP_Text serverRemoteStatus;

    [SerializeField] private Button btnCreateRoom;
    [SerializeField] private Button btnJoinRoom;
    [SerializeField] private Button btnOption;
    [SerializeField] private Button btnExit;

    private new void Start()
    {
        base.Start();
        NetworkManager.Instance.testAction = (string v) => { roomCount.text = v; };
        SetAddListener();
    }

    void SetAddListener()
    {
        btnCreateRoom.onClick.AddListener((() =>
        {
            Debug.Log("방생성 clicked");
            var startGameArgs = new StartGameArgs()
            {
                GameMode = GameMode.Host,
                SessionName = $"test_{Random.Range(1,50)}",
                PlayerCount = 2,
                IsOpen = true,
                Scene = SceneManager.GetActiveScene().buildIndex,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
            };
            NetworkManager.Instance.Runner.StartGame(startGameArgs);
        }));
        btnJoinRoom.onClick.AddListener((() =>
        {
            Debug.Log("방입장 clicked");
            var startGameArgs = new StartGameArgs()
            {
                GameMode = GameMode.Client,
                Scene = SceneManager.GetActiveScene().buildIndex,
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
            };
            NetworkManager.Instance.testAction = (string v) => { roomCount.text = v; };
            NetworkManager.Instance.Runner.StartGame(startGameArgs);
        }));
    }
}
