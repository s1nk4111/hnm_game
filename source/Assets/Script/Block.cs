using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Rigidbody2D r2d;
    float blockspeed = -100;    //�ړ����x
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
            Destroy(gameObject);    //��ʊO�ɏo���̂ŏ���
        }
    }

    float GetLeft()
    {
        // ��ʂ̍����̃��[���h���W���擾����
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);    //Vector2.zero��(0, 0)
        return min.x;
    }
    
    //���x��ݒ�
    public void SetSpeed(float speed)
    {
        blockspeed = speed;
    }
}