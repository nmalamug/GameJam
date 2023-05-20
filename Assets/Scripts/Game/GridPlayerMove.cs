using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridPlayerMove : MonoBehaviour
{
    public GameLogic gameLogic;
    public List<Action> actions = new List<Action>();
    public Vector3Int gridPosition;
    public Vector3Int startingPosition = new Vector3Int(0,0,0);
    public EchoManager echoManager;

    private Rigidbody2D rigid;
    private Vector2 movementInput;
    private bool timeToUpdate;


    [SerializeField]
    private float speed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.timeScale!= 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && gameLogic.isAdjacentInteractable(gridPosition)){
                actions.Add(new Action(Action.ActionType.Interact, gridPosition));
            }
            else if (Input.GetKeyDown(KeyCode.Q) && echoManager.canCreateEcho()) {
            echoReset();
            }

        }
        if (timeToUpdate) {
            timeToUpdate = false;
            updateSurroundings();
        }

    }

    private void FixedUpdate()
    {
        rigid.velocity = movementInput * speed;
        timeToUpdate = true;
    }

    private void OnMove(InputValue inputVal)
    {
        movementInput = inputVal.Get<Vector2>();
    }

    public void updateSurroundings(){
        gameLogic.updateSurroundings();
        echoManager.updateEchos();
    }

    public void echoReset(){
        echoManager.createEcho(startingPosition, actions);
        echoManager.resetEchos();
        actions = new List<Action>();
        gridPosition = startingPosition;
    }
}
