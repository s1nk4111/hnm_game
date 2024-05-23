using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMgr : MonoBehaviour
{
    public GameObject block;
    float timer = 0;        //�J�E���g�_�E��
    float totalTime = 0;
    int cnt = 0;     //�A���J�[������
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        totalTime += Time.deltaTime;

        if (timer < 0)
        {
            Vector3 position = transform.position;
            position.y = Random.Range(-4, 4);
            GameObject obj = Instantiate(block, position, Quaternion.identity);
            Block blockScript = obj.GetComponent<Block>();
            //��{���x200�ɁA�o�ߎ���x5��������
            float speed = 200 + (totalTime * 5);
            blockScript.SetSpeed(-speed);
            cnt++;
            if (cnt % 10 < 3)
            {
                timer += 0.1f;
            }
            else
            {
                timer += 1;
            }
        }
    }
}
