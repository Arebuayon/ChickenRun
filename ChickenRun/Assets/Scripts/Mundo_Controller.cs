using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mundo_Controller : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] List<GameObject> obstaculos;
    public float carril = 1;
    public float contador = 0;

    public float contadorObstaculos = 0;

    [SerializeField] List<GameObject> spawnpointsObstaculos;

    [SerializeField] List<GameObject> spawnpointsAnimales;

    [SerializeField] List<GameObject> animales;

    [SerializeField] GameObject spawn;


    public float distanciaObstaculo;

    public float distanciaAnimal;

    float limiteObstaculos = 1;

    float contadorAnimalesSpawn = 0;
    bool primerNivel = true;

    [SerializeField] GameObject limites;


    public void CrearObstaculos(){
        
        if((contadorObstaculos == 4) && (limiteObstaculos <= 5)){
            
            contadorObstaculos = 0;
            limiteObstaculos++;
            List<GameObject> spawnpointsObstaculoscopy = new List<GameObject>(spawnpointsObstaculos);
            for(int i=0; i<7 ; i++ ){
            CrearObstaculo(spawnpointsObstaculoscopy);
            }
            ActualizarSpawnPointsObstaculos();
        }
        else if(contadorObstaculos == 25 && limiteObstaculos > 5)
        {
            limiteObstaculos = 0;
            contadorObstaculos = 0;
            }
        else{
            
            contadorObstaculos++;
        }

    }


        public void CrearAnimal(){
            
            
                int random = Random.Range(0,spawnpointsAnimales.Count);
                GameObject spawn = spawnpointsAnimales[random];
                Vector3 posicion = spawn.transform.position;
                Quaternion rotation = spawn.transform.rotation;
                GameObject obs = Instantiate(animales[Random.Range(0,animales.Count)],posicion,rotation);
        
    }    
    
   public void CrearAnimales(){
        
        
            foreach(GameObject spawn  in spawnpointsAnimales){
            CrearAnimal();
            
            }
        }

    public void ActualizarSpawnPointsAnimales(){
        Debug.Log(contadorAnimalesSpawn);
        if(primerNivel && contadorAnimalesSpawn >= 21){
            primerNivel = false;
            contadorAnimalesSpawn = 0;
            spawnpointsAnimales.ForEach(objeto => objeto.transform.position = objeto.transform.position + new Vector3(0,0,distanciaAnimal));
            for (int i = 0 ; i <7 ; i++){CrearAnimal();}
            
        }
        else if(!primerNivel  && contadorAnimalesSpawn >= 9){
            contadorAnimalesSpawn = 0;
            spawnpointsAnimales.ForEach(objeto => objeto.transform.position = objeto.transform.position + new Vector3(0,0,distanciaAnimal));
            for (int i = 0 ; i <7 ; i++){CrearAnimal();}
        }

    }

    public void ActualizarLimites(){
        
            float numero = carril * 100;
            Instantiate(limites , Vector3.forward * numero, limites.transform.rotation);
    }
    public void ActualizarSpawnPointsObstaculos(){
        spawnpointsObstaculos.ForEach(objeto => objeto.transform.position = objeto.transform.position + new Vector3(0,0,distanciaObstaculo));

    }

    public void CrearObstaculo(List<GameObject>lista){
        
            
            int random = Random.Range(0,lista.Count);
            GameObject spawn = lista[random];
            lista.RemoveAt(random);
            Vector3 posicion = spawn.transform.position;
            GameObject obs = Instantiate(obstaculos[Random.Range(0,obstaculos.Count)]);
            obs.transform.position = posicion;
        

        
    }



    public void CrearPiso(){
        
        
        if(carril == 1 && contador == 17){
            float numero = carril * 109;
            Instantiate(ground , Vector3.forward * numero  , Quaternion.identity);
            contador = 0;
            ActualizarLimites();
            carril++;
            
        }
        else if(contador == 49){
            float numero = carril * 100;
            Instantiate(ground , Vector3.forward * numero  , Quaternion.identity);
            contador = 0;
            ActualizarLimites();
            carril++;
            
        }else{
            
            contador++;
            contadorAnimalesSpawn++;
           }
        
        
    

    }


    void Start()
    {
        CrearObstaculos();
        InvokeRepeating("CrearAnimal", 0.1f, 0.5f);
        InvokeRepeating("ActualizarSpawnPointsAnimales", 0.2f, 0.5f);
        
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
