using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType; //ammotype class 
        public int ammoAmount;
    }
    public int GetCurrentAmmo(AmmoType ammoType) //to know what ammo we are currently talking about
    {
        return GetAmmoSlot(ammoType).ammoAmount; 
    }
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
         GetAmmoSlot(ammoType).ammoAmount--; //get the ammo slot first based up on the ammo type then we reduce the ammo amount
    }
    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
         GetAmmoSlot(ammoType).ammoAmount += ammoAmount; 
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType) //checking which gun has which ammo slot 
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.ammoType == ammoType)//if the ammo type in the slots matches the ammo type we passed in the arguments then=
            {
                return slot; //here we know that yes, this is the particular ammo slot on the player we want
            }
        }
        return null; //if the desired ammo slot is not found return null
    }
}
