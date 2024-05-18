using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float mouseSensitivity = 1.0f;
    public float moveSpeed = 5f;


    public Transform horizontalRotator;
    public Transform verticalRotator;
    
    private Rigidbody m_rigidbody;
    private Animator m_animator;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // ------ Code for camera rotation -----
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        horizontalRotator.Rotate(Vector3.up, mouseX);
        verticalRotator.Rotate(Vector3.right, -mouseY);

        // ------ Code for shooting ------
        if (Input.GetMouseButtonDown(0))
        {
            m_animator.SetTrigger("Fire");
        }
    }

    private void FixedUpdate()
    {
        // ----- Code for movement -----
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) movement += horizontalRotator.forward;
        if (Input.GetKey(KeyCode.S)) movement -= horizontalRotator.forward;
        if (Input.GetKey(KeyCode.A)) movement -= horizontalRotator.right;
        if (Input.GetKey(KeyCode.D)) movement += horizontalRotator.right;
        movement = movement.normalized * moveSpeed * Time.fixedDeltaTime;
        m_rigidbody.MovePosition(m_rigidbody.position + movement);
    }
}
