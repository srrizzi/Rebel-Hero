using Unity.VisualScripting;
using UnityEngine;

public class Heroin : MonoBehaviour
{
    #region Variables
    public Rigidbody2D rigidbody2D;
    public float moveSpeed = 5;

    public SpriteRenderer spriteRenderer;
    public float jumpForce = 5;

    public Transform detectedGround;
    public float radiusDetected;
    public LayerMask layerGround;

    private bool jumping;
    private bool onTheGround;

    public MoveDiretion moveDiretion;
    #endregion

    private void Start()
    {
        moveDiretion = MoveDiretion.Right;
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 speed = rigidbody2D.linearVelocity;

        speed.x = horizontal * moveSpeed;
        rigidbody2D.linearVelocity = speed;
            
        if (speed.x > 0)
        {
            moveDiretion = MoveDiretion.Right;
            spriteRenderer.flipX = false;
        }
        else if (speed.x < 0)
        {
            moveDiretion = MoveDiretion.Left;
            spriteRenderer.flipX = true;
        }
    }
    private void Jump()
    {
        Collider2D collider = Physics2D.OverlapCircle(detectedGround.position, radiusDetected, layerGround);
        if (collider != null)
        {
            onTheGround = true;
            jumping = false;
        }
        else
        {
            onTheGround = false;
        }

        if (onTheGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!jumping)
                {
                    ApplyForceJump();
                }
            }
        }
    }

    public void ApplyForceJump()
    {
        Vector2 force = new Vector2(0, jumpForce);
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public bool OnTheGround
    {
        get { return onTheGround; }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(detectedGround.position, radiusDetected);
    }
}
