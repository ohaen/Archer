using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private GameObject _target;
    private float _moveSpeed;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = GameManager.Instance.playerObject;
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.destination = _target.transform.position;
    }
}
