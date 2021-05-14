using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    public Image imageSelector;

    public void PickableBallColor(bool isSelect){
        if(isSelect){

            imageSelector.color=Color.green;
        }
        else{
            imageSelector.color= Color.white;
        }

        
    }


    public void OcultarCursor(bool ocultar){
        imageSelector.enabled = !ocultar;
    }
}
