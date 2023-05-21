using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGoal : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Y)){
            nextLevel();
        }
    }
    public void nextLevel(){
        Debug.Log("Called");
        Scene scene = SceneManager.GetActiveScene();
        switch(scene.name){
            case("GameScene"):
                SceneManager.LoadScene("Level01");
                SceneManager.LoadScene("uiScene", LoadSceneMode.Additive);
            break;
            case("Level01"):
                SceneManager.LoadScene("Level02");
                SceneManager.LoadScene("uiScene", LoadSceneMode.Additive);
            break;
            case("Level02"):
                SceneManager.LoadScene("Level03");
                SceneManager.LoadScene("uiScene", LoadSceneMode.Additive);
            break;
            case("Level03"):
                SceneManager.LoadScene("EndGame");
            break;
        }
        
    }
}
