using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;

    public override void Move()
    {
        Debug.Log("Banana Move With Constant Speed");
    }

}
