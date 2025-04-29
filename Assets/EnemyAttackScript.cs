using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttackScript : MonoBehaviour
{
    public int enemyAttackDamage = 20;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                other.GetComponent<HealthManager>().TakeDamage(enemyAttackDamage);
            }
        }
        
    }
}
