using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detroyer : MonoBehaviour
{
    [SerializeField] GameObject objetivo;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Limite"){
            Destroy(other.gameObject,10f);
        }else{Destroy(other.gameObject);}
        
    }

        void FixedUpdate()
    {   
        if(objetivo == null){return;}
        else{transform.position = new Vector3(0,0 , objetivo.transform.position.z - 110);}
    }
     
     }