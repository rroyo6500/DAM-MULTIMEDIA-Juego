using UnityEngine;

public class PlayerScript : MonoBehaviour
    {

        public int health = 100;
        public int damage = 1;
    
        public float speed = 250f;
    
        public float attaclSpeed = 5f;
        public float attackDuration = 1f;
    
        private Rigidbody2D body;
        private BoxCollider2D hitbox;
        private Rigidbody2D collisionBox;
        private GameObject attack;
    
        private Animator animator;

        private Vector3 movement;
        private float timeToNextAttack;
    
        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            collisionBox = transform.Find("PlayerCollisionBox").GetComponent<Rigidbody2D>();
            hitbox = transform.Find("PlayerHitBox").GetComponent<BoxCollider2D>();
            attack = transform.Find("PlayerAttack").gameObject;
            animator = transform.Find("PlayerSprite").GetComponent<Animator>();
        
            movement = Vector3.zero;
            timeToNextAttack = attaclSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            ReadMovement();
        }

        private void FixedUpdate()
        {
            body.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y * speed *Time.fixedDeltaTime);
        }
    
        private void ReadMovement()
        {
            movement = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                movement += Vector3.up;
            }
            else if (Input.GetKey(KeyCode.S)) 
            {
                movement += Vector3.down;
            }
            if (Input.GetKey(KeyCode.A)) 
            {
                movement += Vector3.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movement += Vector3.right;
            }
        
        }

        public void OnHit(int dmg)
        {
            health -= dmg;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
