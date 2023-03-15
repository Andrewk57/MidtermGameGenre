using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathScreen : MonoBehaviour
{
    public GameObject DeathScreen;
    // Start is called before the first frame update
    void Start()
    {
        
        DeathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (swordsmanWalking.hp <= 0)
        {
            AudioListener.volume = 0f;
            Time.timeScale = 0f;
            DeathScreen.SetActive(true);
        }
        else
        {
            
            DeathScreen.SetActive(false);
        }
    }
    
}
