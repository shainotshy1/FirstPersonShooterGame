using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }
    public int GetCurrentAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);

        return ammoSlot.ammoAmount;
    }
    public void ReduceAmmoAmount(AmmoType ammoType,int decrease)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);

        ammoSlot.ammoAmount -= Mathf.Abs(decrease);
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
