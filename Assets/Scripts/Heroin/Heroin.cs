using UnityEngine;

public class Heroin : MonoBehaviour
{
  #region Variables
  public Rigidbody2D rigidbody2D;
  public SpriteRenderer spriteRenderer;
  public float radiusDetected;
  public MoveDiretion moveDiretion;

  DialogueSystem dialogueSystem;

  [SerializeField] private Transform npc;

  [SerializeField] public Animator anim;

  [SerializeField] private Transform detectedGround;
  [SerializeField] private float groundDist;
  [SerializeField] private LayerMask layerGround;

  [SerializeField]
  private HeartSystem heartSystem;

  private bool isGroundCheck;

  [SerializeField] private float moveSpeed;
  [SerializeField] private float jumpForce;
  [SerializeField] private DoubleJump doubleJump;

  private float inputDirection;
  private bool isDirectingRight = true;
  private Rigidbody2D rigidbody2d; 

  public float kBForce;
  public float kBCount;
  public float kBTime;

  public bool isKnockRight;
  private bool canDoubleJump = false;
  #endregion

  private void Awake()
  {
    dialogueSystem = Object.FindFirstObjectByType<DialogueSystem>();
  }

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

    if (Mathf.Abs(transform.position.x - npc.position.x) < 2.0f)
    {
      if (Input.GetKeyDown(KeyCode.E))
      {
        dialogueSystem.Next();
      }
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

  public void Jump()
  {
    bool powerDoubleJump = doubleJump.isDoubleJump; 

    if (isGroundCheck)
    {
      ApplyForceJump();
      if (powerDoubleJump)
      {
        canDoubleJump = true;  
      }
    }
    else if (canDoubleJump)
    {
      ApplyForceJump();
      canDoubleJump = false; 
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
