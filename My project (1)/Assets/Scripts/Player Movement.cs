using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
public float turnSpeed = 20f;
    public float moveSpeed = 1f;
    public float jumpForce = 3f;
    public bool IsOnGround = true;
    Vector3 m_Movement;
    Rigidbody m_Rigidbody;
    Quaternion m_Rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            m_Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * moveSpeed * Time.deltaTime);
        m_Rigidbody.MoveRotation (m_Rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }

    public bool IsPlayerOnGround()
    {
        return IsOnGround;
    }

}
