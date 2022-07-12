using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiePlayerScript : MonoBehaviour
{
    bool isDieing;
    bool swingToggle;
    const double DIE_TIME = 1.5;
    const double ROTATE_SPEED = 60;
    const float GROUND_Y = -2.8f;
    // Start is called before the first frame update
    void Start()
    {
        isDieing = true;
        swingToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDieing) {
            return;
        }

        // rotate
        transform.Rotate(0, 0, (float)(-ROTATE_SPEED * Time.deltaTime));
        if(transform.localEulerAngles.z < 270) {
            transform.Rotate(0, 0, 0);
            transform.position = new Vector3(transform.position.x, GROUND_Y, transform.position.z);
            isDieing = false;
            GameObject.Find("GameManager").GetComponent<GameManager>().EndGameOver();
            return;
        }

        // swing
        if(swingToggle) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        } else {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
        swingToggle = !swingToggle;
    }
}
