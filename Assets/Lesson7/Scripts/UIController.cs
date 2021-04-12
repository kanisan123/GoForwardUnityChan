using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameObject gameOverText;

    private GameObject runLengthText;

    private float len = 0;

    private float speed = 5f;

    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText = GameObject.Find("GameOver");
        runLengthText = GameObject.Find("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            len += speed * Time.deltaTime;
            runLengthText.GetComponent<Text>().text = $"Distance: {len:F2}m";
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //SampleSceneを読み込む（追加）
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void GameOver()
    {
        gameOverText.GetComponent<Text>().text = "Game Over";
        isGameOver = true;
    }
}
