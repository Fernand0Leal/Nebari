using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BonsaiManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.DORotate(new Vector3 (0, -360f, 0), 15.0f, RotateMode.FastBeyond360)
        // .SetLoops(-1, LoopType.Restart)
        // .SetRelative()
        // .SetEase(Ease.Linear);
        transform.RotateAround(transform.position, -transform.up, Time.deltaTime * 40f);
        
    }
}
