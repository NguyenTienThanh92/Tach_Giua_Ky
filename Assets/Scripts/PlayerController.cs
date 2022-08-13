using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Transform bodyPlane;
    public Transform transhoot;
    public BulletController bullet;
    public float hp;
    public Slider slider_hp;
    public Text hpTxt;
    private bool item;

    private void Awake()
    {
        slider_hp.maxValue = hp;
    }

    void Update()
    {
        slider_hp.maxValue = hp;
        {
            hpTxt.text = "HP : " + hp.ToString();
        }
        planeMove();
        planeShoot();
    }
    public void planeMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal , 0);
        bodyPlane.up = Vector3.up;

        if (direction != Vector3.zero)
        {
             this.gameObject.transform.up = direction;
        }
        this.gameObject.transform.position += direction * Time.deltaTime * speed;   
    }

    public void planeShoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bullet, transhoot.position, transhoot.rotation);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && item == false)
        {
            var objectCollisions = collision.GetComponent<BulletController>();
            hp = objectCollisions.CalculateHp(hp);
        }
        if (collision.gameObject.tag == "item")
        {
            item = true;
        }
    }
}
