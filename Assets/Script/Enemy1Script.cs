using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    float x;
    float y;

    const float SPEED = 1.8f;

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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isPause) {
            return;
        }

        x -= SPEED * Time.deltaTime;

        transform.position = new Vector3(x, y, 0);
    }
}
