using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Worldposition;
        Worldposition= Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Worldposition.z = 1;
        transform.position = Worldposition;
    }
}
