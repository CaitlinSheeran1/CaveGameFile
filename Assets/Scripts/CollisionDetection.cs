using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (wc != null && wc.IsAttacking)
        {
            if (other.tag == "Enemy" || other.tag == "Boss")
            {
                other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
            }
        }
    }
}

    

 