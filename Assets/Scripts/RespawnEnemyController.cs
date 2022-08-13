using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemyController : MonoBehaviour
{
    public static RespawnEnemyController instance;
    public Transform gate;
    public GameObject enemy;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void Respawn()
    {
        Instantiate(enemy, gate.position, gate.rotation);
    }
}
