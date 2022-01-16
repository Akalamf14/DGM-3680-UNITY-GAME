using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehaviour : MonoBehaviour
{
    bool paused = false;
    public GameObject pauseMenu;
    
    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            pauseMenu.SetActive(paused);

            if(paused)
            {
                Time.timeScale = 0;
               

            }
            else
            {
                ResumeGame();
            }
        
        }
    }
    
    public void ResumeGame()
	{
		Time.timeScale = 1;
	}
	
}
