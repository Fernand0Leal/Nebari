using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class SpawnDestroy : MonoBehaviour
{

    public BonsaiManager bManager; 
    public int spawnDamage;
    private float scaleUp = 1.5f; 
    private Vector3 currentScale;
    private Coroutine healthT;

   

    // Start is called before the first frame update
    void Start()
    {
        bManager = FindObjectOfType<BonsaiManager>();
        currentScale =  new Vector3(this.transform.localScale.x,this.transform.localScale.y,this.transform.localScale.z);
        
  
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localScale.x > 5f  && this.transform.localScale.y > 5f) 
        {
            print("growing");
        
            bManager.bonsaiHealth -= spawnDamage*Time.deltaTime; 

        }

        if(bManager.winPanel.activeInHierarchy)
        {
            spawnDamage = 0;
            Destroy(this.GetComponent<Collider>());
        }
        if(bManager.losePanel.activeInHierarchy)
        {
            spawnDamage = 0;
            Destroy(this.GetComponent<Collider>());
        }
        

        

    

    }

    

    void OnMouseDown(){

        transform.DOScale(currentScale * scaleUp, 1.0f)
            .SetEase(Ease.InBounce)
            //.SetDelay(1.0f)
            .OnComplete(()=>
            {
                DestroySpawn();
            });
         
        

       healthT = StartCoroutine (HealthTimer());

            

    }

    private IEnumerator HealthTimer()
    {

        bManager.healthSlider.DOValue(bManager.bonsaiHealth + 5,1f)
        .OnComplete(()=> bManager.bonsaiHealth = bManager.healthSlider.value );
        yield return null;
        
    }

    void DestroySpawn()
    {
        Destroy(this.gameObject);

    }

    
}
