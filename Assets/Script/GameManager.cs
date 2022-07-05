using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPause;
    public int level;
    float time;
    
    Text scoreText;
    Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        time = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            isPause = !isPause;
        }

        if(isPause) {
            return;
        }

        time += Time.deltaTime;
        meterUpdate();
        levelUpdate();
    }

    void meterUpdate() {
        scoreText.text = "ただいまの走行距離: " + (int)(time * 10) + "m";
    }

    void levelUpdate() {
        int prevLevel = level;
        level = (int)(time * 10 / 500 + 1);
        if(prevLevel != level) {
            levelText.text = "LEVEL: " + level;
        }
    }
}
