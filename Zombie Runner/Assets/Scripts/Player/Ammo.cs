using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 50;
    public int AmmoAmount { get { return ammoAmount; } }
    public void ReduceAmmoAmount(int decrease)
    {
        ammoAmount -= Mathf.Abs(decrease);
    }
}
