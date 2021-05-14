using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonsFunction : MonoBehaviour
{
    public Camera cam;
    public Button borrar;
    public Button mover;
    public Button size;
    public int modi;
    public GameObject ColorCanvas;
    public GameObject ingresarObraCanvas;
    public GameObject PanelSettings;
    void Start()
    {
        modi = 0;
    }


    public void borrarButton()
    {
        modi = 1;
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().modi=1;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<DragObjects>().enabled = false;
        }
        ColorCanvas.gameObject.SetActive(false);
    }

    public void moverButton()
    {
        modi = 2;
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().modi = 2;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<DragObjects>().enabled = true;
        }
        ColorCanvas.gameObject.SetActive(false);
    }

    //Color change
    public void sizeButton()
    {
        modi = 3;
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().modi = 3;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<DragObjects>().enabled = false;
        }
        ColorCanvas.gameObject.SetActive(true);
    }
    public void modificarButton()
    {
        //Cuando quiero dibujar paredes:
        if (cam.GetComponent<ShowMousePosition>().enabled == false)
        {
            cam.GetComponent<ShowMousePosition>().enabled = true;
            cam.GetComponent<CreateFence>().enabled = true;
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Selectable");
            foreach (GameObject wall in walls)
            {
                wall.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
            //dissappear buttons
            mover.gameObject.SetActive(false);
            size.gameObject.SetActive(false);
            borrar.gameObject.SetActive(false);
            ColorCanvas.gameObject.SetActive(false);
            ingresarObraCanvas.gameObject.SetActive(false);

        }
        else
        {
            //Cuando quiero modificar:
            cam.GetComponent<ShowMousePosition>().enabled = false;
            cam.GetComponent<CreateFence>().enabled = false;
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Selectable");
            foreach (GameObject wall in walls)
            {
                wall.layer = LayerMask.NameToLayer("Default");
            }
            //appear buttons
            mover.gameObject.SetActive(true);
            size.gameObject.SetActive(true);
            borrar.gameObject.SetActive(true);
            ingresarObraCanvas.gameObject.SetActive(false);


            /*var placeHolders = GameObject.FindGameObjectsWithTag("Modificable");
            var buttons = new List<Button>();
            foreach (var placeHolder in placeHolders)
            {
                buttons.Add(placeHolder.GetComponent<Button>());
            }
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].interactable=true;
                // And do what ever else you want with the buttons
            }/*
            
            /*
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("Modificable");
            foreach (GameObject button in buttons)
            {

                button.SetActive(true);
            }*/
        }
        
        return;
    }
    public void paredButton()
    {
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().pared = 1;
        GameObject walls = GameObject.FindGameObjectWithTag("Wall");
        if (walls != null)
        {
            GameObject.Find("Selection Manager").GetComponent<SelectionManager>().fcp.color = walls.transform.parent.gameObject.GetComponent<Renderer>().material.color; ;
        }

    }
    public void columnaButton()
    {
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().pared = 0;
        GameObject walls = GameObject.FindGameObjectWithTag("Columns");
        if (walls != null)
        {
            GameObject.Find("Selection Manager").GetComponent<SelectionManager>().fcp.color = walls.transform.parent.gameObject.GetComponent<Renderer>().material.color; ;
        }
    }
    public void ingresarObras()
    {
        //Cuando quiero modificar:
        cam.GetComponent<ShowMousePosition>().enabled = false;
        cam.GetComponent<CreateFence>().enabled = false;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Selectable");
        foreach (GameObject wall in walls)
        {
            wall.layer = LayerMask.NameToLayer("Default");
        }
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().modi = 0;
        //dissappear buttons
        mover.gameObject.SetActive(false);
        size.gameObject.SetActive(false);
        borrar.gameObject.SetActive(false);
        ColorCanvas.gameObject.SetActive(false);
        ingresarObraCanvas.gameObject.SetActive(true);
    }


    public void cambiarLadoButton()
    {
        modi = 11;
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().modi =12;
        
    }
    public void asignarObraButton()
    {
        modi = 12;
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().modi = 11;

    }

      public void asignarDescripcionButton()
    {
        GameObject.Find("Selection Manager").GetComponent<SelectionManager>().modi = 13;

    }



    /// <summary>
    /// ------------------------------------------------CONFIGURATION PANEL------------------------------------------------------------------
    /// </summary>
    public void configButton()
    {
        bool val=PanelSettings.activeSelf;
        PanelSettings.SetActive(!val);
    }  
    public void homeButton()
    {
        SceneManager.LoadScene(0);
    }
    public void quitButton()
    {
        Application.Quit();
    }

}


/*string path;
public RawImage image;
public void OpenExplorer()
{
    path = EditorUtility.OpenFilePanel("Elige tu obra: ", "", "png");
    GetImage();
}
void GetImage()
{
    if (path != null)
    {
        UpdateImage();
    }
}
void UpdateImage()
{
    WWW www = new WWW("file:///" + path);
    image.texture = www.texture;
}*/