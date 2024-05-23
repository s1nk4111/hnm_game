using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 500.0f;
    public GameObject gameMgr;

    Rigidbody2D r2d;
    Animator animator;
    GameMgr gameMgrScript;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameMgrScript = gameMgr.GetComponent<GameMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            r2d.velocity = Vector2.zero;
            r2d.AddForce(new Vector2(0, jumpForce));
        }

        if (r2d.velocity.y > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private void FixedUpdate()
    {
        Vector3 position = transform.position;
        float y = transform.position.y;
        float vx = r2d.velocity.x;
        if (y > GetTop())
        {
            r2d.velocity = Vector2.zero;
            position.y = GetTop();
        }
        if (y < GetBottom())
        {
            r2d.velocity = Vector2.zero;
            r2d.AddForce(new Vector2(0, jumpForce));
            position.y = GetBottom();
        }
        transform.position = position;
    }

    float GetTop()
    {
        //画面の右上のワールド座標を取得する
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);    //Vector2.oneは(1, 1)
        return max.y;
    }
    float GetBottom()
    {
        //画面の左下のワールド座標を取得する
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        return min.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        gameMgrScript.StartGameOver();        //ゲームオーバーを通知
    }
}