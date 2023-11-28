using System;
using Data;
using Fusion;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : NetworkBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _movePos;
    

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    

    public override void FixedUpdateNetwork()
    {
        if (GetInput<NetworkInputData>(out var input))
        {
            if (Input.GetMouseButtonDown(0))
            {
                _navMeshAgent.SetDestination(input.moveTargerPos);
            }

            Vector3 worldMovement = transform.TransformDirection(input.inputVec3);
            _navMeshAgent.Move(worldMovement * _navMeshAgent.speed * Time.deltaTime );
        }
    }
    
}
