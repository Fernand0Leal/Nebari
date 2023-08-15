using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement;

public class BonsaiManager : MonoBehaviour
{
    
    public float rotAmount = 30f;
    public float maxHealth = 100f; 
    private readonly float minHealth = 0f;
    // public Slider healthSlider; 
    public int counter = 60;
    public TextMeshProUGUI timeText;  
    public GameObject winPanel;
    public GameObject losePanel; 
    public GameObject gameManager;

    private Coroutine gameTimer; 

    public HealthBar healthB;

    

    
    
    
    

    // Start is called before the first frame update
    void Start()
    {
     
       gameTimer = StartCoroutine(GameTimer());
       healthB.canStartLosingHealth = true;
        
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
         DOTween.Clear(true);
        StopCoroutine(gameTimer);
        winPanel.SetActive(true);
        print ("Congrats");
        Destroy(gameManager);
        rotAmount = 15f;
        
    
        
    
    }
    void GameOver()
    {
        
         //DOTween.Clear(true);
        StopCoroutine(gameTimer);
        losePanel.SetActive(true);
        Destroy(gameManager);
        rotAmount = 15f;
         
       

    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = counter + "".ToString();

        
        transform.RotateAround(transform.position, -transform.up, Time.deltaTime * rotAmount);
        // healthSlider.value = bonsaiHealth; 

        float fracValue = healthB.GetFracValue();

        

        if (fracValue  >= maxHealth)
        {
           fracValue  = maxHealth; 
        }        

        if(fracValue  <= 0f)
        {
            fracValue  = minHealth;
           
            print("gameOver");
            GameOver();
        }

        if (winPanel.activeInHierarchy)
        {
            losePanel.SetActive(false);
        }
        if (losePanel.activeInHierarchy)
        {
            winPanel.SetActive(false);
        }

        

   

    


    
    

}
}
