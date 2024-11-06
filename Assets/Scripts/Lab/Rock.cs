using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    private Rigidbody2D rb2d;
    private Vector2 force;

    void Start()
    {
        Damage = 30;
        force = new Vector2 (GetShootDirection() * 100, 400);
        Move();
    }

    public override void Move()
    {
        rb2d.AddForce (force, ForceMode2D.Impulse);
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }
}
