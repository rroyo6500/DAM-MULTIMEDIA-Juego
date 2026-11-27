using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage = 15;
    public float timeBetweenHits = 1f;

    private float damageTimer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = GetPlayer(other);
        if (player != null)
        {
            player.OnHit(damage);
            damageTimer = timeBetweenHits;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerScript player = GetPlayer(other);
        if (player != null)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0f)
            {
                player.OnHit(damage);
                damageTimer = timeBetweenHits;
            }
        }
    }

    private PlayerScript GetPlayer(Collider2D other)
    {
        PlayerScript player = other.GetComponentInParent<PlayerScript>();
        if (player != null) return player;

        ObjectRef objRef = other.GetComponent<ObjectRef>();
        if (objRef != null && objRef.reference != null)
        {
            return objRef.reference.GetComponent<PlayerScript>();
        }

        return null;
    }
}
