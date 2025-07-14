using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject explosionPrefab;
    public int defaultHealthPoint;
    public int healthPoint;
    public System.Action onDead;
    public System.Action onHealthChanged;
  

    private void Start()
    {
        healthPoint = defaultHealthPoint;
        onHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        //if (healthPoint <= 0) return;

        //healthPoint -= damage;
        //if (healthPoint <= 0) Die();
        {
            Debug.Log("Before: HP = " + healthPoint);

            if (healthPoint <= 0) return;

            healthPoint -= damage;
            Debug.Log("After damage: HP = " + healthPoint);
            onHealthChanged?.Invoke();

            if (healthPoint <= 0)
            {
                Debug.Log("HP <= 0 → Die()");
                Die();
            }
        }
    }
    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.transform.localScale = new Vector3(0.5f, 0.5f, 1f); 
            Destroy(explosion, 1f);
            Destroy(gameObject);
            Destroy(gameObject);
        }
        onDead?.Invoke();
    }
}