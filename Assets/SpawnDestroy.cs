using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnDestroy : MonoBehaviour
{

    public BonsaiManager bManager; 

    // Start is called before the first frame update
    void Start()
    {
        bManager = FindObjectOfType<BonsaiManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localScale.x > 5f && this.transform.localScale.y > 5f)
        {
            print("growing");
            bManager.bonsaiHealth -= Time.deltaTime;

        }
       
        
    }

    void OnMouseDown(){

        transform.DOScale(0.05f, 5f)
        .OnComplete(()=> Destroy(this.gameObject));


    }
}
