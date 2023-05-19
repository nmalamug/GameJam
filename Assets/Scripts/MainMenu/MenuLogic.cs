using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
//hi
//hi!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame(){
        //Starts the game. 
        //When using LoadSceneMode.Additive, you can load multiple scenes at once. 
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("uiScene", LoadSceneMode.Additive);
    }

    public void startSettings(){
        SceneManager.LoadScene("SettingsScene");
    }
}
