using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPcontroller : MonoBehaviour
{
    public GameObject HP3;
    public GameObject HP2;
    public GameObject HP1;
    public GameObject HP0;

    public PlayerHP playerHp;
    EnemyAttack enemyAttack;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerHp.currentHp)
        {
            case 30:
                HP3.SetActive(true);
                HP2.SetActive(false);
                HP1.SetActive(false);
                HP0.SetActive(false);
                break;
            case 20:
                HP3.SetActive(false);
                HP2.SetActive(true);
                HP1.SetActive(false);
                HP0.SetActive(false);
                break;
            case 10:
                HP3.SetActive(false);
                HP2.SetActive(false);
                HP1.SetActive(true);
                HP0.SetActive(false);
                break;
            case 0:
                HP3.SetActive(false);
                HP2.SetActive(false);
                HP1.SetActive(false);
                HP0.SetActive(true);
                break;
            default:
                break;
        }
        
        /*
        if (playerHp.currentHp==20)
        {
            HP3.SetActive(false);
        }*/
        
    }
}
