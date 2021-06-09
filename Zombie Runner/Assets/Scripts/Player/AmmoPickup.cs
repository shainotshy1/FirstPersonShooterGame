using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHeatlh>() != null)
        {
            Debug.Log($"{other.name} picked up {name}");
            Destroy(gameObject);
        }
    }
}
