using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthBar : MonoBehaviour

    {
    public float _FillRateValue = 6f; //progress bar starts full
    public Material objectMaterial;

    float healthLoss = 0.3f; //progress is done by this value
    
    private Tween healthG;
    private Tween healthL;

    public bool canStartLosingHealth = false;
    private bool allowHealthBarUpdate = true;

    public BonsaiManager bManager;
    
    // Start is called before the first frame update
    void Start()
    {
        bManager = FindObjectOfType<BonsaiManager>();
        
        objectMaterial.SetFloat("_FillRate", _FillRateValue); //initial value is set 

        
       

    }

  

                                        
    public void ChangeValue(bool increase) //enables changing the value of progress bar
    {              
        Debug.Log("ChangeValue");                     //if increase param is true, the progress bar progresses otherwise it deprogresses
        
        if (!allowHealthBarUpdate || !canStartLosingHealth)
        {
            return;
        }
        
        
        if (increase)
        {

            if(healthG != null && healthG.IsActive())
                     {
                       healthG.Kill();
                       
                     }

           float targetFillRate = _FillRateValue + 3f; // Set the target fill rate value

            // Use DOTween to lerp the fill rate value over a specified duration
             healthG = DOTween.To(() => _FillRateValue, x => _FillRateValue = x, targetFillRate, 1f)
            .OnUpdate(() =>
            {
                objectMaterial.SetFloat("_FillRate", _FillRateValue); // Update the material's fill rate
            });
          
        }
        else
        {
            _FillRateValue -= healthLoss*Time.deltaTime; //progress decreased
        }
            objectMaterial.SetFloat("_FillRate", _FillRateValue); //Update the value of the progress bar
    }

    public void ChangeValue2(bool decrease)
    {

        if (!allowHealthBarUpdate || !canStartLosingHealth)
        {
            return;
        }
        if(decrease)
        {
            if(healthL != null && healthL.IsActive())
                     {
                       healthL.Kill();
                       
                     }

        
        float targetFillRate2 = _FillRateValue - 1.5f; // Set the target fill rate value

            // Use DOTween to lerp the fill rate value over a specified duration
            healthL = DOTween.To(() => _FillRateValue, x => _FillRateValue = x, targetFillRate2, 1f)
            .OnUpdate(() =>
            {
                objectMaterial.SetFloat("_FillRate", _FillRateValue); // Update the material's fill rate
            });
          
        }
        else
        {
            
        }
            objectMaterial.SetFloat("_FillRate", _FillRateValue); //Update the value of the progress bar
    }

    public void SetHealthBarUpdate(bool allowUpdate)
    {
        allowHealthBarUpdate = allowUpdate;
    }

    public void StartContinuousHealthReduction()
    {
        if (!allowHealthBarUpdate || !canStartLosingHealth)
        {
            return;
        }

        // Reduce health value continuously while the condition is met
        healthL = DOTween.To(() => _FillRateValue, x => _FillRateValue = x, -6f, 10f)
            .OnUpdate(() =>
            {
                objectMaterial.SetFloat("_FillRate", _FillRateValue);
            })
            .OnComplete(() =>
            {
                if (canStartLosingHealth) // Check again in case the condition changed
                {
                    StartContinuousHealthReduction(); // Call the method again for continuous reduction
                }
            });
    }

    // Method to stop the continuous health reduction
    public void StopContinuousHealthReduction()
    {
        if (healthL != null && healthL.IsActive())
        {
            healthL.Kill();
        }
    }
    }
