using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CamSwitch : MonoBehaviour
{

    public GameObject player;
    public GameObject cam;
    public GameObject canvas;
    public GameObject esfera;
    public GameObject plano;
    public Texture[] pisos;
    public int current_cam;
    Color BeforeColorCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void darkerColumn()
    {
        GameObject[] Walls = GameObject.FindGameObjectsWithTag("Wall");
        Color wallColor = Walls[0].transform.parent.gameObject.GetComponent<Renderer>().material.color;
        
        int amount = 10;
        Color color = new Color(wallColor.r * 0.8f, wallColor.g * 0.8f, wallColor.b * 0.8f);

        GameObject[] Columns = GameObject.FindGameObjectsWithTag("Columns");
        BeforeColorCol = Columns[0].transform.parent.gameObject.GetComponent<Renderer>().material.color; //Guarda el color normal de la Columna
        foreach (GameObject Column in Columns)
        {
            Column.transform.parent.gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
    void normalColorColumn()
    {
        GameObject[] Columns = GameObject.FindGameObjectsWithTag("Columns");
        foreach (GameObject Column in Columns)
        {
            Column.transform.parent.gameObject.GetComponent<Renderer>().material.color = BeforeColorCol;
        }
    }
    public void configPresenter()
    {
        plano.GetComponent<Renderer>().material.mainTexture=pisos[1];
        darkerColumn();
        player.SetActive(true);
        cam.SetActive(false);
        canvas.SetActive(false);
        esfera.SetActive(false);
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Selectable");


        foreach (GameObject wall in walls)
        {
            wall.tag = "WallsFirstPerson";
            if (wall.layer == LayerMask.NameToLayer("Ignore Raycast"))
            {
                wall.layer = LayerMask.NameToLayer("Default");
            }
        }

        foreach (GameObject wall in walls)
        {

            if (wall.transform.GetChild(0).gameObject.tag == "Wall")
            {
                //wall.transform.GetChild(3).GetComponent<IndexFrame>().description = " ";
                wall.transform.GetChild(3).GetComponent<IndexFrame>().numberofFrames = 4;
                //Debug.Log(wall.transform.GetChild(4).gameObject.name);
                //Debug.Log(wall.transform.GetChild(5).gameObject.name);
                //wall.transform.GetChild(4).gameObject.SetActive(true);
                //wall.transform.GetChild(5).gameObject.SetActive(true);
                if (wall.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled == true && wall.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled == false)
                {
                    wall.transform.GetChild(4).gameObject.SetActive(true);
                    wall.transform.GetChild(6).gameObject.SetActive(true);
                }
                else if (wall.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled == true && wall.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled == false)
                {
                    wall.transform.GetChild(5).gameObject.SetActive(true);
                    wall.transform.GetChild(7).gameObject.SetActive(true);
                }
                wall.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame = 1;
            }
        }
    }
    public void configEditor()
    {
        plano.GetComponent<Renderer>().material.mainTexture=pisos[0];
        normalColorColumn();
        player.SetActive(false);
        cam.SetActive(true);
        canvas.SetActive(true);
        esfera.SetActive(true);
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Selectable");

        foreach (GameObject wall in walls)
        {
            wall.tag = "WallsFirstPerson";
            if (wall.layer == LayerMask.NameToLayer("Default"))
            {
                wall.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
        }

        foreach (GameObject wall in walls)
        {

            if (wall.transform.GetChild(0).gameObject.tag == "Wall")
            {
                wall.transform.GetChild(3).GetComponent<IndexFrame>().description = " ";
                wall.transform.GetChild(3).GetComponent<IndexFrame>().numberofFrames = 4;
                //Debug.Log(wall.transform.GetChild(4).gameObject.name);
                //Debug.Log(wall.transform.GetChild(5).gameObject.name);
                //wall.transform.GetChild(4).gameObject.SetActive(true);
                //wall.transform.GetChild(5).gameObject.SetActive(true);
                if (wall.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled == false && wall.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled == true)
                {
                    wall.transform.GetChild(4).gameObject.SetActive(false);
                    wall.transform.GetChild(6).gameObject.SetActive(false);
                }
                else if (wall.transform.GetChild(2).gameObject.GetComponent<Renderer>().enabled == false && wall.transform.GetChild(1).gameObject.GetComponent<Renderer>().enabled == true)
                {
                    wall.transform.GetChild(5).gameObject.SetActive(false);
                    wall.transform.GetChild(7).gameObject.SetActive(false);
                }
                wall.transform.GetChild(3).GetComponent<IndexFrame>().currentFrame = 1;
            }
        }
    }
// Update is called once per frame
void Update()
    {

        if(Input.GetButtonDown("1Key")){

            configPresenter();
           
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene(0);

        }

    }
}
