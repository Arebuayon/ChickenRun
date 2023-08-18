using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animales_Controller : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] GameObject explosion;

    [SerializeField] GameObject death;

    
    void Start()
    {
        
    }

    void Update()
    {   
        float z = transform.position.z;
        Mathf.Clamp(z, -50 , 50);
        transform.Translate(0,0,velocidad*Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag =="Limite"){
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Player"){
            Vector3 posicion = other.gameObject.transform.position;
            Quaternion rotacion = other.gameObject.transform.rotation;
            other.gameObject.SetActive(false);
            Instantiate(explosion, posicion, rotacion);
            Instantiate(death, posicion, rotacion);
        }
    }
}
