using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsSpawner : MonoBehaviour
{
     public float respwanTime;

    [SerializeField]
    private List <spawnPointInfo> spawnPoints = new List <spawnPointInfo>();
    [SerializeField]
    private List <objectSpawnInfo> objectsToSpawn = new List <objectSpawnInfo>();

    public float curTime;
    

    [System.Serializable]
    public struct objectSpawnInfo
    {
     public GameObject item;
    }
    [System.Serializable]
    public struct spawnPointInfo {
     public GameObject spawnPoint;
    }
    // Start is called before the first frame update
    void Start()
    {
        // foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag ("Spawn"))
        // {
        //     spawnPoints.Add(spawnPoint);
        // }

        curTime = 0f;

        
    }

    // Update is called once per frame
    void Update()
    {

        curTime +=Time.deltaTime;
        if (curTime>respwanTime)
        {
           // StartSpawn();
            curTime = 0f; 
        }
        
    }

    void StartSpawn()
    {
        // for (int i = 0; i < spawnPoints.Count; i++)
        // {
        //     if(spawnPoints[i].spawnPoint.transform)
        //     {
        //         int randomIndex = Random.Range (0, objectsToSpawn.Count);
        //         Instantiate(objectsToSpawn, spawnPoints[randomIndex].spawnPoint.transform,spawnPoint.position, spawnPoint.rotation);
        //        // Spawn();
        //     }

        // }
        
     }

    void Spawn()
    {
        
        
    }
}
