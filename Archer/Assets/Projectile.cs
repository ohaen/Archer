using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody _projectileRigidBody;
    void Start()
    {
        _projectileRigidBody = GetComponent<Rigidbody>();
        _projectileRigidBody.velocity = transform.forward * 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
