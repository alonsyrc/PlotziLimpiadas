using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateVeredict : MonoBehaviour
{
    public enum VeredictType {NotGuilty,Guilty}
    public VeredictType veredictType;

    private void OnMouseDown()
    {
        if (FindObjectOfType<VeredictHammer>().isDrag)
        {
            GiveVeredict();
            //sonida tac tac
        }
    }

    public void GiveVeredict()
    {
        switch (veredictType)
        {
            case VeredictType.Guilty:

                break;
            case VeredictType.NotGuilty:

                break;
        }
    }
}
