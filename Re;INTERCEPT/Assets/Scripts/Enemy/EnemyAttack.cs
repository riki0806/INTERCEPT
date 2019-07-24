using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10;

    GameObject player;
    PlayerHP playerHp;

    bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHp = player.GetComponent<PlayerHP>();

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            inRange = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == player)
        {
            inRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            Attack();

            Destroy(this.gameObject);
        }
    }

    void Attack()
    {
        if (playerHp.currentHp > 0)
        {
            playerHp.TakeDamage(attackDamage);
        }
    }
}
