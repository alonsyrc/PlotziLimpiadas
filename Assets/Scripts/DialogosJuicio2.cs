using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosJuicio2 : MonoBehaviour
{
    public static DialogosJuicio2 instance;

    void Awake()
    {
        DialogosJuicio2.instance = this;
    }
}
