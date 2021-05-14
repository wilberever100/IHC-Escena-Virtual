using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFence : MonoBehaviour
{
    public float lifeTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destruction()
    {
        Destroy(this.gameObject);
    }
}
