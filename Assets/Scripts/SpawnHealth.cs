using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpawnHealth : MonoBehaviour
{

    public BonsaiManager bManager;
    public GameObject sHealth; 
    private float scaleUp = 1.5f; 
    private Vector3 currentScale;
    private Coroutine healthLoss;

     public BugsSpawner bSpawner; 

      private Tween transformTween; 
    private Tween healthL; 
   
    

    // Start is called before the first frame update
    void Start()
    {
        
        bManager = FindObjectOfType<BonsaiManager>();
        bSpawner = FindObjectOfType<BugsSpawner>();
        currentScale =  new Vector3(this.transform.localScale.x,this.transform.localScale.y,this.transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {
    
        // if(this.transform.localScale.x > 5f && this.transform.localScale.y > 5f)
        // {
        //     print("growing");
   
        // }

        if(bManager.winPanel.activeInHierarchy)
        {
            Destroy(this.GetComponent<Collider>());
        }
        if(bManager.losePanel.activeInHierarchy)
        {
            Destroy(this.GetComponent<Collider>());
        }

         if (this.transform == null)
        {
            DOTween.Clear(true);
        }

       
     
    }

    void OnMouseDown(){

      

    
      transformTween = transform.DOScale(currentScale * scaleUp, 1.0f)
            .SetEase(Ease.InBounce)
            //.SetDelay(1.0f)
            .OnComplete(()=>
            {

                if(transformTween != null && transformTween.IsActive())
                {
                // transformTween.Kill();
                GameObject objectToDestroy = this.gameObject; 
                bSpawner.DestroyPrefab(objectToDestroy);
                }
                
                
               
            });

       healthLoss = StartCoroutine (HealthLossTimer());

    
    }

    private IEnumerator HealthLossTimer()
    {
 
       healthL =  bManager.healthSlider.DOValue(bManager.bonsaiHealth - 10,1f)
        .OnComplete(()=> {
            if(healthL != null && healthL.IsActive())
            {
                healthL.Kill();
            }
            bManager.bonsaiHealth = bManager.healthSlider.value;
            
        });
        yield return null;
        

        Debug.Log ("health" +  bManager.healthSlider.value);
 
    }

    
}
