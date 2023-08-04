using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class EndScreenWin : MonoBehaviour, IPointerDownHandler
{
     public float scaleUp = -1.5f; 
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
       
        

        Debug.Log("Pointer Down!");

        Sequence s = DOTween.Sequence();

        s.Append(transform.DOMove(new Vector3(0.3f, -2, -2), 2f));
       

        s.Join(transform.DOScale(currentScale * scaleUp, 3f));
        s.SetEase(Ease.InBounce)
         .OnComplete(() =>
         {
             // Delay scene loading by 0.5 seconds
             DOVirtual.DelayedCall(0.5f, () =>
             {
                

                 SceneManager.LoadScene(1);
             });
             DOTween.Clear(true);
         });
    }
}
