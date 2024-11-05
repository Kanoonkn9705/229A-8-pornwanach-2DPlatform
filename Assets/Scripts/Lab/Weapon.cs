using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] int damage;
    public int Damage { get { return damage; } set { damage = value; } }

    public IShootable shooter;

    public abstract void OnHitWith(Character character);

    public abstract void Move();

    public void Init(int newDamage, IShootable newOnwer)
    {
        Damage = newDamage;
        shooter = newOnwer;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 5f);
    }

    public int GetShootDirection()
    {
        float shootDir = shooter.SpawnPoint.position.x - shooter.SpawnPoint.parent.position.x;
        if (shootDir > 0)
        return 1; //right direction
        else return -1; //left direction
    }


}
