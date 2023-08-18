using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] GameObject objetivo;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(objetivo == null){return;}
        else{transform.position = new Vector3(0, 25, objetivo.transform.position.z + 5);}
    }
}
