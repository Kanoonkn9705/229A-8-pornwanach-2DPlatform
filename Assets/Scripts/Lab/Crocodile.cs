using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy , IShootable
{
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }
    [SerializeField] private Player player;

    [SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    [SerializeField]
    Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

    public float WaitTime { get; set; }
    public float ReloadTime { get; set; }

    private void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 1.0f;
        DamageHit = 30;
        attackRange = 6;
        player = GameObject.FindObjectOfType<Player>();
    }
    
    void Update()
    {
        WaitTime += Time.fixedDeltaTime;
        Behavior();    
    }

    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;
        if (direction.magnitude < attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            Instantiate(bullet, spawnPoint.position, Quaternion.identity);

            WaitTime = 0;
        }
    }
}
