using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaterTankBar : MonoBehaviour
{
    public Slider slider;
    public Image emptyImage;

    public void SetMaxWater( int water)
    {
        slider.maxValue = water;
        slider.value = water;
    }

    public void SetWater(int water)
    {
        slider.value = water;
    }

    public void SetEmptyTank(bool isEmpty)
    {

        if (isEmpty)
        {
            emptyImage.enabled = true;
        }
        else
        {
            emptyImage.enabled = false;
        }
        
    }
}