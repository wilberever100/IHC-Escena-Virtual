using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public GameObject fuente;
    public GameObject objetivo;
    public GameObject descr;
    public GameObject output;
    public GameObject player;
    public InputField este;
    public bool vali;

    float xRotation= 0f;
    // Start is called before the first frame update


    void Awake(){
        objetivo = GameObject.Find("ImageSelected");
    }

    void Start()
    {        
            
            Cursor.lockState= CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX= Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -=mouseY;
        xRotation = Mathf.Clamp(xRotation, -0f,90f);

        transform.localRotation= Quaternion.Euler(xRotation,0f,0f);

        playerBody.Rotate(Vector3.up * mouseX);

        /*RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 100f)){
            if(hit.collider.gameObject.layer== LayerMask.NameToLayer("Default")){
                if(hit.collider.gameObject.tag=="WallsFirstPerson"){
                    if(hit.transform.GetChild(3).gameObject.tag=="WithImage"){
                        //objetivo.GetComponent<Renderer>().material.mainTexture=fuente.GetComponent<Renderer>().materials[1].mainTexture;
                        hit.collider.gameObject.GetComponent<Renderer>().material.color=Color.green;
                    }                                         
                }

            }
            else{
                hit.collider.gameObject.GetComponent<Renderer>().material.color=Color.gray;
            }
        }*/

        if(Input.GetKeyDown("q")){
            if(vali){
                Cursor.lockState= CursorLockMode.Locked; 
                vali=false;       
            }
            else{
                Cursor.lockState= CursorLockMode.None;
                vali=true;
            }
            
            
        }

        if(Input.GetMouseButtonUp(0)){
            Vector3 worldMousePosition=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,100f));
             Vector3 direction= worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 100f)){
                    //Debug.DrawRay(Camera.main.transform.position,hit.point, Color.green,0.5f);
                    //Debug.Log(hit.transform.name);
                    string name=hit.transform.name;
                    fuente=GameObject.Find(name);

                    if(hit.transform.gameObject.tag== "WallsFirstPerson"){
                        if(hit.transform.name != "Plane"){
                            if(hit.transform.GetChild(0).gameObject.tag=="Wall"){
                                if(hit.transform.GetChild(3).gameObject.tag=="WithImage"){
                                    Debug.Log(hit.transform.GetChild(4).gameObject.name);

                                    //Cambia de marco

                                    if(hit.transform.GetChild(4).gameObject.activeInHierarchy){

                                        if (hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 0){
                                            hit.transform.GetChild(4).GetComponent<Renderer>().material= hit.transform.GetChild(3).GetComponent<IndexFrame>().materials[0];
                                        }
                                        else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 1){
                                            hit.transform.GetChild(4).GetComponent<Renderer>().material= hit.transform.GetChild(1).GetComponent<Renderer>().material;                                        
                                        }
                                        else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 2){
                                            hit.transform.GetChild(4).GetComponent<Renderer>().material= hit.transform.GetChild(3).GetComponent<IndexFrame>().materials[0];
                                            hit.transform.GetChild(4).GetComponent<Renderer>().material.mainTexture= hit.transform.GetChild(1).GetComponent<Renderer>().material.mainTexture;                                        
                                        }
                                        else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 3){
                                            hit.transform.GetChild(4).GetComponent<Renderer>().material= hit.transform.GetChild(3).GetComponent<IndexFrame>().materials[1];                                 
                                        }
                                        else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 4){
                                            hit.transform.GetChild(4).GetComponent<Renderer>().material= hit.transform.GetChild(3).GetComponent<IndexFrame>().materials[2];                                 
                                        }

                                    }
                                    else {
                                        if (hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 0){
                                            hit.transform.GetChild(5).GetComponent<Renderer>().material= hit.transform.GetChild(3).GetComponent<IndexFrame>().materials[0];
                                        }
                                        else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 1){
                                            hit.transform.GetChild(5).GetComponent<Renderer>().material= hit.transform.GetChild(2).GetComponent<Renderer>().material;                                            
                                        }
                                        else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 2){
                                            hit.transform.GetChild(5).GetComponent<Renderer>().material= hit.transform.GetChild(3).GetComponent<IndexFrame>().materials[0];
                                            hit.transform.GetChild(5).GetComponent<Renderer>().material.mainTexture= hit.transform.GetChild(2).GetComponent<Renderer>().material.mainTexture;                                        
                                        }
                                        else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 3){
                                            hit.transform.GetChild(5).GetComponent<Renderer>().material= hit.transform.GetChild(3).GetComponent<IndexFrame>().materials[1];
                                            hit.transform.GetChild(5).GetComponent<Renderer>().material.mainTexture= hit.transform.GetChild(3).GetComponent<IndexFrame>().textura;                                
                                        }
                                        else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame == 4){
                                            hit.transform.GetChild(5).GetComponent<Renderer>().material= hit.transform.GetChild(3).GetComponent<IndexFrame>().materials[2];
                                            hit.transform.GetChild(5).GetComponent<Renderer>().material.mainTexture= hit.transform.GetChild(3).GetComponent<IndexFrame>().textura;                                 
                                        }

                                    }
                                    hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame +=1;
                                    hit.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame %=hit.transform.GetChild(3).GetComponent<IndexFrame>().numberofFrames;




                                }                                         
                        }
                     }
                    }
                        /*else{
                            objetivo.GetComponent<Renderer>().material.mainTexture=fuente.GetComponent<Renderer>().material.mainTexture;
                        }*/
                    

            }
            else{
                 Debug.DrawRay(Camera.main.transform.position,worldMousePosition, Color.red,0.5f);
            }

        }
        if(Input.GetMouseButtonUp(1)){
            Vector3 worldMousePosition=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,100f));
             Vector3 direction= worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 100f)){
                 if(hit.transform.gameObject.tag== "WallsFirstPerson"){
                        if(hit.transform.name != "Plane"){
                            if(hit.transform.GetChild(0).gameObject.tag=="Wall"){
                                if(hit.transform.GetChild(3).gameObject.tag=="WithImage"){
                                    

                                    if(hit.transform.GetChild(3).GetComponent<IndexFrame>().description == " "){
                                        //este.text=hit.transform.GetChild(3).gameObject.GetComponent<IndexFrame>().description; ---->para editar el texto
                                        este.text="";
                                        Cursor.lockState= CursorLockMode.None;                                   
                                        player.GetComponent<PlayerMovement>().enabled =false;
                                        player.GetComponent<AudioSource>().enabled =false;
                                        player.transform.GetChild(0).GetComponent<MouseLook>().enabled =false;                                        
                                        player.transform.GetChild(0).GetComponent<ReadInputDescription>().cuadroactual= hit.transform.GetChild(3).gameObject;                                        
                                        descr.gameObject.SetActive(true);                                     

                                       
                                    }
                                    else if(hit.transform.GetChild(3).GetComponent<IndexFrame>().description != " "){    
                                        Cursor.lockState= CursorLockMode.None;                                   
                                         player.GetComponent<PlayerMovement>().enabled =false;
                                         player.GetComponent<AudioSource>().enabled =false;
                                        player.transform.GetChild(0).GetComponent<MouseLook>().enabled =false;                                   
                                        player.transform.GetChild(0).GetComponent<ShowText>().descActual= hit.transform.GetChild(3).GetComponent<IndexFrame>().description;
                                        output.gameObject.SetActive(true);

                                        
                                        //player.transform.GetChild(0).GetComponent<ReadInputDescription>().cuadroactual= hit.transform.GetChild(3).gameObject;





                                    }
                                }
                            }
                        }
                 }
            }
        }


        
    }
}
