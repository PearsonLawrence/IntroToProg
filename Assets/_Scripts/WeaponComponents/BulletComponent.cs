using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public GameObject Owner;
    public float DamageVal;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != Owner)
        {

            HealthComponent TempHealthComponentReference = other.GetComponent<HealthComponent>();

            if (TempHealthComponentReference != null)
            {
                TempHealthComponentReference.TakeDamage(DamageVal);
            }

            Destroy(gameObject);
        }
    }

}
