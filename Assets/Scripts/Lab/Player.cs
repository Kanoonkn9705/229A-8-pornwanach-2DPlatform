using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character , IShootable
{
    [SerializeField]
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }

    [SerializeField]
    Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } set { spawnPoint = value; } }

    public float rockWaitTime { get; set; }
    public float rockTimer { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && rockWaitTime >= rockTimer)
        {
            GameObject obj = Instantiate(bullet, SpawnPoint.position, Quaternion.identity);
            Banana banana = obj.GetComponent<Banana>();
            banana.Init(10, this);
            
        }
    }

    void Start()
    {
        Init(100);
        rockTimer = 0.0f;
        rockWaitTime = 1.0f;
    }

    void Update()
    {
        Shoot();
    }

    void FixedUpdate() 
    {
        rockWaitTime += Time.fixedDeltaTime;
    }

    void onCollisionEnter2D(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
        }
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
}
