using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGenerateScript : MonoBehaviour
{
    public GameObject[] EnemyPrehabs;
    GameManager gameManager;
    double time;

    const float INIT_Y = -2.5f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        time = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPause || gameManager.isGameOver)
        {
            return;
        }
        
        time += Time.deltaTime;
        if (time >= 3) {
            GenerateEnemy();
            if(gameManager.level > 2) {
                GenerateEnemy();
            }
            time = 0;
        }
    }

    void GenerateEnemy() {
        GameObject enemy = Instantiate(this.EnemyPrehabs[UnityEngine.Random.Range(0, Math.Min(EnemyPrehabs.Length, gameManager.level + 1))], new Vector3(8.5f, INIT_Y, 0), Quaternion.identity);
    }
}
