using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescripcionObra : MonoBehaviour
{
    public string descActual;
    public GameObject player;
    public GameObject output;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetButtonDown("Jump") ){
            Debug.Log("Se presiono space");
            player.GetComponent<PlayerMovement>().enabled =true;
            player.transform.GetChild(0).GetComponent<MouseLook>().enabled =true;
            player.GetComponent<AudioSource>().enabled =true;
            output.gameObject.SetActive(false);
            Cursor.lockState= CursorLockMode.Locked;

        }
    }
}
