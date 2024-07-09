using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;
    
    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken"); //calling OnDamageTaken method
        //when damage is taken follow the player
        //BroadcastMessage only calls the methods that is on the gaame obj or its children and can be used multiple times but just calling once
        hitPoints -= damage; //reduce hitpoints when damage taken
        if(hitPoints <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if(isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
    }
}
