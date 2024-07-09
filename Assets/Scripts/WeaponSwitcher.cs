using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    void Start()
    {
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0) //going up
        {
            if(currentWeapon >= transform.childCount - 1) //go back to the first weapon as we are on the last weapon in the
            { //transform.childCount is the total count of the things in the list
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++; //or go to the next weapon
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0) //going down
        {
            if(currentWeapon <= 0) //go back to the first weapon as we are on the last weapon in the
            {
                currentWeapon = transform.childCount - 1; //if the current weapon is less than or equal to 0 then go to the lasat weapon
            }// -1 as the index starts from 0
            else
            {
                currentWeapon++; //or go to the next weapon
            }
        }
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentWeapon = 3;
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true); //setting the weapon as active
            }
            else
            {
                weapon.gameObject.SetActive(false); //setting the weapon as inactive
            }
            weaponIndex++; //increment the weapon from 0 to all the rest and check if they are the require weapon or not
        }
    }   

}
