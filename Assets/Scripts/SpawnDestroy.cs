using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SpawnDestroy : MonoBehaviour, IPointerDownHandler
{

    public BonsaiManager bManager;
    public BugsSpawner bSpawner; 
    public HealthBar healthB;
    
   
    // public float spawnDamage;

    //private Vector3 currentScale;
    // private Coroutine healthT;
    
    private Tween transformTween; 
    // private Tween healthL; 
   
   

   

    // Start is called before the first frame update
    void Start()
    {
        
        bManager = FindObjectOfType<BonsaiManager>();
        bSpawner = FindObjectOfType<BugsSpawner>();
        healthB = FindObjectOfType<HealthBar>();
        //currentScale =  new Vector3(this.transform.localScale.x,this.transform.localScale.y,this.transform.localScale.z);
        // StartTweens();
  
    }



    // Update is called once per frame
    void Update()
    {

             // Only check the scale condition when the health bar is not losing health
        if (this.transform.localScale.x > 0.6f && this.transform.localScale.y > 0.6f)
        {
            if (!healthB.canStartLosingHealth)
            {
                healthB.canStartLosingHealth = true;
                healthB.StartContinuousHealthReduction(); // Start continuous health reduction
            }
        }
        else
        {
            if (healthB.canStartLosingHealth)
            {
                healthB.canStartLosingHealth = false;
                healthB.StopContinuousHealthReduction(); // Stop continuous health reduction
            }
        }
        
       

        if(bManager.winPanel.activeInHierarchy)
        {
            // spawnDamage = 0;
            Destroy(this.GetComponent<Collider>());
        }
        if(bManager.losePanel.activeInHierarchy)
        {
            // spawnDamage = 0;
            Destroy(this.GetComponent<Collider>());
        }

        

        else if (gameObject == null)
        {
           if (DOTween.TotalPlayingTweens() > 0)
            {
            DOTween.Clear(true);
            }
        }

        // else if (healthB._FillRateValue >= bManager.maxHealth)
        // {
        //     DOTween.KillAll();
        // }        

        else if(healthB.GetFracValue()  <= 0)
        {
             DOTween.Clear(true);
        }

        if(bManager.winPanel.activeInHierarchy)
        {
            // spawnDamage = 0;
            Destroy(this.GetComponent<Collider>());
        }
        if(bManager.losePanel.activeInHierarchy)
        {
            // spawnDamage = 0;
            Destroy(this.GetComponent<Collider>());
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        healthB.ChangeValue(true);

         
        transformTween = transform.DOScale(new Vector3(0,0,0), 1.0f)
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
        
    
    }

    void OnDestroy()
    {
        // Stop continuous health reduction when the object is destroyed
        if (healthB != null)
        {
            healthB.StopContinuousHealthReduction();
        }
    }

        
        
    




}

