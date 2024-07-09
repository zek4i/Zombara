using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target; //this is where the target is if transform type is used
    //but here we are directly linking playerhealth and target instead of doing the drag & drop each time
    //accessing anything within the player health class
    [SerializeField] float damage = 40f;
    void Start()
    {
        target = FindFirstObjectByType<PlayerHealth>(); 
    }
    public void AttackHitEvent()
    {
        if(target == null)
        {
            return;
        }
        target.TakeDamage(damage); //damaging the player
        //no need to access palyer health again as we already did it once at start
        Debug.Log("BANG BANG!");
    }


}
