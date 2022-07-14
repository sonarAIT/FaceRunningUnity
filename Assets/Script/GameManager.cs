using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPause;
    public bool isGameOver;
    public int level;
    float time;
    
    Text scoreText;
    Text levelText;

    Canvas canvas;
    Canvas gameOverCanvas;
    Text gameOverText1;
    Text gameOverText2;
    Text gameOverText3;
    Text gameOverText4;

    public GameObject diePlayer;
    public AudioClip deathAgonySound;
    public AudioClip dingSound;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        time = 1000;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        gameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        gameOverText1 = GameObject.Find("GameOverText1").GetComponent<Text>();
        gameOverText2 = GameObject.Find("GameOverText2").GetComponent<Text>();
        gameOverText3 = GameObject.Find("GameOverText3").GetComponent<Text>();
        gameOverText4 = GameObject.Find("GameOverText4").GetComponent<Text>();

        gameOverCanvas.enabled = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver) {
            if(Input.GetKeyDown(KeyCode.Z)) {
                // reload scene
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
            }
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
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
        scoreText.text = "ただいまの走行距離: " + getMeter() + "m";
    }

    int getMeter() {
        return (int)(time * 10);
    }

    void levelUpdate() {
        int prevLevel = level;
        level = (int)(time * 10 / 500 + 1);
        if(prevLevel != level) {
            levelText.text = "LEVEL: " + level;
        }
    }

    public void StartGameOver() {
        isGameOver = true;
        canvas.enabled = false;
        GameObject player = GameObject.Find("Player");
        Vector3 playerPos = player.transform.position;
        Destroy(player);
        GameObject diePlayer = Instantiate(this.diePlayer, playerPos, Quaternion.identity);
        audioSource.PlayOneShot(deathAgonySound);
    }

    public void EndGameOver() {
        gameOverText1.text = "GameOver!";
        gameOverText2.text = "あなたのスコア: " + getMeter() + "m";
        gameOverText3.text = "あなたの最終到達レベル: " + level;
        gameOverText4.text = "Zキーでもう一度プレイ";
        gameOverCanvas.enabled = true;

        audioSource.Stop();
        audioSource.PlayOneShot(dingSound);
    }
}
