using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScarchCollider : MonoBehaviour
{
    private Collider[] _collider = new Collider[15];
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

    }


    void Update()
    {
        int _monsterLayerMask = (1 << LayerMask.NameToLayer("Monster"));
        int _wallLayerMask = (1 << LayerMask.NameToLayer("Wall"));
        Physics.OverlapSphereNonAlloc(transform.position, 10.0f, _collider, _monsterLayerMask);
    }
}