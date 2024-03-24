using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] private float _jumpForce;
    [SerializeField, Range(1f, 20f)] private float _speed;

    [SerializeField] private Animator _animator;

    private CharacterController _characterController;

    private Vector3 _moveVector;

    private float _gravity = 9.8f;
    private float _fallVelocity = 1f;

    private void Start()
    {
        _characterController ??= GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovementUpdate();
    }

    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        int runDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 4;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDirection = 3;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -_jumpForce;
        }

        _animator.SetInteger("run direction", runDirection);
    }

    private void FixedUpdate()
    {
        _characterController.Move(_moveVector * _speed * Time.fixedDeltaTime);

        _fallVelocity += _gravity * Time.deltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0f;
        }
    }
}
