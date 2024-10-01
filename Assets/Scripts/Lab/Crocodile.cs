using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField] private float attackRange;
    [SerializeField] private Player player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletWaitTime;
    [SerializeField] private float bulletTimer;

    private void Start()
    {
        Init(100);
        Behavior();
    }
    
    private void Update()
    {
        bulletTimer -= Time.deltaTime;
        Behavior();
        if (bulletTimer < 0 )
        {
            bulletTimer = bulletWaitTime;
        }
    }

    public override void Behavior()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance < attackRange)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bulletTimer < 0)
        {
            Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
        }
    }
}
