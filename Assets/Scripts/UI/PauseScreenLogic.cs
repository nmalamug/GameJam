using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenLogic : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseScreen;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if escape key is pressed, and pauses or unpauses game. 
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!gameIsPaused){
                pauseGame();
            }else{
                unpauseGame();
            }
        }
    }
    
    public void goToMenu(){
        //Sets the speed of the game back to normal then quits. 
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void pauseGame(){
        //If the game isn't paused, pauses the game by setting speed to 0. 
        if(!gameIsPaused){
            gameIsPaused = true;
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
    }
    
    public void unpauseGame(){
        //Sets game speed back to normal and unpauses game. 
        Time.timeScale = 1;
        gameIsPaused = false;
        pauseScreen.SetActive(false);
    }
}
