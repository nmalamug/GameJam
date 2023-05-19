using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsLogic : MonoBehaviour
{
    public Toggle invertControls;
    public Slider volumeControl;

    private const string InvertControls = "InvertControls";
    private const string VolumeControl = "VolumeControl";

    // Start is called before the first frame update
    void Start()
    {
        //Set an initial state for the checkbox
        //PlayerPrefs saves to an external file. 
        //PlayerPrefs can save ints, floats, and strings. 
        if(PlayerPrefs.GetInt(InvertControls, 0) > 0){
            invertControls.isOn = true;
        }else{
            invertControls.isOn = false;
        }

        //Set initial state for the slider
        volumeControl.value = PlayerPrefs.GetFloat(VolumeControl, .75f);
    }

    public void onInvertToggle(){
        if(invertControls.isOn){
            //If the setting is on, then turn off
            PlayerPrefs.SetInt(InvertControls, 1);
        }else{
            //If off then turn on
            PlayerPrefs.SetInt(InvertControls, 0);
        }
    }

    public void onVolumeChange(){
        PlayerPrefs.SetFloat(VolumeControl, volumeControl.value); 
    }

    public void startMenu(){
        SceneManager.LoadScene("MainMenu");
        //Debug.Log(PlayerPrefs.GetFloat(VolumeControl, .75f));
    }
}