using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody2D r2d;
    float blockspeed = -100;    //移動速度
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        r2d.AddForce(new Vector2(blockspeed, 0));
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if (position.x < GetLeft() - 10)
        {
            Destroy(gameObject);    //画面外に出たので消す
        }
    }

    float GetLeft()
    {
        // 画面の左下のワールド座標を取得する
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);    //Vector2.zeroは(0, 0)
        return min.x;
    }
    
    //速度を設定
    public void SetSpeed(float speed)
    {
        blockspeed = speed;
    }
}