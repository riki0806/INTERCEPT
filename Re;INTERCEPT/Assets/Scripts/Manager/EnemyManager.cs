using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public PlayerHP playerHP;
    public GameObject enemy; //敵のオブジェクト
    public float spawnTime = 3f;　//敵の生成間隔
    public Transform[] spawnPoints;　//敵を生成する場所
    public float totalTime = 120; //制限時間
    GameObject time;　//ヒエラルキーの中のタイム宣言
    Text timeText; //GetComponentのための制限
    //public PlayerController playerController;


    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);　//はじめを3秒で生成して、その次からも3秒で生成
        time = GameObject.Find("Time");
        timeText = time.GetComponent<Text>();
        //playerController = GetComponent<PlayerController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            timeText.text = "TIME " + totalTime.ToString("f2");　//小数点第二位まで表示
        }
        else
        {
            totalTime = 0;
            timeText.text = "TIME 0";
            //ここにゲームオーバー関数への遷移を書く
            //playerHP.GameOverScene();
            
            GameOver.SetActive(true);
            //playerController.enabled = false;
        }
    }

    void Spawn()　//敵を生成する処理
    {
        if (playerHP.currentHp <= 0f || totalTime == 0) 　//プレイヤーのHPが0の場合
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);　

        //敵を生成。spawnPointは新しくヒエラルキーで作る
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
