using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{

    private EnemyScript enemyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyScript = transform.GetComponent<ObjectRef>().reference.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAttack player = collision.GetComponent<ObjectRef>()
            .reference.GetComponent<PlayerAttack>();
        
        if (player == null)
        {
            return;
        }
        
        enemyScript.OnHit(player.damage);
    }
    
}
