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
    private PlayerAbility _playerAbility;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerAbility = GetComponent<PlayerAbility>();
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
        newProjectile.GetComponent<Projectile>().Init(_playerAbility.GetDamage(), _playerAbility.GetProjectileSpeed());

        //newProjectile.GetComponent<Projectile>().Init(_playerAbility.GetDamage(),3f);
    }

    public void ResetAttack()
    {
        _playerAnimator.SetBool("Attack", false);
    }
}
