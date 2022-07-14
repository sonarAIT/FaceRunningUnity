using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StarGenerateScript : MonoBehaviour
{
    public GameObject StarPrehab;
    Color[] COLORS = new Color[]{Color.white, Color.red, Color.yellow, Color.blue, new Color(1f, 0.255f, 0f, 1f), Color.magenta};
    GameManager gameManager;
    float time;

    const float INIT_Y = -2.5f;
    const float INTERVAL = 0.03f;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        time = 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPause || gameManager.isGameOver)
        {
            return;
        }
        
        time += Time.deltaTime;
        while(time >= INTERVAL) {
            time -= INTERVAL;
            GenerateStar();
        }
    }

    void GenerateStar() {
        GameObject star = Instantiate(this.StarPrehab, new Vector3(8.5f, INIT_Y, 0), Quaternion.identity);
        bool isWhite = UnityEngine.Random.Range(0, 2) == 0;
        if (isWhite) {
            star.GetComponent<SpriteRenderer>().color = Color.white;
        } else {
            star.GetComponent<SpriteRenderer>().color = COLORS[UnityEngine.Random.Range(0, Math.Min(COLORS.Length, gameManager.level))];
        }
    }
}
