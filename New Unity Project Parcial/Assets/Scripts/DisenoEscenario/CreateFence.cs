using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateFence : MonoBehaviour
{
    bool creating;
    ShowMousePosition pointer;
    public GameObject polePrefab;
    public GameObject fencePrefab;
    GameObject lastPole;
    // Start is called before the first frame update
    void Start()
    {
        pointer = GetComponent<ShowMousePosition>();
    }

    void getInput()
    {
        if (!enabled) return;
        if (Input.GetMouseButtonDown(0))
        {
            startFence();
        }else if(Input.GetMouseButtonUp(0)){
            setFence();
        }
        else
        {
            if (creating)
            {
                updateFence();
            }
        }
    }

    void startFence()
    {
        creating=true;
        Vector3 startPos = pointer.getWorldPoint();
        startPos = pointer.snapPosition(startPos);
        GameObject startPole = Instantiate(polePrefab, startPos, Quaternion.identity);
        startPole.transform.position = new Vector3(startPos.x, startPos.y+0.3f, startPos.z) ;
        lastPole = startPole;
    }
    void setFence()
    {
        creating = false;
    }
    void updateFence()
    {
        Vector3 current = pointer.getWorldPoint();
        current = pointer.snapPosition(current);
        current = new Vector3(current.x, current.y + 0.3f, current.z);
        if (!current.Equals(lastPole.transform.position))
        {
            createFenceSegment(current);
        }
    }

    void createFenceSegment(Vector3 current)
    {
       
        GameObject newPole = Instantiate(polePrefab, current, Quaternion.identity);
        Vector3 middle = Vector3.Lerp(newPole.transform.position, lastPole.transform.position, 0.5f);
        GameObject newFence = Instantiate(fencePrefab, middle, Quaternion.identity);
        newFence.transform.LookAt(lastPole.transform);
        lastPole = newPole;
        GameObject[] Col = GameObject.FindGameObjectsWithTag("Columns");
        lastPole.GetComponent<Renderer>().material.color= Col[0].transform.parent.gameObject.GetComponent<Renderer>().material.color;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        newFence.GetComponent<Renderer>().material.color = walls[0].transform.parent.gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOverUI())
            getInput();
    }
    public bool isOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
