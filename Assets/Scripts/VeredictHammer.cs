using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VeredictHammer : MonoBehaviour
{
    Sprite hammerDown;
    public bool isDrag;
    public bool isInside;
    public Vector3 initPos;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    public void RestartPosition()
    {
        isDrag = false;
        transform.position = initPos;
        Cursor.visible = !isDrag;
    }

    private void OnMouseDown()
    {
        ///llevarse el hammer
        isDrag = !isDrag;
        Cursor.visible = !isDrag;
    }

    //si tengo el mazo y estoy enter en el plate puedo dar veredicto


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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("plate")&&Input.GetMouseButtonDown(0))
        {
            collision.GetComponent<PlateVeredict>().GiveVeredict();
            RestartPosition();
        }
    }
private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("plate"))
        {
            isInside = false;
        }
    }
}
