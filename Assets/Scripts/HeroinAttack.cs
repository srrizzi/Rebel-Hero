using System;
using UnityEngine;

public class HeroinAttack : MonoBehaviour
{
  [SerializeField]
  private Transform attackPointRight;

  [SerializeField]
  private Transform attackPointLeft;

  [SerializeField]
  private float attackRange;

  [SerializeField]
  private LayerMask layerAttack;

  [SerializeField]
  private Heroin heroin;

  [SerializeField]
  private AnimationHeroin animationHeroin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      Attack();
    }
  }

  private void Attack()
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

    Collider2D enemyCollider = Physics2D.OverlapCircle(attackPoint.position, attackRange, layerAttack);
    if (enemyCollider != null)
    {
      Enemy enemy = enemyCollider.GetComponent<Enemy>();
      if (enemy != null)
      {
        enemy.TakeDamage();
      }
    }
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    if (attackPointRight != null)
    {
      Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
    }
    if (attackPointLeft != null)
    {
      Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
    }

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
