using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 3f;  // Distance within which the enemy can attack
    public float attackCooldown = 2f;  // Time between attacks
    public int damage = 10;  // Damage dealt by the enemy
    private float lastAttackTime;
    private Transform player;  // Reference to the player
    private Animator anim;  // Animator to trigger attack animation
    private Collider attackCollider;  // Reference to the attack collider
    private bool isAttacking = false;  // To track if the enemy is in attacking state

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        attackCollider = GetComponent<Collider>();  // Make sure this is a trigger collider
        if (attackCollider != null)
        {
            attackCollider.enabled = false;  // Disable the collider initially
        }
    }

    void Update()
    {
        // Only attack if the player is within range and cooldown is over
        if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (anim != null)
        {
            anim.SetTrigger("Attack");  // Trigger the attack animation
            lastAttackTime = Time.time;  // Reset cooldown
        }
        if (attackCollider != null)
        {
            attackCollider.enabled = true;  // Enable the collider during attack
            StartCoroutine(DisableColliderAfterDelay());  // Disable collider after a short delay
        }
        isAttacking = true;  // Mark as attacking
    }

    private IEnumerator DisableColliderAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);  // Delay before disabling the collider
        attackCollider.enabled = false;  // Disable collider after delay
        isAttacking = false;  // Reset attacking state
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAttacking && other.CompareTag("Player"))  // Check if the player is hit by the attack
        {
            Debug.Log("Enemy attack hit the player!");
            HealthManager hm = other.GetComponent<HealthManager>();  // Get player's health manager
            if (hm != null)
            {
                hm.TakeDamage(damage);  // Deal damage to the player
            }
        }
    }
}