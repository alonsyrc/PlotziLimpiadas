using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeredictHammer : MonoBehaviour
{
    Sprite hammerDown;
    public bool isDrag;
    public Vector3 initPos;

    public void RestartPosition()
    {
        isDrag = false;
        transform.position = initPos;
    }

    private void OnMouseDown()
    {
        ///llevarse el hammer
        isDrag = !isDrag;
        Cursor.visible = !isDrag;
    }

    private void Update()
    {
        if (isDrag)
        {
            transform.position = new Vector3(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,

                Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plate"))
        {
            
        }
    }
}
