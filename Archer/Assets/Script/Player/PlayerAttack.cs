using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackSpeed;
    public GameObject attackObject;
    public VirtualJoystick playerJoystick;
    public Transform projectilePoint;

    private Animator _playerAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (false == playerJoystick.ActiveJoyStick())
        {
            _playerAnimator.SetBool("Attack", true);
        }
    }

    public void Attack()
    {
        GameObject newProjectile = null;
        newProjectile = Instantiate(attackObject,projectilePoint.position, projectilePoint.rotation);
    }

    public void ResetAttack()
    {
        _playerAnimator.SetBool("Attack", false);
    }
}
