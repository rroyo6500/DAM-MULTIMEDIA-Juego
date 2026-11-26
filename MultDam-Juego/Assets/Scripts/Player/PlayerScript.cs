using UnityEngine;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
    {

        public MouseController mouse;
        
        public int health = 100;
        public int maxHealth = 100;
        public int damage = 1;
        
        public int level = 0;
        public int maxLevel = 10;
        public float xpPerLevel = 1f;
        public float xpDiffPerLevel = 0.25f;
        private float currentXp = 0f;
        
        public float speed = 250f;
    
        public float attackSpeed = 5f;
        public float attackDuration = 1f;
    
        private Rigidbody2D body;
        private CameraScript playerCamera;
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
            playerCamera = GetComponentInChildren<Camera>().GetComponent<CameraScript>();
            collisionBox = transform.Find("PlayerCollisionBox").GetComponent<Rigidbody2D>();
            hitbox = transform.Find("PlayerHitBox").GetComponent<BoxCollider2D>();
            attack = transform.Find("PlayerAttack").gameObject;
            animator = transform.Find("PlayerSprite").GetComponent<Animator>();
        
            movement = Vector3.zero;
            timeToNextAttack = attackSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            ReadMovement();
            UpdateAnimator();
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
        
        private void UpdateAnimator()
        {
            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetBool("movement", true);

                if (movement.x > 0)
                {
                    animator.SetInteger("right", 1);
                } else if (movement.x < 0)
                {
                    animator.SetInteger("right", -1);
                }
                else
                {
                    animator.SetInteger("right", 0);
                }

                if (movement.y > 0)
                {
                    animator.SetBool("up", true);
                }
                else
                {
                    animator.SetBool("up", false);
                }
                
            }
            else
            {
                animator.SetBool("movement", false);
                animator.SetBool("up", false);
                animator.SetInteger("right", 0);
            }
        }

        public void GiveXp(float xp)
        {
            currentXp += xp;

            float requiredXp = xpPerLevel * ((xpDiffPerLevel + 1) * level + 1);
            while (currentXp >= requiredXp && level < maxLevel)
            {
                level++;
                currentXp -= requiredXp;
                requiredXp = xpPerLevel * ((xpDiffPerLevel + 1) * level + 1);
            }
        }

        public void OnHit(int dmg)
        {
            health -= dmg;
            if (health <= 0)
            {
                if (playerCamera != null)
                {
                    playerCamera.Remove();
                }
                Destroy(gameObject);
            }
        }
    }
