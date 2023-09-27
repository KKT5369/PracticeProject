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
        if (Input.GetMouseButtonUp(0))
        {
            Move();
        }
    }

    void Move()
    {
        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        bool isOverGameObj = EventSystem.current.IsPointerOverGameObject();
        
        if (Physics.Raycast(ray,out hit,Mathf.Infinity) && !isOverGameObj)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Floor"))
            {
                _movePos = hit.point;
                _navMeshAgent.SetDestination(_movePos);
            }
        }
    }
}
