using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy , IShootable
{
    [SerializeField] private float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }
    [SerializeField] private Player player;

    [SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    [SerializeField]
    Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

    public float rockWaitTime { get; set; }
    public float rockTimer { get; set; }

    private void Start()
    {
        Init(50);
        rockWaitTime = 2.0f;
        rockTimer = 0.0f;
    }
    
    void FixedUpdate()
    {
        rockTimer -= Time.deltaTime;
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
        if (rockTimer <= 0f)
        {
            animator.SetTrigger("Shoot");
            GameObject obj = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);
            
            Rock rockScipt = obj.GetComponent<Rock>();
            rockScipt.Init(20, this);

            rockTimer = rockWaitTime;
        }
    }
}
