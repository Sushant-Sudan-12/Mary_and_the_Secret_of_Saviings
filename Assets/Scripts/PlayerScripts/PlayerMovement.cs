using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isMoving;
    public float moveSpeed = 5;
    public Vector2 input;
    private Animator anim;

    private void Awake(){
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(!isMoving){
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            if(input.x != 0) input.y =0;

            if(input!= Vector2.zero){
                anim.SetFloat("moveX", input.x);
                anim.SetFloat("moveY", input.y);

                var targetpos = transform.position;
                targetpos.x += input.x;
                targetpos.y += input.y;

                StartCoroutine(Move(targetpos));
            }
            
        }

        anim.SetBool("isMoving", isMoving);

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
}











