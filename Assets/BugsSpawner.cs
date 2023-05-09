using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BugsSpawner : MonoBehaviour
{
     public float respwanTime;
     public float curTime;
     public Transform bonsaiP; 
     public float localScale = 0.5f;
     public float maxScale = 15f;
     

    [SerializeField]
    public Transform[] spawns;

    [SerializeField]
    public GameObject[] objects;
 
    
    // Start is called before the first frame update
    void Start()
    {
        
        curTime = 0f;

        

        
    }

    
    // Update is called once per frame
    void Update()
    {

        curTime +=Time.deltaTime;
        if (curTime>respwanTime)
        {
            SpawnObjects( objects, spawns );
            curTime = 0f; 
        }
        
    }


    void SpawnObjects( GameObject[] gameObjects, Transform[] locations, bool allowOverlap = true )
     {
         List<GameObject> remainingGameObjects = new List<GameObject>( gameObjects );
         List<Transform> freeLocations        = new List<Transform>( locations );
 
         if( locations.Length < gameObjects.Length )
             Debug.LogWarning( allowOverlap  ? "There are more gameObjects than locations. Some objects will overlap." : "There are not enough locations for all the gameObjects. Some won't spawn.");
 
         while( remainingGameObjects.Count > 0 )
         {
             if( freeLocations.Count == 0 )
             {
                 if( allowOverlap ) freeLocations.AddRange( locations );
                 else               break ;
             }
 
             int gameObjectIndex = Random.Range( 0, remainingGameObjects.Count );
             int locationIndex   = Random.Range( 0, freeLocations.Count );
             GameObject go = Instantiate(gameObjects[gameObjectIndex], locations[locationIndex].position, Quaternion.identity, bonsaiP) ;
             remainingGameObjects.RemoveAt( gameObjectIndex );
             freeLocations.RemoveAt( locationIndex );

             
             go.transform.localScale = new Vector3 (localScale, localScale, localScale);
            go.transform.DOScale(15f, 20f);

            //   
            //     .SetEase(Ease.OutBounce);
        
         }
    }

    public void SpawnObjectsTransform()
    {
        if (localScale < maxScale)
        {
            

        }

        
      
       
        

    }
}
