using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private float time = 0;
    public GameObject bullet;
    public Transform transhoot;
    public bool item;
    void Start()
    {
        item = false;
    }
    void Update()
    {
        EnemyMove();
        EnemyShoot();
    }

    public void EnemyMove()
    {
        Vector3 enemyDirection = new Vector3(0, -1);
        this.gameObject.transform.position += enemyDirection * Time.deltaTime * speed;

        if (time == 5000)
        {
            Destroy(gameObject);
        }
        time++;
    }
    private void EnemyShoot()
    {
        if (Random.Range(0, 100) % 5000 == 0)
        {
            Instantiate(bullet, transhoot.position, transhoot.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != this.gameObject.tag )
        {
            Destroy(gameObject);
            GameManager.instance.AddScore();
            RespawnEnemyController.instance.Respawn();
            if(Random.Range(0,100) % 20 == 0)
            {
                ShieldRespawnController.instance.shieldRespawn();
            }
            PlayerController.instance.enemyDie++;
        }
    }
}
