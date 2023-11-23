using Cinemachine;
using Cysharp.Threading.Tasks;
using Fusion;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class World : SimulationBehaviour,ISpawned
{
    public CinemachineVirtualCamera camera;
    private NetworkObject _networkObject;
    private NetworkRunner _runner;
    private async void Awake()
    {
        _runner = NetworkManager.Instance.Runner;

        var go = NetworkManager.Instance.playerPre;
        var player = _runner.Spawn(go, Vector3.up, quaternion.identity);
        
        camera.Follow = camera.LookAt = player.transform;
    }


    public void Spawned()
    {
        var go = NetworkManager.Instance.playerPre;
        _runner.Spawn(go, Vector3.up, quaternion.identity);
    }
}
