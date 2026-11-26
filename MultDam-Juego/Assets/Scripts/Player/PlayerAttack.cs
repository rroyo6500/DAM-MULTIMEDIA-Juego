using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damage;
    public float attackSpeed;
    public float attackDuration;

    private float timeToNextAttack;
    private float duration;

    private SpriteRenderer sprite;
    private Animator anim;
    private PolygonCollider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript ps = gameObject.GetComponent<ObjectRef>().reference.GetComponent<PlayerScript>();
        sprite = transform.Find("PlayerAttackSprite").GetComponent<SpriteRenderer>();
        anim = transform.Find("PlayerAttackSprite").GetComponent<Animator>();
        col = transform.Find("PlayerAttackBox").gameObject.GetComponent<PolygonCollider2D>();

        if (damage == 0)
        {
            damage = ps.damage;
        }
        if (attackSpeed == 0)
        {
            attackSpeed = ps.attaclSpeed;
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
        Attack();
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
