using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public GameObject HitParticle;
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy" || other.tag == "Boss")
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
    }

    

    //IEnumerator DestroyEnemy(GameObject enemy, float delay)
    //{
    //    KillCounter.Instance.AddKill(); // This is for the counter
    //    yield return new WaitForSeconds(delay);
    //    Destroy(enemy);
    //}
}