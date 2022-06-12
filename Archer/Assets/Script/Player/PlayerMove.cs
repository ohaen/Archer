using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private readonly int Run = Animator.StringToHash("Run");
    [SerializeField]
    public float moveSpeed;

    public VirtualJoystick virtualJoyStick;

    private Animator _playerAnimator;
    private Rigidbody _playerRigidBody;

    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (virtualJoyStick.ActiveJoyStick())
        {
            Move();
        }
        else
        {
            StopMove();
        }

        MoveAnimationController();
    }
    private void Move()
    {
        Vector3 playerDir = new Vector3(virtualJoyStick.StickDirection().x, 0, virtualJoyStick.StickDirection().y);
        _playerRigidBody.velocity = playerDir * moveSpeed;

        transform.LookAt(transform.position + playerDir);
    }

    private void StopMove()
    {
        _playerRigidBody.velocity = Vector3.zero;
    }

    private void MoveAnimationController()
    {
        bool isRun;
        isRun = _playerRigidBody.velocity != Vector3.zero ? true : false;
        _playerAnimator.SetBool(Run, isRun);
        _playerAnimator.SetBool("Attack", !isRun);
    }
}
