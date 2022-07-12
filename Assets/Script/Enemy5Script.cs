using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Script : MonoBehaviour
{
    float x;
    float y;
    float size;

    const float SPEED = 7.2f;
    const float SIZEUP_SPEED = 1.08f;

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
        size = 1.2f;
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

        // size up
        size += SIZEUP_SPEED * Time.deltaTime;
        transform.localScale = new Vector3(1.2f, size, 1);
        // collider size up
        GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.7f * size);

        if (x < -8.5f) {
            Destroy(gameObject);
        }

        transform.position = new Vector3(x, y, 0);
    }
}
