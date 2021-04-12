using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{

    // ユニティちゃんのアニメーター
    Animator animator;

    // 移動させるコンポーネント
    Rigidbody2D rigid2D;

    private float groundLevel = -3.0f;

    private float dump = 0.8f;

    float jumpVelocity = 20;

    private float deadLine = -9;

    private 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", 1);

        bool isGround = transform.position.y <= groundLevel;
        animator.SetBool("isGround", isGround);

        // ジャンプ状態のときにはボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        if (Input.GetMouseButtonDown(0) && isGround)
        {
            rigid2D.velocity = new Vector2(0, jumpVelocity);
        }

        if (!Input.GetMouseButton(0))
        {
            if (rigid2D.velocity.y > 0)
            {
                rigid2D.velocity *= dump;
            }
        }

        if (transform.position.x < deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            Destroy(gameObject);
        }
    }
}
