using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;

    private bool isWalking;
    private void Update() {
        Vector2 inputVector = new Vector2(0,0);
        if (Input.GetKey(KeyCode.W)){
            inputVector.y = +1;
        }
         if (Input.GetKey(KeyCode.S)){
            inputVector.y = -1;
        }
         if (Input.GetKey(KeyCode.A)){
            inputVector.x = -1;
        }
         if (Input.GetKey(KeyCode.D)){
            inputVector.x = +1;
        }
        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x,0f,inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius, moveDir,moveDistance);

        if(!canMove){
            Vector3 moveDirX = new Vector3(moveDir.x,0,0);
            canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius, moveDirX,moveDistance);
            
        if (canMove){
         moveDir = moveDirX;
        }
        else {
            Vector3 moveDirZ = new Vector3(0,0,moveDir.z);
            canMove = canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerHeight,playerRadius, moveDirZ,moveDistance);
            if (canMove){
                moveDir = moveDirZ;
            } else{

            }
        }
        }
        if (canMove){
            transform.position += moveDir * moveDistance;
        }
        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }
        public bool IsWalking(){
            return isWalking;
        }
        
      
    
}
