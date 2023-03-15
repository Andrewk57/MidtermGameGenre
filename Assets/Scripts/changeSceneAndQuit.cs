using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneAndQuit : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool isPaused = false;
    private void Start()
    {
        PauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseGame();
        }
    }
    public void ChangeScene(string sceneName)
    {
        swordsmanWalking.hp = 5f;
        AudioListener.volume = 1f;
        placementScript.money = 50;
        SceneManager.LoadScene(sceneName);
    }
    public void QuitG()
    {
        Application.Quit(); 
    }
    public void pauseGame()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);
        if (isPaused)
        {
            Time.timeScale = 0f;
            AudioListener.volume = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.volume = 1f;
        }

    }
}
