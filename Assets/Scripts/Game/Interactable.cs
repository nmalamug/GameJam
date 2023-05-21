using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public HashSet<int> isInRange = new HashSet<int>();
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public UnityEvent echoReset;
    public UnityEvent levelReset;
    public UnityEvent playerMove;
    public Vector3Int gridPosition;
    public GameLogic gameLogic;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void onInteract(int id){
        if(isInRange.Contains(id)){
            interactAction.Invoke();
        }
    }

    public void onEchoReset(){
        echoReset.Invoke();
    }

    public void onLevelReset(){
        levelReset.Invoke();
    }

    public void onPlayerMove(){
        playerMove.Invoke();
    }

    public void snapToGrid(){
        transform.parent.position = gameLogic.getScreenPosition(gridPosition);
        transform.position = gameLogic.getScreenPosition(gridPosition);
    
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange.Add(0);
            Debug.Log("Player is in Range ");
        }
        if(collision.gameObject.CompareTag("Echo")){
            Echo temp = collision.gameObject.GetComponent<Echo>();
            isInRange.Add(temp.id);
            Debug.Log("Echo in Range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player"))
        {
            isInRange.Remove(0);
            Debug.Log("Player is not in Range ");
        }
        if(collision.gameObject.CompareTag("Echo")){
            Echo temp = collision.gameObject.GetComponent<Echo>();
            isInRange.Remove(temp.id);
            Debug.Log("Echo not in Range");
        }
    }
}

