using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animator;
            int cont=0;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking= animator.GetBool("isWalking");
        bool isJumping= animator.GetBool("isJumping");
        bool JumpPressed= Input.GetButtonDown("Jump");
        bool forwardPressed = Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d")|| Input.GetKey("a");
    if(!isJumping && JumpPressed){
          animator.SetBool("isJumping",true);
          cont=0;

     }
     cont++;
      if(isJumping && cont==40){
          animator.SetBool("isJumping",false);
     }
    
    
    
     if(!isWalking && forwardPressed){

         animator.SetBool("isWalking",true);
     }

     if(isWalking && !forwardPressed){
         animator.SetBool("isWalking",false);
     }

     /*if(!isJumping && (forwardPressed && JumpPressed)){
          animator.SetBool("isJumping",true);
     }
      if(!isJumping && (forwardPressed || JumpPressed)){
          animator.SetBool("isJumping",false);
     }
    */

    
       
    }
}
