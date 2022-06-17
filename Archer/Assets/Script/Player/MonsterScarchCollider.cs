using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScarchCollider : MonoBehaviour
{
    private Collider[] _collider = new Collider[15];
    private int _enemyCount;
    void Start()
    {

    }

    void Update()
    {
        int _monsterLayerMask = (1 << LayerMask.NameToLayer("Monster"));
        int _wallLayerMask = (1 << LayerMask.NameToLayer("Wall"));
        _enemyCount = Physics.OverlapSphereNonAlloc(transform.position, 10.0f, _collider, _monsterLayerMask);

        NearMonster();
    }

    void NearMonster()
    {
        if (_enemyCount == 0)
        {
            return;
        }
        GameObject nearMonster = _collider[0].transform.gameObject;
        for(int i = 1; i < 15; ++i)
        {
            if (_collider[i] == null)
            {
                break;
            }

        }
    }
}