using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement;

public class BonsaiManager : MonoBehaviour
{
    public float bonsaiHealth = 100f;
    public float rotAmount = 30f;
    private float maxHealth = 200; 
    private float minHealth = 0;
    public Slider healthSlider; 
    public int counter = 60;
    public TextMeshProUGUI timeText;  
    public GameObject winPanel;
    public GameObject losePanel; 
    public GameObject gameManager;

    private Coroutine gameTimer; 

    
    
    
    

    // Start is called before the first frame update
    void Start()
    {
       gameTimer = StartCoroutine(GameTimer());
        
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
         DOTween.Clear();
        StopCoroutine(gameTimer);
        winPanel.SetActive(true);
        print ("Congrats");
        Destroy(gameManager);
        rotAmount = 15f;
        
    
        
    
    }
    void GameOver()
    {
        
         DOTween.Clear();
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
        healthSlider.value = bonsaiHealth; 

        if (bonsaiHealth >= maxHealth)
        {
            bonsaiHealth = maxHealth; 
        }        

        if(bonsaiHealth <= 0)
        {
            bonsaiHealth = minHealth;
           
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
