using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    float x;
    float y;

    float SPEED;

    const float WINDOW_W = 15;
    const float WINDOW_H = 10;

    const float INIT_X = 8.5f;
    const float INIT_Y = -2.5f;
    
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        x = INIT_X;
        y = Random.Range(INIT_Y + 0.5f, 5);
        SPEED = (int)Random.Range(0, 5) * 1 + 2.33f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isPause || gameManager.isGameOver) {
            return;
        }

        x -= SPEED * Time.deltaTime;

        if (x < -8.5f) {
            Destroy(gameObject);
        }

        transform.position = new Vector3(x, y, 0);
    }
}
