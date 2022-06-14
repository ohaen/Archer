using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    [SerializeField] private float _playerMaxHP;
    [SerializeField] private float _playerCurrentHP;
    [SerializeField] private float _playerDamage;
    [SerializeField] private float _playerMoveSpeed;
    [SerializeField] private float _playerProjectileSpeed;

    public float GetDamage()
    {
        return _playerDamage;
    }

    public float GetProjectileSpeed()
    {
        return _playerProjectileSpeed;
    }

    public void TakeDamage(float damage)
    {
        _playerCurrentHP -= damage;
        if(_playerCurrentHP < 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
