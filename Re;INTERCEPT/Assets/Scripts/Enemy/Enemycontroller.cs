using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemycontroller : MonoBehaviour
{
    Rigidbody rb;
    Transform player;
    GameObject viewField; //
    UnityEngine.AI.NavMeshAgent nav;
    public PlayerHP playerHp;
    public EnemyManager enemyManager;

   
    bool inViewRange;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        viewField = GameObject.FindGameObjectWithTag("View");
    }

    private void OnTriggerStay(Collider collision) //
    {
        if (collision.gameObject == viewField)
        {
            inViewRange = true;
        }
    }
    private void OnTriggerExit(Collider collision) //
    {
        if (collision.gameObject == viewField)
        {
            inViewRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inViewRange || playerHp.currentHp <= 0 || enemyManager.totalTime==0) //ここにタイム0ならをいれる
        {
            nav.velocity = Vector3.zero;
        }
        else
        {
            nav.SetDestination(player.position);
        }
    }

   

    /*public void StopEnemy()
    {
        nav.velocity = Vector3.zero;
        //nav.Stop();
        StartCoroutine("EnemyCount");　//機能してない
        //Destroy(this.gameObject);
    }*/

    IEnumerator EnemyCount() //なぜか機能しない
    {
        yield return new WaitForSeconds(3f);
        //nav.SetDestination(player.position);
        //yield break;
    }
}
    
