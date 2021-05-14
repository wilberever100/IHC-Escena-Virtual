using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReadInputDescription : MonoBehaviour
{
    public string input;
    public GameObject player;
    public GameObject cuadroactual;
    public  GameObject descr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string s){
        input=s;
        Debug.Log(input);
        cuadroactual.GetComponent<IndexFrame>().description=input;
        

        
        player.GetComponent<PlayerMovement>().enabled =true;
        player.transform.GetChild(0).GetComponent<MouseLook>().enabled =true;
        player.GetComponent<AudioSource>().enabled =true;
        descr.gameObject.SetActive(false);
        Cursor.lockState= CursorLockMode.Locked;



    }
}
