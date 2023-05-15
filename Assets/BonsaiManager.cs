using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BonsaiManager : MonoBehaviour
{
    public float bonsaiHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(transform.position, -transform.up, Time.deltaTime * 30f);
        
    }
}
