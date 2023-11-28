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
    private Animator _animator;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
    
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public override void FixedUpdateNetwork()
    {
        if (GetInput<NetworkInputData>(out var input))
        {
            // if (Input.GetMouseButtonDown(0))
            // {
            //     _navMeshAgent.SetDestination(input.moveTargerPos);
            // }

            //Vector3 worldMovement = transform.TransformDirection(input.inputVec3);
            Vector3 inputVec3 = input.inputVec3;
            _navMeshAgent.Move(inputVec3 * _navMeshAgent.speed * Time.deltaTime );
            
            if (inputVec3.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(inputVec3.x, inputVec3.z) * Mathf.Rad2Deg;
                float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, 10f);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }

            
            if (inputVec3 != Vector3.zero)
            {
                _animator.SetBool("IsRun",true);
            }
            else
            {
                _animator.SetBool("IsRun",false);
            }
        }
    }
    
}
