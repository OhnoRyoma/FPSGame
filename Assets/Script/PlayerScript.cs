using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody _rigidbody;

    [Header("����")]
    public float _moveSpeed, _jumpForce;

    public float _groundDrag;

    [Header("�n�ʂ̌��m")]
    public float _playerHeight;
    public LayerMask whatIsGround;
    bool _isGrounded;

    public Transform _orientation;

    float _horizontalInput;
    float _verticalInput;

    Vector3 _moveDirection;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        //�n�ʂ̌��m
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 1.0f + 0.2f, whatIsGround);

        MyInput();

        if(_isGrounded)
        {
            _rigidbody.linearDamping = _groundDrag;
        }
        else
        {
            _rigidbody.linearDamping = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;

        _rigidbody.AddForce(_moveDirection.normalized * _moveSpeed * 10f, ForceMode.Force);
    }
}
