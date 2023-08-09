using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndScreenLose : MonoBehaviour, IPointerDownHandler
{
    public float scaleUp = 1f; 
    private Vector3 currentScale;

    public HealthBar healthBar;

    void Start()
    {
        currentScale = transform.localScale; // Set the currentScale to the initial scale of the transform
         healthBar = FindObjectOfType<HealthBar>();
         healthBar.SetHealthBarUpdate(false); // Pause health bar updates
    }

    
   

   
    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
       
        

       
       

        transform.DOScale(currentScale * scaleUp, 2f)
        .SetEase(Ease.InBounce)
       
        
        
         .OnComplete(() =>
         {

            SceneManager.LoadScene(1);
            DOTween.Clear(true);
         });
    }
}
