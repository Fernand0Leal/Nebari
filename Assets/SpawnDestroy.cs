using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnDestroy : MonoBehaviour
{

    public BugsSpawner bSpawn; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    void OnMouseDown(){

        transform.DOScale(0.05f, 5f)
        .OnComplete(()=> Destroy(this.gameObject));


    }
}
