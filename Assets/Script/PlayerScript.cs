using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip downSound;

    float x;
    float y;
    float jumpTime;
    float penaltyTime;

    enum action { idle, jump, down };
    action act;

    const float SPEED = 9.6f;
    const float JUMP_SPEED = 3.6f;
    const float JUMP_HEIGHT = 5;
    const float DOWN_SPEED = 24;

    const float WINDOW_W = 15;
    const float WINDOW_H = 10;

    const float INIT_X = -4.78f;
    const float INIT_Y = -2.5f;
    
    const float PENALTY_THRESHOLD = 0.2f;
    const float PENALTY_TIME = 0.2f;

    GameManager gameManager;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        x = INIT_X;
        y = INIT_Y;
        jumpTime = 0;
        penaltyTime = 0;
        act = action.idle;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime > PENALTY_THRESHOLD) {
            penaltyTime = PENALTY_TIME;
        } else {
            penaltyTime = Math.Max(penaltyTime - Time.deltaTime, 0);
        }

        if(gameManager.isPause) {
            return;
        }
        //input handling
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            down();
        } else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            up();
        }
        
        // left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            left();
        }
        // right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            right();
        }

        updateY();

        // set position
        transform.position = new Vector3((float)x, (float)y, 0);
    }

    void up() {
        if(act != action.idle) {
            return;
        }

        act = action.jump;
        jumpTime = 0.01f;
        audioSource.PlayOneShot(jumpSound);
    }

    void down() {
        if(act != action.jump) {
            return;
        }

        act = action.down;
        audioSource.PlayOneShot(downSound);
    }

    void left() {
        x = Math.Max(x - SPEED * Time.deltaTime, -WINDOW_W/2);
    }

    void right() {
        x = Math.Min(x + SPEED * Time.deltaTime, WINDOW_W/2);
    }

    void updateY() {
        if(act == action.jump) {
            y = INIT_Y + JUMP_HEIGHT * (float)Math.Sin(jumpTime);
            jumpTime += Time.deltaTime * JUMP_SPEED;
            if(y <= INIT_Y) {
                jumpEnd();
            }
        } else if(act == action.down) {
            y -= DOWN_SPEED * Time.deltaTime;
            if(y <= INIT_Y) {
                jumpEnd();
            }
        }
    }

    void jumpEnd() {
        act = action.idle;
        jumpTime = 0;
        y = INIT_Y;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" && penaltyTime == 0) {
            Debug.Log("Game Over");
            gameManager.StartGameOver();
        }
    }
}
