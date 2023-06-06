using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public void quitGame()
    {
        SceneManager.LoadScene(0);//whatever you called the scene for the main menu. You can find it in the build settings.
    }

    public void resumeGame(GameObject Player) {
        Player.SetActive(true);
    }
}
