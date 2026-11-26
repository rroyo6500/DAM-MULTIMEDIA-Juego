using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int health = 100;
    public int damage = 1;
    public float droppedXP = 0;
    
    public float speed = 125f;
    public GameObject player;
    
    private Rigidbody2D playerBody;
    
    private Rigidbody2D body;
    private BoxCollider2D hitbox;
    private Rigidbody2D collision;
    
    private Animator animator;

    private Vector3 movement;
    private Vector2 lastPlayerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        hitbox = transform.Find("EnemyHitBox").GetComponent<BoxCollider2D>();
        animator = transform.Find("EnemySprite").GetComponent<Animator>();
        collision = transform.Find("EnemyCollisionBox").GetComponent<Rigidbody2D>();

        movement = Vector3.zero;
        
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y * speed * Time.fixedDeltaTime);
    }

    private void ReadMovement()
    {
        movement = Vector3.zero;

        if (playerBody != null)
        {
            lastPlayerPos = playerBody.position;
        }
        
        Vector2 vec = (lastPlayerPos - body.position).normalized;
        movement = vec;
    }

    public void OnHit(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
            player.GetComponent<PlayerScript>().GiveXp(droppedXP);
        }
    }
    
}
