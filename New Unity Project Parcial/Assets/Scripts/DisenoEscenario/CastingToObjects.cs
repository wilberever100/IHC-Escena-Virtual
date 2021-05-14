using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingToObjects : MonoBehaviour
{
    public static string selectedObject;
    public string internalObject;
    public RaycastHit theObject;
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out theObject)){
            selectedObject = theObject.transform.gameObject.name;
            internalObject = theObject.transform.gameObject.name;
        }
        
    }
}
