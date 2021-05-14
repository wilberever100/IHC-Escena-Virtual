using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Selection : MonoBehaviour{

        Vector3 targetRot;
        Vector3 currentAngle;
        int currentSelection;
        int totalCharacters=3;

    // Start is called before the first frame update
    void Start()
    {
        currentSelection=2;         
        
    }
  
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("a") && currentSelection<totalCharacters){
            currentAngle=transform.eulerAngles;
            targetRot=targetRot+new Vector3(0,90,0);
            currentSelection++;

        }
            currentAngle=transform.eulerAngles;
        if(Input.GetKeyDown("d") && currentSelection>1){
            targetRot=targetRot-new Vector3(0,90,0);
            currentSelection--;

        }

        currentAngle=new Vector3(0,Mathf.LerpAngle(currentAngle.y,targetRot.y,2.0f*Time.deltaTime),0);
        transform.eulerAngles=currentAngle;

        if(Input.GetMouseButtonUp(0)){
            SceneManager.LoadScene("Scenes/Diseño Escenario");
        }
    }
}
