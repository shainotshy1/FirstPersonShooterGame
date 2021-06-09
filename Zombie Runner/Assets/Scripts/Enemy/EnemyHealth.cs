using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;
    public bool GetIsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= Mathf.Abs(damage);
        if (hitPoints <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        if (isDead) { return; }
        isDead = true;
        GetComponent<Animator>().SetTrigger("Killed");
    }
}
