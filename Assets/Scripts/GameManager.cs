using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EnemyController enemy;
    public int scorePlayer;
    public Text scoreTxt;
    public GameObject gate;
    
    private void Awake()
    {
         if (instance == null) instance = this;
    }

    void Update()
    {
        scoreTxt.text = "Score : " + scorePlayer.ToString();
    }

    public void AddScore()
    {
        scorePlayer += 10;
    }
}