using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public Joystick joystick;

    public float forwardSpeed = 15f;
    public float horizontalSpeed = 4f;
    public float verticalSpeed = 4f;
    public float smoothness = 5f;
    public float rotationSmoothness = 5f;
    public float maxHorizontalRotation = 0.1f;
    public float maxVerticalRotation = 0.06f;

    private Rigidbody _plane;

    private float _horizontalInput;
    private float _verticalInput;

    private float _forwardSpeedMultiplier = 100f;
    private float _speedMultiplier = 1000f;


    void Start()
    {
        _plane = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.touches.Length != 0)
        {
            _horizontalInput = joystick.Horizontal;
            _verticalInput = joystick.Vertical;
        }
        else
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");
        }

        HandlePlaneRotation();
    }

    private void FixedUpdate()
    {
        HandlePlaneMovement();
    }

    private void HandlePlaneMovement()
    {
        _plane.velocity = new Vector3(_plane.velocity.x, _plane.velocity.y, forwardSpeed * _forwardSpeedMultiplier * Time.deltaTime);

        float xVelocity = _horizontalInput * _speedMultiplier * horizontalSpeed * Time.deltaTime;
        float yVelocity = -_verticalInput * _speedMultiplier * verticalSpeed * Time.deltaTime;

        _plane.velocity = Vector3.Lerp(_plane.velocity, new Vector3(xVelocity, yVelocity, _plane.velocity.z), Time.deltaTime * smoothness);
    }

    private void HandlePlaneRotation()
    {
        float horizontalRotation = _horizontalInput * maxHorizontalRotation;
        float verticalRotation = _verticalInput * maxVerticalRotation;

        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(verticalRotation, transform.rotation.y, horizontalRotation, transform.rotation.w), Time.deltaTime * rotationSmoothness);
    }
}
