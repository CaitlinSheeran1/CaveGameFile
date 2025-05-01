using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyCollider : MonoBehaviour
{
    public Collider weaponCollider;

    private void Start()
    {
        if (weaponCollider != null)
        {
            weaponCollider.enabled = false;
        }
    }

    public void EnableCollider()
    {
        if (weaponCollider != null)
            weaponCollider.enabled = true;
    }

    public void DisableCollider()
    {
        if (weaponCollider != null)
            weaponCollider.enabled = false;
    }
    public void EnableColliderWithDelay(float delay)
    {
        StartCoroutine(EnableAfterDelay(delay));
    }

    private IEnumerator EnableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        EnableCollider();
    }
}

