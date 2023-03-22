using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGradient : MonoBehaviour
{
    public Image filledBar;
    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        filledBar.color = gradient.Evaluate(filledBar.fillAmount);
    }
}
