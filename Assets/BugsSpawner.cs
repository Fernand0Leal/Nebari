using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

//add name space

public class BugsSpawner : MonoBehaviour
{ 
// make all variates private or private serialized or public
     public float respwanTime;
     public float curTime = 0f;
     public Transform bonsaiP; 
     public float spawnScale = 0.1f;
     private GameObject go;

  
     

    [SerializeField]
    public Transform[] spawns;

    [SerializeField]
    public GameObject[] objects;
 
    
  
    
    
    // Update is called once per frame
    void Update()
    {
       
   
     // try to use corutine instead 
     // read about async/ await 
     
        curTime +=Time.deltaTime;
        if (curTime>respwanTime)
        {
            SpawnObjects(objects, spawns);
            curTime = 0f; 
        }


   
    }


    public void SpawnObjects( GameObject[] objects, Transform[] spawns, bool allowOverlap = true )
    {
         List<GameObject> remainingGameObjects = new List<GameObject>( objects );
         List<Transform> freeLocations        = new List<Transform>( spawns );
 
         if( spawns.Length < objects.Length )
             Debug.LogWarning( allowOverlap  ? "There are more gameObjects than locations. Some objects will overlap." : "There are not enough locations for all the gameObjects. Some won't spawn.");
 
         while( remainingGameObjects.Count > 0 )
         {
             if( freeLocations.Count == 0 )
             {
                 if( allowOverlap ) freeLocations.AddRange( spawns );
                 else               break ;
             }
 
             int gameObjectIndex = Random.Range( 0, remainingGameObjects.Count );
             int locationIndex   = Random.Range( 0, freeLocations.Count );
             GameObject go = Instantiate(objects[gameObjectIndex], spawns[locationIndex].position, Quaternion.identity, bonsaiP) ;
             remainingGameObjects.RemoveAt( gameObjectIndex );
             freeLocations.RemoveAt( locationIndex );
             
             go.transform.localScale = new Vector3 (spawnScale, spawnScale, spawnScale);
             
             go.transform.DOScale(15f, 30f);

             

        
            
         }

         
              
     
    
    }



}