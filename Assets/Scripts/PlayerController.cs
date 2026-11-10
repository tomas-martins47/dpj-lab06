using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    public float groundCheckRadius;
    public float horizontalInput;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float fallLimit = 0f;
    private bool hasFallen;
    private Vector3 spawnPosition;

    private bool isGrounded;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | 
                         RigidbodyConstraints.FreezeRotationX;
        spawnPosition = transform.position;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (gameObject.transform.position.y <= fallLimit && hasFallen == false)
        {
            hasFallen = true;
            UIManager.Instance.LoseLife(1);
            rb.position = spawnPosition;
            rb.linearVelocity = Vector3.zero;
        }
        
        if (isGrounded && transform.position.y > fallLimit)
        {
            hasFallen = false;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,
                                         groundCheckRadius,     
                                         groundLayer);
        Vector3 velocity = rb.linearVelocity;
        float targetVelX = horizontalInput * moveSpeed;
        float newVelX = Mathf.MoveTowards(velocity.x, targetVelX, 50f * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(Mathf.Clamp(newVelX, -maxSpeed, maxSpeed), velocity.y, 0f);
    }

    private void Jump()
    {
        Vector3 jumpVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.linearVelocity = jumpVelocity;
        jumpVelocity = Vector3.up * jumpForce;
        rb.AddForce(jumpVelocity, ForceMode.Impulse);
    }
}
