using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int healAmount = 25;
    public float speedBoost = 40f;
    public int damageBoost = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerScript player = other.GetComponentInParent<PlayerScript>();
        if (player != null)
        {
            player.health = Mathf.Min(player.health + healAmount, player.maxHealth);
            player.speed += speedBoost;

            PlayerAttack attack = player.GetComponentInChildren<PlayerAttack>();
            if (attack != null) attack.damage += damageBoost;

            Destroy(gameObject);
        }
    }
}
