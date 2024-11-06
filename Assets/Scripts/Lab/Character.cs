using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public void Init(int newHealth)
    {
        Health = newHealth;
    }

    [SerializeField] private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public Animator animator;
    public Rigidbody2D rb;
    public HealthBar healthBar;

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.SetHealth(Health);

        IsDead();
    }
    
}
