using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRespawnController : MonoBehaviour
{
    public static ShieldRespawnController instance;
    public Transform gate;
    public Transform shield;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

public void shieldRespawn()
    {
        Instantiate(shield, gate.position, gate.rotation);
    }
}
