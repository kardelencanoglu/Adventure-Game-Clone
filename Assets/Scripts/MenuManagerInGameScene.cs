using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerInGameScene : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton()
    {
        if (Time.timeScale == 1) 
        {
            Time.timeScale = 0;
        }
       else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void RePlayButton()
    {

    }

    public void HomeButton()
    {

    }
}
