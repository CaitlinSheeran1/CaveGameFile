using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{
    private bool canDealDamage = false;
    private int damageAmount = 0;

    public void SetDamageEnabled(bool enabled, int damage)
    {
        canDealDamage = enabled;
        damageAmount = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canDealDamage)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
            {
                EnemyScript enemy = other.GetComponent<EnemyScript>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damageAmount);
                    Debug.Log("Hit enemy: " + other.name + " for " + damageAmount + " damage");
                }
            }
        }
    }
}
