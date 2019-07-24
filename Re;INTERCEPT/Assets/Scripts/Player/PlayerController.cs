using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //プレイヤーキャラ情報
    Rigidbody rb;
    public float speed = 2.0f;
    public float maxSpeed = 10.0f;

    //オブジェクト宣言
    public GameObject camera;

    public GameObject enemy;
    public GameObject item;//アイテムコンポーネントをアタッチしてtransform.positionで位置を割り出す

    public GameObject Enemy;
    public GameObject Item;　//後objectFindでアイテムコンポーネントを取得用だから割り当てなくていい


    //ポジション宣言
    private Vector3 startPosition;
    private Vector3 playerPosition;
    //private Vector3 enemyPosition;　//positionによる当たり判定用
    //private Vector3 itemPosition; //positionによる当たり判定用

    //マウス方向取得宣言
    Plane plane = new Plane();
    float distance = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = camera.transform.position;
        playerPosition = transform.position;
        //enemyPosition = enemy.transform.position;　//positionによる当たり判定用
        //itemPosition = item.transform.position;　//positionによる当たり判定用
    }

    // Update is called once per frame
    void Update()
    {
        //キャラ移動
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;

        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.AddForce(x, 0, z);
        }

        Vector3 difference = transform.position - playerPosition;

        //少しでも力加わったらキャラが回転
        if (difference.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(difference);
        }
        playerPosition = transform.position;

        camera.transform.position =
            startPosition + new Vector3(transform.position.x, 0, transform.position.z);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //あたらしく作ったカメラクラスの方をひっぱってしまうらしい

        // プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);

        if (plane.Raycast(ray, out distance))
        {

            // 距離を元に交点を算出して、交点の方を向く
            var lookPoint = ray.GetPoint(distance);

            transform.LookAt(lookPoint);

        }

        //Vector3 eyeDir = this.transform.forward; // プレイヤーの視線ベクトル

        /*if (enemyPosition != null)
        {
            enemyPosition = enemy.transform.position; //敵の現在位置取得
        }*/

        //float angle = 30.0f;
        //float watchDistance = 3.5f;

        //positionによる敵との当たり判定
        /*Enemy = GameObject.Find("Enemy");
        Enemycontroller enemyController;//下のやつの取得
        enemyController = Enemy.GetComponent<Enemycontroller>();
        if (Vector3.Angle((enemyPosition - playerPosition).normalized, eyeDir) <= angle && Vector3.Distance(enemyPosition, playerPosition) <= watchDistance)
        {
            enemyController.StopEnemy();
        }*/

        //positionによるアイテムとの当たり判定
        /*Item = GameObject.Find("Item");　//オブジェクトの中からItemを探し出す
        ItemManager itemManager;　//スクリプト格納用変数
        itemManager = Item.GetComponent<ItemManager>();　//割り当て
        if (Vector3.Angle((itemPosition - playerPosition).normalized, eyeDir) <= angle && Vector3.Distance(itemPosition, playerPosition) <= watchDistance)
        {
            itemManager.TakeItem();　//itemManagerのTakeItemを呼び出す
        }*/
    }
}
