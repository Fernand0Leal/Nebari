using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BugsSpawner : MonoBehaviour, IPointerClickHandler
{
     public float respwanTime;
     public float curTime;
     public Transform bonsaiP; 
     public float localScale = 0.1f;
     private GameObject go;

     public Ray ray;
     public RaycastHit hit;
     

     public List<GameObject> remainingGameObjects = new List<GameObject>();
     public List<Transform> freeLocations        = new List<Transform>();
  
     

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
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);    

        curTime +=Time.deltaTime;
        if (curTime>respwanTime)
        {
            SpawnObjects( objects, spawns );
            curTime = 0f; 
        }

         // Ray will be sent out from where your mouse is located    
         
        if(Physics.Raycast(ray,out hit, 1000.0f) && Input.GetMouseButtonDown (0)) // On left click we send down a ray
         {
             Destroy (hit.collider.gameObject); // Destroy what we hit
         }
     
        
    }


    public void SpawnObjects( GameObject[] gameObjects, Transform[] locations, bool allowOverlap = true )
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

             
             }
              
     
    
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
           if (Input.GetMouseButtonDown(0))
        {
            Destroy(go) ;
             
        
      
       
        }
       
       
    }

}
