using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType; //can selects the type of ammo with this
    [SerializeField] Ammo ammoSlot; //making connection from ammo class
    //instantiating as we want it to appear at a ceratian point adn nota  fixed location adn get destroyed later
    [SerializeField] float timeBetweenShots = 0.5f;
    bool canShoot = true;
    
    private void OnEnable() 
    {
        canShoot = true;
    }
    private void Start() {
        Debug.Log("Weapon.cs is attached to " + this.gameObject.name, this.gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true) 
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0) //we the current ammo that we got is more than 0
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType); //reducing the ammo by accessing reduce current ammo method from aammo class
        }
        yield return new WaitForSeconds(timeBetweenShots); //to wait between shots / have a cooldown time
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit; //variable of type raycasthit
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        //move the ray from the camera's current position to the forward direction
        //out is a keyword used to tell what the raycast is hitting (variable hit has infor abt what we hit) 
        //& lastly range to tell how far the ray travels
        {
            CreateHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>(); //target is what is being hit
            if (target == null) //if the target is not the enemy (as we get an error is we hit anything which is not the enemy)
            {
                return;
            }
            target.TakeDamage(damage); //accessing public class from EnemyHealth class/script
        }
        else
        {
            return;
        }
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject Impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //hit.point: This is the position where the raycast hit something. 
        //Quaternion.LookRotation(hit.normal): makes sure that the effects faces the direction of the surface normal at the hit point
        //(ensuring that the edffect is aligned w the surface)
        Destroy(Impact, .1f);
    }
}
