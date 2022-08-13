using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float speed;
    private float time = 0;
    public GameObject shield;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        shieldMove();
    }

    public void shieldMove()
    {
        Vector3 shieldDirection = new Vector3(0, -1);
        this.gameObject.transform.position += shieldDirection * Time.deltaTime * speed;

        if (time == 5000)
        {
            Destroy(gameObject);
        }
        time++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
