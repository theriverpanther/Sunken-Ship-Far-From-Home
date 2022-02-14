using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private Image barImage;

    // Start is called before the first frame update
    void Start()
    {
        barImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBar(float fill)
    {
        barImage.fillAmount = fill;
    }


}
