using Cinemachine;
using Cysharp.Threading.Tasks;
using Fusion;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class World : SimulationBehaviour
{
    public CinemachineVirtualCamera camera;
    private NetworkObject _networkObject;
    private NetworkRunner _runner;
    public GameObject go;
    private void Awake()
    {
        _runner = NetworkManager.Instance.Runner;
    }

    private async void Start()
    {
        var go = await Addressables.LoadAssetAsync<GameObject>("Player");
        var playerTf = _runner.Spawn(go, Vector3.up, quaternion.identity).transform;
        camera.Follow = playerTf;
        camera.LookAt = playerTf;
    }
    
}
