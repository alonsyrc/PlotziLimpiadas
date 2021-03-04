using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccesibilyMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown filterMode;
    public Toggle slowMode;

    public void ChangeFilter()
    {
        if(filterMode != null) {
            //Camera.main.GetComponent<ColorBlindFilter>().mode = (ColorBlindMode)filterMode.value;
            FindObjectOfType<ColorBlindFilterURP>().ChangeChannelMixer(filterMode.value);
            AccesibilityModel.filter = filterMode.value;
        }
        else
        {
            Camera.main.GetComponent<ColorBlindFilter>().mode = (ColorBlindMode)AccesibilityModel.filter;
        }
    }

    public void ChangeToggle()
    {
        AccesibilityModel.slowMode = slowMode.isOn;
    }

}
