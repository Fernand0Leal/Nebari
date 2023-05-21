using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpawnDestroy : MonoBehaviour
{

    public BonsaiManager bManager; 
    public int spawnDamage;

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
        
            bManager.bonsaiHealth -= spawnDamage*Time.deltaTime; 

        }

    }

    

    void OnMouseDown(){

        transform.DOScale(0.05f, 5f)
        .OnComplete(()=> Destroy(this.gameObject));

        StartCoroutine (HealthTimer());

    }

    private IEnumerator HealthTimer()
    {

        bManager.healthSlider.DOValue(bManager.bonsaiHealth + 5,1f)
        .OnComplete(()=> bManager.bonsaiHealth = bManager.healthSlider.value );
        yield return null;
        
    }
}
