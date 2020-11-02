using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour {
    public Rigidbody rigidbody;
    public float moveSpeed = 35f;
    public float sprintSpeedMultiplier = 1.6f;
    public float jumpForce = 35f;
    public Transform groundCheckTransform;
    public LayerMask groundCheckLayerMask;
    private Vector3 _inputVector;
    private bool _isGrounded = true;

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Terrain"))
        {
            _isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update() {
        _inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift) && _isGrounded)
            _inputVector.z *= sprintSpeedMultiplier;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rigidbody.AddForce(jumpForce * 10 * transform.up, ForceMode.Acceleration);
        }
    }

    void FixedUpdate() {
        Vector3 movement = moveSpeed * 10f * _inputVector.z * Time.fixedDeltaTime * transform.forward + 
                            moveSpeed * 10f * _inputVector.x * Time.fixedDeltaTime * transform.right;

        rigidbody.MovePosition(transform.position + movement * Time.fixedDeltaTime);    
    }
}