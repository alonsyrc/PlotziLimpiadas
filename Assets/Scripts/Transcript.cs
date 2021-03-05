using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Transcript : MonoBehaviour
{
    public static Transcript instance;
    public GameObject dialogueLine;

    private void Awake()
    {
        instance = this;
    }

    public void NewTranscriptLine(string dialogue)
    {
        TextMeshProUGUI newDalog = Instantiate(dialogueLine,transform).GetComponent<TextMeshProUGUI>();
        newDalog.text = dialogue;
    }

    public void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
