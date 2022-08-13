using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    private float time = 0;
    public float timeLimit;
    public float damage;

    private void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        if (time == timeLimit)
        {
            Destroy(this.gameObject);
        }
        time++;
        this.transform.position += transform.up * Time.deltaTime * speed;
    }
    public virtual float CalculateHp(float hp)
    {
        var hpLeft = hp - damage;
        return hpLeft;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != this.gameObject.tag)
            Destroy(this.gameObject);
    }
}
