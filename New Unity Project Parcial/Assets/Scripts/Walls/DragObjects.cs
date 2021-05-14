using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    ShowMousePosition pointer1;
    public Vector3 mOffset;
    public GameObject Selection;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    void OnMouseDown()
    {
        /*int x=Selection.GetComponent<SelectionManager>().modi;
        if (x != 2)
            return;*/
        if (!enabled) return;
        this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        pointer1 = Camera.main.GetComponent<ShowMousePosition>();
        Vector3 Mouse = pointer1.getWorldPoint();
        Mouse = pointer1.snapPosition(Mouse);
       
        
        mOffset = this.transform.position - Mouse;
        /*
        mOffset.x = this.transform.position.x- pointer.mousePointer.transform.position.x;
        mOffset.y = this.transform.position.y - pointer.mousePointer.transform.position.y;
        mOffset.z = this.transform.position.z - pointer.mousePointer.transform.position.z;*/
    }
    void OnMouseDrag()
    {
        /*int x = Selection.GetComponent<SelectionManager>().modi;
        if (x != 2)
            return;*/
        if (!enabled) return;
        Vector3 Mouse = pointer1.getWorldPoint();
        Mouse = pointer1.snapPosition(Mouse);
        
        
        Mouse.y = 0;
        this.transform.position = Mouse + mOffset;
        
    }

    void OnMouseUp()
    {
        /*int x = Selection.GetComponent<SelectionManager>().modi;
        if (x != 2)
            return;*/
        if (!enabled) return;
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }
    public Vector3 snapPosition(Vector3 original)
    {
        Vector3 snapped;
        snapped.x = Mathf.Floor(original.x + 0.5f);
        snapped.y = Mathf.Floor(original.y + 0.5f);
        snapped.z = Mathf.Floor(original.z + 0.5f);
        return snapped;
    }
}
