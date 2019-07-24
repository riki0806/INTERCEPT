using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //Rigidbody rb;
    //float count = 3;
    private const float G = 9.9f;
    bool inViewRangeI;
    GameObject viewField;


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        viewField = GameObject.FindGameObjectWithTag("View");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, 1), transform.position.z);

        if (inViewRangeI)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay(Collider collision) //
    {
        if (collision.gameObject == viewField)
        {
            inViewRangeI = true;
            Debug.Log("stayItem");
        }
    }
    private void OnTriggerExit(Collider collision) //
    {
        if (collision.gameObject == viewField)
        {
            inViewRangeI = false;
        }
    }

    /*public void TakeItem()
    {
        Destroy(this.gameObject);
    }*/
}
