using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isMoving;
    public float moveSpeed = 5;
    public Vector2 input;
    private Animator anim;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;


    private void Awake(){
        anim = GetComponent<Animator>();
    }

    public void HandleUpdate(){
        if(!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0) input.y =0;

            if(input!= Vector2.zero){
                anim.SetFloat("moveX", input.x);
                anim.SetFloat("moveY", input.y);

                var targetpos = transform.position;
                targetpos.x += input.x;
                targetpos.y += input.y;
                if(IsWalkable(targetpos)){
                    StartCoroutine(Move(targetpos));
                }
            }            
        }

        anim.SetBool("isMoving", isMoving);

        if(Input.GetKeyDown(KeyCode.E)){
            interact();
        }
        
    }

    IEnumerator Move(Vector3 targetPos){
        isMoving = true;
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position,targetPos,moveSpeed*Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos){
       if(Physics2D.OverlapCircle(targetPos,0.1f,solidObjectsLayer)!= null||Physics2D.OverlapCircle(targetPos,0.1f,interactableLayer)!= null){
        return false;
       }
       return true;
    }

    void interact(){
        var facingDir = new Vector3(anim.GetFloat("moveX"),anim.GetFloat("moveY"));
        var interactPos = transform.position+facingDir;

        //Debug.DrawLine(transform.position, interactPos, Color.red, 1f);
        var collider = Physics2D.OverlapCircle(interactPos,0.2f,interactableLayer);
        if(collider != null){
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

}











