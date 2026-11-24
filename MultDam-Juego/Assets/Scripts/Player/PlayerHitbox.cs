using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    
    public GameObject self;
    
    private PlayerScript playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = self.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        EnemyScript enemyScript = collision.transform.parent.GetComponent<EnemyScript>();
        int damage = enemyScript.damage;
        
        playerScript.onHit(damage);
    }
    
}
