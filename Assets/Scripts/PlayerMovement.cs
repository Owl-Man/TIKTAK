using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpForce = 300f;
    private bool _isGrounded;
    private Rigidbody _rb;

    private void Start() => _rb = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.AddForce(movement * Speed);
    }

    private void JumpLogic()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
}