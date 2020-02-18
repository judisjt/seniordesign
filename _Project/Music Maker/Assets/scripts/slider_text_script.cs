using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class slider_text_script : MonoBehaviour
{
    public Slider superSlider;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
         text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        var superSliderValuString = superSlider.value.ToString();
        text.text = superSliderValuString;
    }

}
