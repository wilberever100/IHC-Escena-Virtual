using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{

    GameObject source;
    public Texture[] textures;
    public int currentTexture;
    



    void Awake()
    {
        source = GameObject.Find("ImageSelected");
       GetComponent<Renderer>().material.mainTexture=source.GetComponent<Renderer>().material.mainTexture;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
        currentTexture++;
        currentTexture %=textures.Length;
        GetComponent<Renderer>().material.mainTexture = textures[currentTexture];
        }
    }
}
