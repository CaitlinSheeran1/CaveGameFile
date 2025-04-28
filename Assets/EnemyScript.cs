using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public AudioClip SkeletonSound;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        AudioSource ac = GetComponent<AudioSource>();
        if (HP <= 0 )
        {
            animator.SetTrigger("die");
            ac.PlayOneShot(SkeletonSound);
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");
            ac.PlayOneShot(SkeletonSound);

        }
    }
}
