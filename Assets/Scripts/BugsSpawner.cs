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
     //private float curTime = 0f;
     public Transform bonsaiP; 
     public float spawnScale = 0.25f;


     public Tween oScale;

  
    [SerializeField]
    public List<Transform> spawns;

    [SerializeField]
    public List <GameObject> objects;

    private Dictionary<GameObject, Transform> spawnedObjects;

    void Start()
    {
        spawnedObjects = new Dictionary<GameObject, Transform>();
        StartCoroutine(SpawnObjectsCoroutine());
    }

    

    IEnumerator SpawnObjectsCoroutine()
    {
        Debug.Log("SpawnObjectsCoroutine started");

        yield return new WaitForSeconds(4f);

        while (true)
        {
            // Randomly select a spawn location
        int locationIndex = Random.Range(0, spawns.Count);
        Transform spawnLocation = spawns[locationIndex];

        spawns.RemoveAt(locationIndex);

        // Randomly select an object prefab
        int prefabIndex = Random.Range(0, objects.Count);
        GameObject selectedPrefab = objects[prefabIndex];

        // Spawn the object
        GameObject spawnedObject = Instantiate(selectedPrefab, spawnLocation.position, spawnLocation.rotation, bonsaiP);

        // Move the ScaleSpawn method call here
        // ScaleSpawn(spawnedObject);

        spawnedObjects.Add(spawnedObject, spawnLocation);

        spawnedObject.transform.localScale = new Vector3(spawnScale, spawnScale, spawnScale);
        Debug.Log("Spawned Object Scale: " + spawnedObject.transform.localScale);

        if (spawnedObject!= null )
        {
            oScale = spawnedObject.transform.DOScale(1f, 4f);
            Debug.Log("Scale Tween Started: " + oScale);
        }

        yield return new WaitForSeconds(respwanTime);
        }
    }
    public void ScaleSpawn(GameObject spawnedObject)
    {
        Debug.Log("ScaleSpawn called");
        
    }
 
    
    
    
    

    public void DestroyPrefab(GameObject objectToDestroy)
    {
        if (spawnedObjects.ContainsKey(objectToDestroy))
        {
            // Retrieve the spawn location of the object
            Transform spawnLocation = spawnedObjects[objectToDestroy];

            // Remove the object from the spawned objects dictionary
            spawnedObjects.Remove(objectToDestroy);

            if (objectToDestroy.transform != null )
        {
            objectToDestroy.transform.DOKill(); // Kill the active tween
        }
             

            // Destroy the object
            Destroy(objectToDestroy);
           
            if(oScale != null && oScale.IsActive())
                {
                //oScale.Kill();
                }

            if(spawnLocation != null)
                {
                spawns.Add(spawnLocation);
                }
            
        }
        else
        {
            Debug.LogError("The specified object does not exist or was not spawned by this spawner.");
        }

    }
}



    
  

    



