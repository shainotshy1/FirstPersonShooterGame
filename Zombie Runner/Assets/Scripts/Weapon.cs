using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem shootVFX;
    [SerializeField] GameObject hitImpactVFX;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRayCast();
    }

    private void PlayHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitImpactVFX, hit.point,Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

    private void PlayMuzzleFlash()
    {
        shootVFX.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;

        bool success = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

        if (success)
        {
            PlayHitImpact(hit);
            Debug.Log(hit.transform.name);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) { return; }

            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
