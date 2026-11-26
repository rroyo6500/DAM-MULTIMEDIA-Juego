using System;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{

    public float timeBetweenHits = 1f;

    private float timeToNextHit;
    
    private PlayerScript playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = transform.GetComponent<ObjectRef>().reference.GetComponent<PlayerScript>();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        timeToNextHit -= Time.deltaTime;
        if (timeToNextHit <= 0)
        {
            timeToNextHit = timeBetweenHits;
            
            if (collision.gameObject.layer != LayerMask.NameToLayer("EnemyHitbox"))
            {
                return;
            }

            EnemyScript enemy = collision.GetComponentInParent<EnemyScript>();
            if (enemy == null)
            {
                return;
            }

            playerScript.OnHit(enemy.damage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        timeToNextHit = 0f;
    }
}
