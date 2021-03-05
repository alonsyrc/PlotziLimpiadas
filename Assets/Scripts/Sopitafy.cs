using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Sopitafy : MonoBehaviour
{
    //SopitafyUI sopitafyUI;
    AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Awake()
    {
        //sopitafyUI = FindObjectOfType<SopitafyUI>();
        audioSource = GetComponent<AudioSource>();
        //sopitafyUI.sliderVolumen = GameObject.Find("SldrVolumen").GetComponent<Slider>();
        audioSource.volume = 1.0f; //sopitafyUI.sliderVolumen.value;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // Update is called once per frame
    public void ChangeVolume(float vol)
    {
        audioSource.volume = vol;
    }

    public void PlayPause(bool isPlaying)
    {
        if(isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
