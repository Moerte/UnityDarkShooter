using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damage = 10;
    public bool ignoreTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (ignoreTrigger)
            return;

        Health heath = other.GetComponent<Health>();
        if(heath != null)
        {
            DoDamage(heath, damage);
        }
    }
    public void DoDamage(Health health, int damage)
    {
        health.TakeDamage(damage, transform.position);
    }
}
