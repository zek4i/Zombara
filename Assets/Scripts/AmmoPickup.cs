using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickups : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammotype;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammotype, ammoAmount);
            Destroy(gameObject);
        }
    }
}
