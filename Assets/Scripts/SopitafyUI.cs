using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SopitafyUI : MonoBehaviour
{
    TextMeshProUGUI txtVolumenPrc;
    public Slider sliderVolumen;
    float volPrc;

    // Start is called before the first frame update
    void Awake()
    {
        txtVolumenPrc = GameObject.Find("txtVolumenPrc").GetComponent<TextMeshProUGUI>();
        sliderVolumen = GetComponent<Slider>();
        sliderVolumen.onValueChanged.AddListener(delegate { ChangeVolumen(sliderVolumen.value); });
        //sopitafy = FindObjectOfType<Sopitafy>();
        sliderVolumen.value = 1.0f;
    }

    // cuando se le de click al boton de play pause sopitafy
    
    public void ChangeVolumen(float vol)
    {
        //sopitafy.ChangeVolume(vol);
        volPrc = vol * 100;
        txtVolumenPrc.text = ($"{Mathf.Round(volPrc).ToString()} %");
    }
}