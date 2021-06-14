using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeatlh : MonoBehaviour
{
    [SerializeField] float playerHealth = 50f;
    [SerializeField] float bloodDisplayTime = 2f;
    [SerializeField] Canvas bloodDisplayCanvas;
    private void Start()
    {
        bloodDisplayCanvas.enabled = false;
    }
    public void DecreaseHealth(float damage)
    {
        StartCoroutine(DecreaseHealthSequence(damage));
    }
    IEnumerator DecreaseHealthSequence(float damage)
    {
        bloodDisplayCanvas.enabled = true;
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
        yield return new WaitForSeconds(bloodDisplayTime);
        bloodDisplayCanvas.enabled = false;
    }
}
