using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem shootVFX;
    [SerializeField] GameObject hitImpactVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float reloadDelay = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Update()
    {
        DisplayAmmo();

        if (Input.GetMouseButtonDown(0) && canShoot && ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            StartCoroutine(Shoot());
        }
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
    private IEnumerator Shoot()
    {
        canShoot = false;
        ammoSlot.ReduceAmmoAmount(ammoType,1);
        PlayMuzzleFlash();
        ProcessRayCast();
        yield return new WaitForSeconds(reloadDelay);
        canShoot = true;
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
