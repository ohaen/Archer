using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum eState
{
    Idle,
    Move,
    Attack,
}

public class Enemy : MonoBehaviour
{
    public Collider attackCollider;

    [SerializeField] private float maxHP;
    [SerializeField] private float currentHP;
    [SerializeField] private float damage;
    [SerializeField] private float attackInterver;
    private eState currentState;

    private Collider _collider;
    private NavMeshAgent _navMeshAgent;
    private GameObject _target;
    private Animator _monsterAnimator;
    private Rigidbody _rigidbody;
    //private float _moveSpeed;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = GameManager.Instance.playerObject;
        _monsterAnimator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        currentState = eState.Move;
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakeDamage(other.GetComponent<PlayerAbility>().GetDamage());
            Destroy(other.gameObject);
        }
    }
    IEnumerator Move()
    {
        while(currentState == eState.Move)
        {
            _navMeshAgent.destination = _target.transform.position;
            if (Vector3.Distance(GameManager.Instance.playerObject.transform.position, transform.position) < 1f)
            {
                currentState = eState.Attack;
                StopAllCoroutines();
                StartCoroutine("Attack");
            }
            yield return null;
        }
    }
    IEnumerator Attack()
    {
        _navMeshAgent.destination = transform.position;
        transform.LookAt(GameManager.Instance.playerObject.transform);
        yield return new WaitForSeconds(1.0f);
        _monsterAnimator.Play("Attack");
        yield return null;

    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP < 0)
        {
            Die();
        }

    }

    public void MonsterAttack()
    {
        attackCollider.enabled = true;
    }

    public void MonsterAttackReset()
    {

    }

    private void Die()
    {
        Debug.Log("Á×À½");
    }
}
