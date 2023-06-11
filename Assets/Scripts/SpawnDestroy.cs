using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SpawnDestroy : MonoBehaviour
{

    public BonsaiManager bManager; 
    public GameObject sDestroy; 
    public int spawnDamage;
    private float scaleUp = 1.5f; 
    private Vector3 currentScale;
    private Coroutine healthT;
   
   

   

    // Start is called before the first frame update
    void Start()
    {
        
        bManager = FindObjectOfType<BonsaiManager>();
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

          if (this.transform == null)
        {
            DOTween.Clear(true);
        }
        

        

    

    }

    Tween _tweener; 

    void OnMouseDown(){

        Debug.Log("hello");

       
        if (_tweener != null) 
        {
            _tweener.Kill(); 
        }

        
        _tweener = transform.DOScale(currentScale * scaleUp, 1.0f)
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
            Debug.Log("ScaleBug3");
            bManager.healthSlider.DOValue(bManager.bonsaiHealth + 5,1f)
                .OnComplete(()=> {
                 bManager.bonsaiHealth = bManager.healthSlider.value;
                
                 });
        yield return null;
        
        
        
    }

    void DestroySpawn()
    {

        _tweener.Kill();
       
       // Destroy(this.gameObject);
        
    }


}

