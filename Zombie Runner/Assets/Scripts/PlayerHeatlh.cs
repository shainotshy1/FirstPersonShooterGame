using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeatlh : MonoBehaviour
{
    [SerializeField] float playerHealth = 50f;
    
    public void DecreaseHealth(float damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            Debug.Log("Player is dead");
        }
    }
}
