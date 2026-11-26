using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damage;
    public float attackSpeed;
    public float attackDuration;
    
    public float angleOffset = 0f;

    private float timeToNextAttack;
    private float duration;

    private SpriteRenderer sprite;
    private Animator anim;
    private PolygonCollider2D col;
    
    private MouseController mouse;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript ps = gameObject.GetComponent<ObjectRef>().reference.GetComponent<PlayerScript>();
        mouse = ps.mouse;
        sprite = transform.Find("PlayerAttackSprite").GetComponent<SpriteRenderer>();
        anim = transform.Find("PlayerAttackSprite").GetComponent<Animator>();
        col = transform.Find("PlayerAttackBox").gameObject.GetComponent<PolygonCollider2D>();

        if (damage == 0)
        {
            damage = ps.damage;
        }
        if (attackSpeed == 0)
        {
            attackSpeed = ps.attackSpeed;
        }
        if (attackDuration == 0)
        {
            attackDuration = ps.attackDuration;
        }

        timeToNextAttack = attackSpeed;
        duration = attackDuration;
    }

    private void FixedUpdate()
    {
        CheckDirection();
        Attack();
    }

    private void CheckDirection()
    {
        if (mouse == null) return;
        
        Vector2 direction = mouse.WorldMousePos - (Vector2)transform.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0f, 0f, angle + angleOffset);
    }

    private void Attack()
    {
        if (col.enabled || sprite.enabled)
        {
            duration -= Time.fixedDeltaTime;
            if (duration <= 0)
            {
                col.enabled = false;
                sprite.enabled = false;
                duration += attackDuration;
            }
        }
        else
        {
            timeToNextAttack -= Time.fixedDeltaTime;
            if (col.enabled) col.enabled = false;
            if (sprite.enabled) sprite.enabled = false;
            if (timeToNextAttack < 0)
            {
                col.enabled = true;
                sprite.enabled = true;
                timeToNextAttack += attackSpeed;
            }
        }
        
    }
    
}
