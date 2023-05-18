using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenLogic : MonoBehaviour
{
    private bool gameIsPaused = false;
    public GameObject pauseScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!gameIsPaused){
                pauseGame();
            }else{
                unpauseGame();
            }
        }
    }
    
    public void goToMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void pauseGame(){
        if(!gameIsPaused){
            gameIsPaused = true;
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
    }
    
    public void unpauseGame(){
        Time.timeScale = 1;
        gameIsPaused = false;
        pauseScreen.SetActive(false);
    }
}
