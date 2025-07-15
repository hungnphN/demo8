using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyHealth health;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            var agent = GetComponent<FlyPathArgent>();
            if (agent != null && !agent.isBoss)
            {
                health.TakeDamage(1000);
            }
           
        }
    }
}
