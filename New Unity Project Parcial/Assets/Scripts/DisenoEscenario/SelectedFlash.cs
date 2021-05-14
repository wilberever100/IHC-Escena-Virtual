using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public GameObject selectedObject;
    public int redCol;
    public int blueCol;
    public int greenCol;
    public bool lookintAtObject = false;
    public bool flashingIn = true;
    public bool startedFlashing = false;
    public Color32 lastColor;

    void Update()
    {
        if(lookintAtObject==true)
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
    }
    void OnMouseOver()
    {
        selectedObject = GameObject.Find(CastingToObjects.selectedObject);
        lookintAtObject = true;
        
        if (startedFlashing == false)
        {
            lastColor = selectedObject.GetComponent<Renderer>().material.color;
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
    }
    void OnMouseExit()
    {
        startedFlashing = false;
        lookintAtObject = false;
        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = lastColor;
    }
    IEnumerator FlashObject()
    {
        while (lookintAtObject == true)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn == true)
            {
                if(blueCol <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    blueCol -= 25;
                    greenCol -= 1;
                }
            }
            if (flashingIn == false)
            {
                if (blueCol >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    blueCol += 25;
                    greenCol += 1;
                }
            }
            
        }
    }
}
