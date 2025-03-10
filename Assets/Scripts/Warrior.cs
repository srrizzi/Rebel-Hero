using Unity.VisualScripting;
using UnityEngine;

public class Warrior : MonoBehaviour
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
    #endregion

    private void Start()
    {

    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 speed = this.rigidbody2D.linearVelocity;

        speed.x = horizontal * this.moveSpeed;
        this.rigidbody2D.linearVelocity = speed;

        if (speed.x > 0)
        {
            this.spriteRenderer.flipX = false;
        }
        else if (speed.x < 0)
        {
            this.spriteRenderer.flipX = true;
        }
    }
    private void Jump()
    {
        Collider2D collider = Physics2D.OverlapCircle(this.detectedGround.position, this.radiusDetected, this.layerGround);
        if (collider != null)
        {
            this.onTheGround = true;
            this.jumping = false;
        }
        else
        {
            this.onTheGround = false;
        }

        if (this.onTheGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!this.jumping)
                {
                    ApplyForceJump();
                }
            }
        }
    }

    public void ApplyForceJump()
    {
        Vector2 force = new Vector2(0, this.jumpForce);
        this.rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    public bool OnTheGround
    {
        get { return this.onTheGround; }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.detectedGround.position, this.radiusDetected);
    }
}
