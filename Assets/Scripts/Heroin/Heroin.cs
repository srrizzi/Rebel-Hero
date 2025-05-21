using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Heroin : MonoBehaviour
{
  #region Variables
  public Rigidbody2D rigidbody2D;
  public SpriteRenderer spriteRenderer;
  public float radiusDetected;
  private bool jumping;
  public MoveDiretion moveDiretion;

  [SerializeField] private Transform cameraTarget;
  [SerializeField] private float cameraSpeed;
  [SerializeField] public Animator anim;

  [SerializeField] private Transform detectedGround;
  [SerializeField] private float groundDist;
  [SerializeField] private LayerMask layerGround;

  private bool canJump;
  private bool isGroundCheck;

  [SerializeField] private float moveSpeed;
  [SerializeField] private float jumpForce;

  private float inputDirection;
  private bool isDirectingRight = true;
  private Rigidbody2D rigidbody2d; 

  public float kBForce;
  public float kBCount;
  public float kBTime;

  public bool isKnockRight;
  #endregion

  private void Start()
  {
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    GetInputMove();
    DirectionCheck();
    ModeAnim();
    JumpAnim();
  }

  private void FixedUpdate()
  {
    KnockLogic();
    CheckArea();
  }

  void KnockLogic()
  {
    if(kBCount < 0)
    {
      MoveLogic();
    }
    else
    {
      if(isKnockRight)
      {
        rigidbody2d.linearVelocity = new Vector2(-kBForce, kBForce);
      }
      if(!isKnockRight)
      {
        rigidbody2d.linearVelocity = new Vector2(kBForce, kBForce);
      }
    }
    kBCount -= Time.deltaTime;
  }
  void CheckArea()
  {
    isGroundCheck = Physics2D.OverlapCircle(detectedGround.position, groundDist, layerGround);
  }

  void GetInputMove()
  {
    inputDirection = Input.GetAxisRaw("Horizontal");

    if (Input.GetButtonDown("Jump")) Jump();
    
  }


  void DirectionCheck()
  { 
    if(isDirectingRight && inputDirection < 0)
    {
      Flip();
    }
    else if (!isDirectingRight && inputDirection > 0)
    {
      Flip();
    }
  }

  void Flip()
  {
    isDirectingRight = !isDirectingRight;
    transform.Rotate(0f, 180f, 0f);
  }

  void MoveLogic()
  {
    rigidbody2d.linearVelocity = new Vector2(inputDirection * moveSpeed, rigidbody2d.linearVelocityY);
  }

  void ModeAnim()
  {
    anim.SetFloat("HorizontalAnim", rigidbody2D.linearVelocityX);
  }

  private void Jump()
  {
    Collider2D collider = Physics2D.OverlapCircle(detectedGround.position, radiusDetected, layerGround);
    if (collider != null)
    {
      isGroundCheck = true;
      jumping = false;
    }
    else
    {
      isGroundCheck = false;
    }

    if (isGroundCheck)
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

  void JumpAnim()
  {
    anim.SetFloat("VerticalAnim", rigidbody2D.linearVelocityY);
    anim.SetBool("groundCheck", isGroundCheck);

  }

  public void ApplyForceJump()
  {
    Vector2 force = new Vector2(0, jumpForce);
    rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
  }

  private void OnDrawGizmos()
  {
    Gizmos.DrawWireSphere(detectedGround.position, groundDist);
  }

}
