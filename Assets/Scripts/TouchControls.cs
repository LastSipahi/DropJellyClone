using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping = false;
    public Transform objectToMove;
    const float moveSpeed = 4f;
    public bool GamePaused;
    GamePlayManager gamePlayManager;

    private void Start()
    {
        gamePlayManager = GetComponent<GamePlayManager>();
    }
    void Update()
    {
        if(objectToMove!=null && GamePaused==false)
        { 
            if (Input.GetMouseButtonDown(0)) //works fine with both mouse and touch as long as single touch intended.
            {
                startTouchPosition = Input.mousePosition;
                isSwiping = true;
            }

            if (Input.GetMouseButton(0) && isSwiping)
            {
                Vector2 currentTouchPosition = Input.mousePosition;
                float deltaX = currentTouchPosition.x - startTouchPosition.x;
                objectToMove.position += new Vector3(deltaX * moveSpeed * Time.deltaTime, 0, 0);
                objectToMove.position = new Vector3(Mathf.Clamp(objectToMove.position.x,0f, 4f), objectToMove.position.y, objectToMove.position.z);
                startTouchPosition = currentTouchPosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isSwiping = false;
                objectToMove.position = new Vector3(Mathf.RoundToInt(objectToMove.position.x), objectToMove.position.y, objectToMove.position.z);
                gamePlayManager.SendPieceToPosition(objectToMove);
                objectToMove = null;
            }
        }
    }

    
}
