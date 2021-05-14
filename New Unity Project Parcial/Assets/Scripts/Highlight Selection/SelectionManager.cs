using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    ShowMousePosition pointer;
    public int modi; //indicates the button index 1=borrar, 2=mover, 3=color.
    public int pared; //-1 inactive, 0 column, 1 wall 
    public bool moving;
    Vector3 mOffset;

    //For choosing walls or columns color
    public FlexibleColorPicker fcp;
    public Material material;

    public Color externalColor;
    private Color internalColor;
    public Color Before;

    
    public void operation(RaycastHit hit)
    {
        if (hit.transform.gameObject.tag != "Selectable")
        {
            
            
            return;
        }
        switch (modi)
        {
            case 11:     //abrir explorador de archivos
                string path = EditorUtility.OpenFilePanel("Elige tu obra: ", "", "png");
                
                if (path != null)
                {
                    WWW www = new WWW("file:///" + path);

                    //hit.transform.gameObject.GetComponent<Principal>().image = www.texture;
                    hit.transform.GetChild(2).gameObject.GetComponent<Renderer>().material.mainTexture = www.texture;

                    hit.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.mainTexture = www.texture;
                    hit.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = false;
                }
                    hit.transform.GetChild(3).gameObject.tag="WithImage"; 
                
                break;
            case 12:
                
                Debug.Log("Help");
                Texture temp= hit.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.mainTexture;
                //if (hit.transform.GetChild(1).gameObject.GetComponent<Renderer>().materials == null)
                if (hit.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled == true)
                {
                    Debug.Log("Changing to 1 child");
                    hit.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = false;
                    hit.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled = true;
                }
                else
                {
                    
                    {
                        Debug.Log("Changing to 2 child");
                        
                        hit.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled = false;
                        hit.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled = true;
                    }
                }
                break;

            case 13:     //abrir explorador de archivos para decripcion
                string path2 = EditorUtility.OpenFilePanel("Elige tu descripcion: ", "", "txt");
                
                if (path2 != null)
                {
                    StreamReader reader = new StreamReader(path2); 
                    hit.transform.GetChild(3).gameObject.GetComponent<IndexFrame>().description=reader.ReadToEnd(); 
                    reader.Close();

                }   
                break; 

            case 1:     //borrar
                Destroy(hit.transform.gameObject);
                break;
            case 2:     //mover
                moving = true;
                //hit.transform.gameObject.GetComponent<DragObjects>().enabled = true;
                break;
            case 3:     //color-size
                // code block
                break;
            default:
                // code block
                break;
        }
    }
    public void highlight()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                operation(hit);
            }
            
            defaultMaterial = hit.transform.GetComponent<Renderer>().material;

            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                }

                _selection = selection;
            }

        }
    }
    void changeColor()
    {
        
        GameObject[] walls;
        if (pared==1)
        {
            walls = GameObject.FindGameObjectsWithTag("Wall");
        }
        else if (pared == 0)
        {
            walls = GameObject.FindGameObjectsWithTag("Columns");
        }
        else
        {
            return;
        }

        if (walls.Length != 0)
        {
            Before=walls[0].transform.parent.gameObject.GetComponent<Renderer>().material.color;
        }

        /*if (internalColor != externalColor)
        {
            fcp.color = externalColor;
            internalColor = externalColor;
        }*/
                        //fcp.color = Before;
        foreach (GameObject wall in walls)
        {
            wall.transform.parent.gameObject.GetComponent<Renderer>().material.color = fcp.color;
        }
        //apply color of this script to the FCP whenever it is changed by the user
        

        //extract color from the FCP and apply it to the object material
        
    }

    void Update()
    {
        if (!isOverUI())
            highlight();
        changeColor();
        
    }
    void Start()
    {
        pointer = GetComponent<ShowMousePosition>();
        moving = false;
        pared =-1;
        internalColor = externalColor;
        
    }
    public bool isOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
