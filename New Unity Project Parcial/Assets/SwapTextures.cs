using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTextures : MonoBehaviour
{
    public GameObject source;
    public int vali;
    public Texture[] textures;
    public int currentTexture;


    void Awake()
    {
        source = GameObject.Find("ImageSelected");
       GetComponent<Renderer>().materials[1].mainTexture=source.GetComponent<Renderer>().material.mainTexture;
         if(vali==1){
            GetComponent<Renderer>().materials[0].mainTexture = source.GetComponent<Renderer>().material.mainTexture;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
        currentTexture++;
        currentTexture %=textures.Length;
        GetComponent<Renderer>().materials[1].mainTexture = textures[currentTexture];
        if(vali==1){
            GetComponent<Renderer>().materials[0].mainTexture = textures[currentTexture];
        }
        }
    }
}

