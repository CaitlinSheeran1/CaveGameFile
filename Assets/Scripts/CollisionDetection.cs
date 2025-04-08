using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public GameObject HitParticle;
    private Dictionary<GameObject, int> enemyHealth = new Dictionary<GameObject, int>();
    public int maxHealth = 3; 
    public int bossHealth = 10; 

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Enemy") || other.CompareTag("Boss")) && wc.IsAttacking)
        {
            if (!enemyHealth.ContainsKey(other.gameObject))
            {
                int healthToAssign = other.CompareTag("Boss") ? bossHealth : maxHealth;
                enemyHealth[other.gameObject] = healthToAssign;
            }

            enemyHealth[other.gameObject]--;

            Animator enemyAnim = other.GetComponent<Animator>();

            if (enemyAnim != null)
            {
                if (enemyHealth[other.gameObject] <= 0)
                {
                    enemyAnim.SetTrigger("Die");
                    StartCoroutine(DestroyEnemy(other.gameObject, 0.2f));
                }
                else
                {
                    enemyAnim.SetTrigger("Hit");
                    StartCoroutine(ResetToWalk(enemyAnim));
                }
            }
        }
    }

    IEnumerator ResetToWalk(Animator anim)
    {
        yield return new WaitForSeconds(0.3f);
        anim.ResetTrigger("Hit");
        anim.SetBool("isWalking", true);
    }

    IEnumerator DestroyEnemy(GameObject enemy, float delay)
    {
        KillCounter.Instance.AddKill(); // This is for the counter
        yield return new WaitForSeconds(delay);
        Destroy(enemy);
    }
}