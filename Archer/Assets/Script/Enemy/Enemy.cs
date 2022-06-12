using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Collider _collider;
    private NavMeshAgent _navMeshAgent;
    private GameObject _target;
    //private float _moveSpeed;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = GameManager.Instance.playerObject;
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.destination = _target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("¸Â¾Ò´ç");
        }
    }
}
