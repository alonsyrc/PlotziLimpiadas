using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectSuspect : MonoBehaviour
{
    public FlyingObjects[] flyingObjects;

    public static InspectSuspect instance;

    private void Awake()
    {
        instance = this;
    }

    public bool inspecting;

    private void OnMouseEnter()
    {
        //sacar a volar las partes, casha
        if (!inspecting)
        {
            inspecting = true;
            foreach (FlyingObjects item in flyingObjects)
            {
                item.MovePos();
            }
        }
    }
}
