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
    public float maxHealth = 5; 
    private readonly float minHealth = -5;
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

        if (healthB._FillRateValue >= maxHealth)
        {
           healthB._FillRateValue = maxHealth; 
        }        

        if(healthB._FillRateValue <= -5f)
        {
            healthB._FillRateValue = minHealth;
           
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

   

    public void SceneLoader()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }

    
    

}
