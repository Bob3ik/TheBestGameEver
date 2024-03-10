using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] private float _jumpForce;
    [SerializeField, Range(1f, 20f)] private float _speed;

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
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -_jumpForce;
        }    
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
