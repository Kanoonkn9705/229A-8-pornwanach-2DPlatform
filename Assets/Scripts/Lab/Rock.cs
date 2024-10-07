using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    private Rigidbody2D rb2d;
    private Vector2 force;

    public override void Move()
    {
        Debug.Log("Rock Move With RigidBody: force");
    }

}
