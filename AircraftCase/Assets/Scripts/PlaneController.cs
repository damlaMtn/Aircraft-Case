using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public Joystick joystick;

    //public float forwardSpeed = 15f;
    //public float horizontalSpeed = 4f;
    //public float verticalSpeed = 4f;
    //public float smoothness = 5f;
    //public float rotationSmoothness = 5f;
    //public float maxHorizontalRotation = 0.1f;
    //public float maxVerticalRotation = 0.06f;

    //private Rigidbody _plane;

    //private float _horizontalInput;
    //private float _verticalInput;

    //private float _forwardSpeedMultiplier = 100f;
    //private float _speedMultiplier = 1000f;
    public float flySpeed = 50f;
    public float yawAmount = 60f;

    private float _yaw;


    void Start()
    {
        //_plane = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += transform.forward * flySpeed * Time.deltaTime;

        if (Input.GetMouseButton(0) || Input.touches.Length != 0)
        {
            float horizontalInput = joystick.Horizontal;
            float verticalInput = joystick.Vertical;

            _yaw += horizontalInput * yawAmount * Time.deltaTime;
            float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
            float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

            transform.localRotation = Quaternion.Euler(Vector3.up * _yaw + Vector3.right * pitch + Vector3.forward * roll);
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            _yaw += horizontalInput * yawAmount * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(Vector3.up * _yaw);
        }



        //if (Input.GetMouseButton(0) || Input.touches.Length != 0)
        //{
        //    _horizontalInput = joystick.Horizontal;
        //    _verticalInput = joystick.Vertical;
        //}
        //else
        //{
        //    _horizontalInput = Input.GetAxis("Horizontal");
        //    _verticalInput = Input.GetAxis("Vertical");
        //}

        //HandlePlaneRotation();
    }

    //private void FixedUpdate()
    //{
    //    HandlePlaneMovement();
    //}

    //private void HandlePlaneMovement()
    //{
    //    _plane.velocity = new Vector3(_plane.velocity.x, _plane.velocity.y, forwardSpeed * _forwardSpeedMultiplier * Time.deltaTime);

    //    float xVelocity = _horizontalInput * _speedMultiplier * horizontalSpeed * Time.deltaTime;
    //    float yVelocity = -_verticalInput * _speedMultiplier * verticalSpeed * Time.deltaTime;

    //    _plane.velocity = Vector3.Lerp(_plane.velocity, new Vector3(xVelocity, yVelocity, _plane.velocity.z), Time.deltaTime * smoothness);
    //}

    //private void HandlePlaneRotation()
    //{
    //    float horizontalRotation = _horizontalInput * maxHorizontalRotation;
    //    float verticalRotation = _verticalInput * maxVerticalRotation;

    //    transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(verticalRotation, transform.rotation.y, horizontalRotation, transform.rotation.w), Time.deltaTime * rotationSmoothness);
    //}
}
