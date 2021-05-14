using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelected : MonoBehaviour
{
    // Start is called before the first frame update
    public static ImageSelected imageSelected;
    void Awake(){
        if( imageSelected==null){
            imageSelected=this;
            DontDestroyOnLoad(gameObject);
        }
        else if(imageSelected!=this){
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
