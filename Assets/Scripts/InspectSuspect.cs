using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectSuspect : MonoBehaviour
{
    public FlyingObjects[] flyingObjects;
    public bool isOn;

    public static InspectSuspect instance;

    private void Awake()
    {
        instance = this;
        HideInspect();
    }

    public bool inspecting;

    public void HideInspect()
    {
        transform.localScale = Vector3.zero;
        isOn = false;
    }
    public void ShowInspect()
    {
        transform.localScale = Vector3.one * 2;

        foreach (FlyingObjects item in flyingObjects)
        {
            item.transform.localScale = Vector3.one * 0.1f;
        }
    }

    private void OnMouseEnter()
    {
        //sacar a volar las partes, casha
        if (isOn)
        {
            inspecting = true;
            foreach (FlyingObjects item in flyingObjects)
            {
                item.MovePos();
            }
        }
    }
}
