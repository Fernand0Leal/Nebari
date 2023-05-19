using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BonsaiManager : MonoBehaviour
{
    public float bonsaiHealth = 100f;
    public Slider healthSlider; 

    // private bool lerpinghealth = false; 
    // private float timeScale = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(transform.position, -transform.up, Time.deltaTime * 30f);
        healthSlider.value = bonsaiHealth; 
        
    }
    
    // public void SetHealth (float health)
    // {
    //     bonsaiHealth = health;
    //     timeScale = 0;

    //     // if(!lerpinghealth)
    //     //     StartCoroutine(LerpHealth());


    // }
    // private IEnumerator LerpHealth()
    // {
    //     float speed = 2;
    //     float startHealth = healthSlider.value;

    //     lerpinghealth = true; 

    //     while(timeScale < 1)
    //     {
    //         timeScale += Time.deltaTime * speed;
    //         healthSlider.value = Mathf.Lerp(startHealth, bonsaiHealth, timeScale);
    //     }
    //     lerpinghealth = false; 
    // }
}
