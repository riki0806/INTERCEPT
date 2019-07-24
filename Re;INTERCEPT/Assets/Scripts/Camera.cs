using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    private float rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation.y;
    }

    public void main()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //水平方向の更新
        if (Input.GetMouseButton(0))
        {
            rotation += Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }

    }
}
