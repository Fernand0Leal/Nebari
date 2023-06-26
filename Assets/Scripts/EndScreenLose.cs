using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenWin : MonoBehaviour
{
     private float scaleUp = -1.5f; 
    private Vector3 currentScale;
    
   

   
    // Start is called before the first frame update
    void OnMouseDown(){

        Sequence l= DOTween.Sequence();
        

    
       l.Append(transform.DOMove(new Vector3(0.3f,-2,-2), 2f));
       
       l.Join(transform.DOScale(currentScale * scaleUp, 3f));
       l.SetEase(Ease.InBounce)
       .OnComplete(()=>
            {
                
                
                SceneManager.LoadScene(1);
                DOTween.Clear(true);
                  
               
            });

     
    
    }
}
