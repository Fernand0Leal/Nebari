using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BonsaiManager : MonoBehaviour
{
    public float bonsaiHealth = 100f;
    private float maxHealth = 200; 
    public Slider healthSlider; 
    public int counter = 60;
    
    

    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(GameTimer());
    }



    private IEnumerator GameTimer()
    {

            
            while (counter > 0)
            {
                yield return new WaitForSeconds (1);
                counter --;
            }

            GameClear();
           
    }

    void GameClear()
    {

        print ("Congrats");
    
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(transform.position, -transform.up, Time.deltaTime * 30f);
        healthSlider.value = bonsaiHealth; 

        if (bonsaiHealth >= maxHealth)
        {
            bonsaiHealth = maxHealth; 
        }        

        if(bonsaiHealth <= 0)
        {
            print("gameOver");
        }
    }

    
    

}
