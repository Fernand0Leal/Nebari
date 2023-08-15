using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    public Material objectMaterial;
    private Tween healthG;
    private Tween healthL;

    

    public bool canStartLosingHealth = false;
    private bool allowHealthBarUpdate = true;

    // Start is called before the first frame update
    void Start()
    {
       
        objectMaterial.SetFloat("_Frac", 1.0f);
        
    }

    public float GetFracValue()
{
    return objectMaterial.GetFloat("_Frac");
}

    public void ChangeValue(bool increase)
    {
        if (!allowHealthBarUpdate || !canStartLosingHealth)
        {
            return;
        }

        if (increase)
        {
            if (healthG != null && healthG.IsActive())
            {
                healthG.Kill();
            }

            float targetFrac = objectMaterial.GetFloat("_Frac") + 0.1f; // Set the target value

            healthG = DOTween.To(() => objectMaterial.GetFloat("_Frac"), x => objectMaterial.SetFloat("_Frac", x), targetFrac, 1f);
        }
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

        
        float targetFrac2 = objectMaterial.GetFloat("_Frac") - 0.3f; // Set the target fill rate value

            // Use DOTween to lerp the fill rate value over a specified duration
            healthL = DOTween.To(() => objectMaterial.GetFloat("_Frac"), x => objectMaterial.SetFloat("_Frac", x), targetFrac2, 1f);
            
          
        }
        
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

        healthL = DOTween.To(() => objectMaterial.GetFloat("_Frac"), x => objectMaterial.SetFloat("_Frac", x), -0.1f, 20f)
            .OnComplete(() =>
            {
                if (canStartLosingHealth)
                {
                    StartContinuousHealthReduction();
                }
            });
    }

    public void StopContinuousHealthReduction()
    {
        if (healthL != null && healthL.IsActive())
        {
            healthL.Kill();
        }
    }
}

 