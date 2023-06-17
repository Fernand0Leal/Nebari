using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    private float scaleUp = -1.5f; 
    private Vector3 currentScale;
    
   

   
    // Start is called before the first frame update
    void OnMouseDown(){

        Sequence s= DOTween.Sequence();
        

    
       s.Append(transform.DOMove(new Vector3(0.3f,-2,-2), 2f));
       
       s.Join(transform.DOScale(currentScale * scaleUp, 3f));
       s.SetEase(Ease.InBounce)
       .OnComplete(()=>
            {
                
                
                SceneManager.LoadScene(1);
                DOTween.Clear(true);
                  
               
            });

     
    
    }
}
