using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // スクロール速度
    private float scrollSpeed = -1;

    // 背景の左端
    private float deadLine = -18;

    // 背景の右端
    private float startLine = 18f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 背景をスクロール
        transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x < deadLine)
        {
            // 左端まで来たら右端に移動させる
            transform.position = new Vector2(startLine, 0);
        }
    }
}
