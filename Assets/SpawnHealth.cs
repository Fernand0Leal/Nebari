using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpawnHealth : MonoBehaviour
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
   
        }
     
    }

    void OnMouseDown(){

        transform.DOScale(0.05f, 5f)
        .OnComplete(()=> Destroy(this.gameObject));

        StartCoroutine (HealthLossTimer());

    }

    private IEnumerator HealthLossTimer()
    {
 
        bManager.healthSlider.DOValue(bManager.bonsaiHealth - 10,1f)
        .OnComplete(()=> bManager.bonsaiHealth = bManager.healthSlider.value );
        yield return null;

        Debug.Log ("health" +  bManager.healthSlider.value);
 
    }
}
