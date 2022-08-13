using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class WaveController : MonoBehaviour
{
    public List<EnemyController> Enemy = new List<EnemyController>();
    public EnemyController enemySample;
    [SerializeField] private Transform[] _gate;
    public static WaveController instance;
    //private int _enemyInwave = 0;
    void Start()
    {
        //Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, CalculateEnemy);  
        Enemy.Add(enemySample);
        CreatEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreatEnemy()
    {
        for (int i = 0; i < Enemy.Count; i++)
        {
            var enemy = Enemy[i];
            var gate = Random.Range(0, _gate.Length);
            Instantiate(enemy, _gate[gate].position, _gate[gate].rotation);
        }
    }
    //private void calculateenemy(object data)
    //{
    //    _enemyinwave += 1;
    //    if (_enemyinwave == enemy.count)
    //    {
    //        if (enemy.count <= 10)
    //        {
    //            enemy.add(enemysample);
    //            createnemy();
    //        }
    //        else
    //        {
    //            createnemy();
    //            _enemyinwave = 0;
    //        }
    //    }
    //}
}
