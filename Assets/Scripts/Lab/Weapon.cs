using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damege
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public string owner;

    private void Start()
    {
        Move();
    }

    public void OnHitWith()
    {

    }

    public abstract void Move();

    public int GetShootDirection()
    {
        return 1;
    }


}
