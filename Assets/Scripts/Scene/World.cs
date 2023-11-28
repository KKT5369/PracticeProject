using Cinemachine;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : SimulationBehaviour
{
    public CinemachineVirtualCamera camera;
    private NetworkObject _networkObject;
    private NetworkRunner _runner;
    private StartGameArgs _startGameArgs;
    private void Awake()
    {
        _runner = NetworkManager.Instance.Runner;
        Init();
    }

    async void Init()
    {
        switch (NetworkManager.Instance.gameMode)
        {
            case GameMode.Host:
                _startGameArgs = new StartGameArgs()
                {
                    GameMode = GameMode.Host,
                    SessionName = $"test_{Random.Range(1, 50)}",
                    PlayerCount = 5,
                    IsOpen = true,
                    Scene = SceneManager.GetActiveScene().buildIndex,
                    SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
                };
                await _runner.StartGame(_startGameArgs);
                break;
            case GameMode.Client:
                _startGameArgs = new StartGameArgs()
                {
                    GameMode = GameMode.Client,
                    Scene = SceneManager.GetActiveScene().buildIndex,
                    SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
                };
                await _runner.StartGame(_startGameArgs);
                break;
        }
    }
}
