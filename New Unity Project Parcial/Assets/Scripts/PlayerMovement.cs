using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed= 30f;
    public float gravity = -9.81f;
    public float jumpHeight = -3f;
    float cont=0;

    public Transform groundCheck;
    public float groundDstance = 0.4f;
    public LayerMask groundMask;
    AudioSource audiosource;


    Vector3 velocity;


    

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        audiosource= GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        isGrounded= Physics.CheckSphere(groundCheck.position, groundDstance,groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y =-2f;
        }   


        float x= Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(isGrounded && move.x !=0 && move.z !=0  && audiosource.isPlaying == false){

            audiosource.volume= Random.Range(0.8f,1f);
            audiosource.pitch= Random.Range(0.8f,1.1f);
            audiosource.Play();
            cont=0;
        }
        
        else if(cont==100){
            audiosource.Pause();
        }
        cont++;


        controller.Move(move* speed* Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y=Mathf.Sqrt(jumpHeight * -2 - gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }
}
