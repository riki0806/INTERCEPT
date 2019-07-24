using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int startHp = 30; //初期HP
    public int currentHp; //ゲーム中HP

    public Image damageImage;　//赤スライド
    //public Image HP3; //HP宣言
    private Sprite sprite; //画像変更のための宣言

    public float flashSpeed = 5f;　//赤スライドの消える時間
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);　//赤スライドの色合い、透過度

    private PlayerController playerController;//死んだときの操作受付用

    public bool damaged;　//ダメージを受けているか
    bool dead;　//死んでいるか

    public GameObject GameOver;
    //public EnemyManager enemyManager;
    


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();　//取得
        currentHp = startHp;　//初期HPを現在HPに代入
        dead = false;
        //enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)　//damagedがtrueになったら
        {
            damageImage.color = flashColor; //赤スライド出す
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);　//赤スライド消す
        }
        damaged = false;　//フラグを切る

        /*if (enemyManager.totalTime == 0)
        {
            playerController.enabled = false;
        }*/

    }

    public void TakeDamage(int amount)　
    {
        damaged = true;

        currentHp -= amount;
        /*sprite =Resources.Load<Sprite>("HP2");
        HP3 = this.GetComponent<Image>();
        HP3.sprite = sprite;*/

        if (currentHp <= 0 && !dead) //HP0以下かつdeadでない
        {
            Death();
        }
    }

    public void Death()
    {
        dead = true;

        playerController.enabled = false;　//操作できないように
        //GameOverScene();
        GameOver.SetActive(true);
    }

    /*public void GameOverScene()
    {
        GameOver.SetActive(true);
    }*/
}
