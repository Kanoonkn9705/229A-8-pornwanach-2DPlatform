using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    Transform SpawnPoint { get; set; }
    GameObject Bullet { get; set; }

    float rockWaitTime { get; set; }
    float rockTimer { get; set; }

    void Shoot();
}
