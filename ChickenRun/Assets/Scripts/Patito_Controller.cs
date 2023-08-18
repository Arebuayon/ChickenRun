using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patito_Controller : MonoBehaviour
{
    private int carril;
    private int lateral;

    [SerializeField] TMPro.TMP_Text scoreText;

    private int score = 0;

    private Vector3 posicionObjetivo;

    [SerializeField] float velocidad;

    int posicionZ;
    
    [SerializeField] float distanciaRay = 3f;


    [SerializeField] Mundo_Controller mundo;
    
    
    void Start()
    {
        
    }

    void Update()
    {   
        
        actualizarPosicion();
        if(Input.GetKeyDown(KeyCode.W)){
            Avanzar();
            Debug.Log("Hola Mundo!");
        }else if (Input.GetKeyDown(KeyCode.S)){
            Retroceder();
        }else if (Input.GetKeyDown(KeyCode.D)){
            MoverLados(2);
        }else if (Input.GetKeyDown(KeyCode.A)){
            MoverLados(-2);
        }
        
    }

    public void actualizarPosicion(){
        posicionObjetivo = new Vector3(lateral,0 ,posicionZ);
        transform.position = Vector3.Lerp(transform.position , posicionObjetivo, velocidad * Time.deltaTime);
    }
    public void MoverLados(int cuanto)
    {   
        
        if(cuanto > 0){
            gameObject.transform.eulerAngles = new Vector3(0,90,0);
            if(HayObstaculo()){return;}
            }
        else{
            gameObject.transform.eulerAngles = new Vector3(0,-90,0);
            if(HayObstaculo()){return;}
        }
        lateral += cuanto;
        lateral = Mathf.Clamp(lateral, -20 , 20);
    }

    public void Avanzar(){
        gameObject.transform.eulerAngles = new Vector3(0,0,0);
        if(HayObstaculo()){return;}
        posicionZ+=2;
        if(posicionZ > carril){
            carril = posicionZ;
            score++;
            scoreText.text = score.ToString();
            mundo.CrearPiso();
            mundo.CrearObstaculos();
        }
    }

    public void Retroceder(){
        
        gameObject.transform.eulerAngles = new Vector3(0,180,0);
        if(HayObstaculo()){return;}
        if(posicionZ > carril-3){
            posicionZ-=2;
        }
    }

    public bool HayObstaculo(){
        Vector3 adelante = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(transform.position.x,distanciaRay, transform.position.z),adelante);
        if(Physics.Raycast (ray, out hit, distanciaRay) && hit.transform.tag == "Obstaculo"){
            return true;
        }
        else{return false;}
    }
}
