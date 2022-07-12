using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Script : MonoBehaviour
{
    float x;
    float y;
    float jumpTime;

    const float SPEED = 1.8f;
    const float JUMP_HEIGHT = 5f;
    const float JUMP_SPEED = 3.6f;

    const float WINDOW_W = 15;
    const float WINDOW_H = 10;

    const float INIT_X = 8.5f;
    const float INIT_Y = -2.5f;
    
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        x = INIT_X;
        y = INIT_Y;
        jumpTime = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isPause || gameManager.isGameOver) {
            return;
        }

        // move
        x -= SPEED * Time.deltaTime;

        jumpTime += JUMP_SPEED * Time.deltaTime;
        float nextY = INIT_Y + JUMP_HEIGHT * Mathf.Sin(jumpTime);
        if(nextY > INIT_Y) {
            y = nextY;
        } else {
            jumpTime = 0;
            y = INIT_Y;
        }

        if (x < -8.5f) {
            Destroy(gameObject);
        }

        transform.position = new Vector3(x, y, 0);
    }
}
