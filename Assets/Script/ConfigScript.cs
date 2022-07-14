using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigScript : MonoBehaviour
{
    public void GoTitleScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

    public void GoWindowSizeConfigScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WindowSizeConfigScene");
    }

    public void GoOperationExplanationScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OperationExplanationScene");
    }

    public void GoConfigScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ConfigScene");
    }
}
