using System;
using UnityEngine;

public class HeroinAttack : MonoBehaviour
{
  [SerializeField] private Transform attackPointRight;
  [SerializeField] private Transform attackPointLeft;
  [SerializeField] private float attackRange;
  [SerializeField] private LayerMask layerAttack;
  [SerializeField] private Heroin heroin;
  [SerializeField] private AttackDestroy powerUp;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      heroin.anim.SetTrigger("isAttack");
      Attack();
    }
  }

  public void Attack()
  {
    Transform attackPoint;
    if (heroin.moveDiretion == MoveDiretion.Right)
    {
      attackPoint = attackPointRight;

    }
    else
    {
      attackPoint = attackPointLeft;
    }

    bool power = powerUp.isPowerUp;

    Collider2D enemyCollider = Physics2D.OverlapCircle(attackPoint.position, attackRange, layerAttack);
    if (enemyCollider != null)
    {
      Enemy enemy = enemyCollider.GetComponent<Enemy>();

      if (enemyCollider.CompareTag("Stone"))
      {
        if (power)
        {
          enemy = enemyCollider.GetComponent<Enemy>();
          if (enemy != null)
          {
            enemy.TakeDamage();
          }
        }
      }
      else
      {
        if (enemy != null)
        {
          enemy.TakeDamage();
        }
      }
    }
  }

  private void OnDrawGizmos()
  {
    Transform attackPoint;
    if (heroin.moveDiretion == MoveDiretion.Right)
    {
      attackPoint = attackPointRight;
    }
    else
    {
      attackPoint = attackPointLeft;
    }
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  }
}
