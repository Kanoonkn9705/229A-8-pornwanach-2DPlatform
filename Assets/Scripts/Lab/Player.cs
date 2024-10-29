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

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime > ReloadTime)
        {
            Instantiate(bullet, SpawnPoint.position, Quaternion.identity);
        }
    }

    void Start()
    {
        Init(100);
        WaitTime = 0.0f;
        ReloadTime = 1.0f;
    }

    void Update()
    {
        Shoot();
    }

    void FixedUpdate() 
    {
        WaitTime += Time.fixedDeltaTime;
    }


}
