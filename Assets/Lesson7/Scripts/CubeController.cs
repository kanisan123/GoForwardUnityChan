using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float speed = -12;

    private float deadLine = -10;

    private AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HitSound"))
        {
            if (collision.gameObject.TryGetComponent<AudioSource>(out var audioSource))
            {
                if (!audioSource.isPlaying)
                {
                    myAudioSource.Play(); // 二重に再生されるので考慮が必要
                }
            }
            else
            {
                myAudioSource.Play();
            }

            
        }
    }
}
