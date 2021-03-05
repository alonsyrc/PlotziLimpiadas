using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateVeredict : MonoBehaviour
{
    public enum VeredictType {NotGuilty,Guilty}
    public VeredictType veredictType;

    bool isInside;

    private void OnMouseEnter()
    {
        isInside = true;
    }

    //private void OnMouseDown()
    //{
    //    if (FindObjectOfType<VeredictHammer>().isInside && isInside)
    //    {
    //        GiveVeredict();
    //        //sonida tac tac
    //    }
    //}

    public void GiveVeredict()
    {
        switch (veredictType)
        {
            case VeredictType.Guilty:
                Debug.Log("Culpable");
                break;
            case VeredictType.NotGuilty:
                Debug.Log("Inocente");
                break;
        }
        GameManager.instance.EndTrial();
    }
}
