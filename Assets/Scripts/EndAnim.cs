using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EndAnim : MonoBehaviour
{

 
    // Start is called before the first frame update
    void Start()
    {

        transform.DORotate(new Vector3 (5,5, 0), 1f, RotateMode.FastBeyond360)
        .SetLoops(-1,LoopType.Yoyo)
        .SetRelative()
        .SetEase(Ease.Linear);

        
    }

   
}
