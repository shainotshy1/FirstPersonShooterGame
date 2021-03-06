using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHeatlh target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHeatlh>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        target.DecreaseHealth(damage);
    }
}
