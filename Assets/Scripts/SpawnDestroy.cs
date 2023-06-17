using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SpawnDestroy : MonoBehaviour
{

    public BonsaiManager bManager;
    public BugsSpawner bSpawner; 
    
   
    public int spawnDamage;
    //private float scaleUp = 1.5f; 
    private Vector3 currentScale;
    private Coroutine healthT;
    
    private Tween transformTween; 
    private Tween healthL; 
   
   

   

    // Start is called before the first frame update
    void Start()
    {
        
        bManager = FindObjectOfType<BonsaiManager>();
        bSpawner = FindObjectOfType<BugsSpawner>();
        currentScale =  new Vector3(this.transform.localScale.x,this.transform.localScale.y,this.transform.localScale.z);
        // StartTweens();
  
    }



    // Update is called once per frame
    void Update()
    {
        
        if(this.transform.localScale.x > 5f  && this.transform.localScale.y > 5f) 
        {
         
        
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

        

          if (gameObject == null)
        {
           if (DOTween.TotalPlayingTweens() > 0)
            {
            DOTween.Clear(true);
            }
        }

         if (bManager.bonsaiHealth >= bManager.maxHealth)
        {
            DOTween.KillAll();
        }        

        if(bManager.bonsaiHealth <= 0)
        {
            DOTween.KillAll();
        }
        

        

    

    }


  
    
    

    void OnMouseDown(){

         

        
        transformTween = transform.DOScale(new Vector3(0,0,0), 1.0f)
        .SetEase(Ease.InBounce)
                 //.SetDelay(1.0f)
                 .OnComplete(()=>
                {
                    if(transformTween != null && transformTween.IsActive())
                    {
                        
                    transformTween.Kill();
                    GameObject objectToDestroy = this.gameObject; 
                    bSpawner.DestroyPrefab(objectToDestroy);
                    }
                    
                });
        

       healthT = StartCoroutine (HealthTimer());

            
        
    }
    
    

    private IEnumerator HealthTimer()
    {
     

            if(gameObject != null)
            {
            healthL = bManager.healthSlider.DOValue(bManager.bonsaiHealth + 5,1f)
                .OnComplete(()=> {

                    if(healthL != null && healthL.IsActive())
                     {
                       healthL.Kill();
                       
                     }
                 bManager.bonsaiHealth = bManager.healthSlider.value;
                 
                
                 });
        yield return null;
            }
        
        
        
    }




}

