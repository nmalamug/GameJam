using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBallMovement : MonoBehaviour
{
    public float xvel;
    public float yvel;
    public float speed;
    bool up, down, left, right;
    private int invertControls;
    
    // Start is called before the first frame update
    void Start()
    {
        up = false;
        down = false;
        left = false;
        right = false;
        xvel = 0;
        yvel = 0;

        //Implement the setting for Inverting Controls Here
        if(PlayerPrefs.GetInt("InvertControls", 1) > 0){
            invertControls= -1;
        }else{
            invertControls = 1;
        }
        speed *= invertControls;
    }  

    // Update is called once per frame
    void Update()
    {
        getKeyInputs();
    }

    void FixedUpdate(){
        updateVelocity();
    }

    private void getKeyInputs(){
        //Take in inputs, set a flag to determine which keys are pressed. 
        if(Input.GetKeyDown(KeyCode.W)){
            up = true;
        }
        if(Input.GetKeyUp(KeyCode.W)){
            up = false;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            left = true;
        }
        if(Input.GetKeyUp(KeyCode.A)){
            left = false;
        }
        if(Input.GetKeyDown(KeyCode.S)){
            down = true;
        }
        if(Input.GetKeyUp(KeyCode.S)){
            down = false;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            right = true;
        }
        if(Input.GetKeyUp(KeyCode.D)){
            right = false;
        }
    }

    private void updateVelocity(){
        //Sets the speed of the ball depending on direction of motion.
        if(right){
            xvel =  speed;//*Time.deltaTime;
        }
        if(left){
            xvel = -speed;//*Time.deltaTime;
        }
        if(up){
            yvel = speed;//*Time.deltaTime;
        }
        if(down){
            yvel = -speed;//*Time.deltaTime;
        }

        //Calculate new position based on velocity
        transform.position = transform.position + new Vector3(xvel,yvel,0);
        
        //Decelerate the player character. 
        if(xvel > 0){
            xvel -= (float).5;
        }else if(xvel < 0){
            xvel += (float).5;
        }
        if(yvel > 0){
            yvel -= (float).5;
        }else if(yvel < 0){
            yvel += (float).5;
        }
        
        if(Mathf.Abs(xvel) <= .01){
            xvel = 0;
        }
        if(Mathf.Abs(yvel) <= .01){
            yvel = 0;
        }
        
    }
}
