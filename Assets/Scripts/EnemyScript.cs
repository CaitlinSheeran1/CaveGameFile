using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemyScript : MonoBehaviour
{
    public int HP = 100;
    public Slider healthBar;
    public Animator animator;
    public AudioClip SkeletonSound;

    private void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        AudioSource ac = GetComponent<AudioSource>();
        if (HP <= 0 )
        {
            animator.SetTrigger("die");
            ac.PlayOneShot(SkeletonSound);
            GetComponent<BoxCollider>().enabled = false;
            KillCounter.Instance.AddKill();
            if (CompareTag("Enemy"))
            {
                StartCoroutine(DestroyAfterDelay(8f));
            }
            else if (CompareTag("Boss"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
        else
        {
            animator.SetTrigger("damage");
            ac.PlayOneShot(SkeletonSound);

        }
    }
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
