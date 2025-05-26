using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;

    public void TakeDamage()
    {
        health --;
        Debug.Log("Health: " + health);
        if (health == 0)
        {
            Destroy(gameObject, 0.1f);
            Debug.Log("Enemy destroyed");
        }
    }
}
