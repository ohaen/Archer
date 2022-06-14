using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _damage;

    private Rigidbody _projectileRigidBody;
    void Start()
    {
    }

    public void Init(float damage, float speed)
    {
        _damage = damage;
        _projectileRigidBody = GetComponent<Rigidbody>();
        _projectileRigidBody.velocity = transform.forward * speed;
    }

    public float ProjectileDamage()
    {
        return _damage;
    }

}
