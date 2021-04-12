using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{

    public GameObject cubePrefab;

    private float delta = 0;

    // キューブの生成間隔
    private float span = 1.0f;

    // キューブの生成位置
    private float genPosX = 12;
    
    // キューブの生成位置オフセット
    private float offsetY = 0.3f;

    // キューブの縦方向の間隔
    private float spaceY = 6.9f;

    // キューブの生成位置オフセット
    private float offsetX = 0.5f;

    // キューブの横方向の間隔
    private float spaceX = 0.4f;

    // キューブの生成個数の上限
    private int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        if (delta > span)
        {
            delta = 0;

            // キューブの生成個数をランダムに決める
            int n = Random.Range(1, maxBlockNum + 1);

            for (int i = 0; i < n; i++)
            {
                // キューブを生成する
                GameObject go = Instantiate(cubePrefab);
                go.transform.position = new Vector2(genPosX, offsetY + i * spaceY);
            }

            // キューブの数に応じて次の生成間隔を調整する
            span = offsetX + spaceX * n;
        }
    }
}
