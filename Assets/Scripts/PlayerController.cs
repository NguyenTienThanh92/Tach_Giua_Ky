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
    public int enemyDie;
    public static PlayerController instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        slider_hp.maxValue = hp;
    }

    void Update()
    {
        slider_hp.maxValue = hp;
        PlaneMove();
        PlaneShoot();
        HpUp();
        {
            hpTxt.text = "HP : " + hp.ToString();
        }
    }
    public void PlaneMove()
    {
        bodyPlane.up = Vector3.up;
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal , 0);

        if (direction != Vector3.zero)
        {
             this.gameObject.transform.up = direction;
        }
        this.gameObject.transform.position += direction * Time.deltaTime * speed;   
    }

    public void PlaneShoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bullet, transhoot.position, transhoot.rotation);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.gameObject.tag == "Enemy" && item == false)
        {
            var objectCollisions = collision.GetComponent<BulletController>();
            hp = objectCollisions.CalculateHp(hp);
        }
        else if (collision.gameObject.tag == "Item")
        {
            item = true;
        }
    }
    private void HpUp()
    {
        if (enemyDie == 10)
        {
            hp += 5;
            hp = hp += 5;
        }
        {
            hpTxt.text = "HP : " + hp.ToString();
        }

    }

}
