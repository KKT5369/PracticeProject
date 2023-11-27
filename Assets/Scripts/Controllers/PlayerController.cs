using Fusion;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : NetworkBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _movePos;
    

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!Runner.IsPlayer) 
            return;
        

        if (Input.GetMouseButtonUp(0))
        {
            Move();
        }
    }

    void Move()
    {
        
    }

    public override void FixedUpdateNetwork()
    {
        _movePos = NetworkManager.Instance.data.movePos;
        if (_movePos == null)
        {
            return;
        }
        _navMeshAgent.SetDestination(_movePos);


    }
}
