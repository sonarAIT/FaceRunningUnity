using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("ConfigScene");
        }
    }
}
