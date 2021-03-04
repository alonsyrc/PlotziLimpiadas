using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyingObjects : MonoBehaviour
{
    public float radious;
    public float timeToMove=3f;
    Vector3 randDirection;
    Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
        Randomize();

    }

    public void RestartPosition()
    {
        transform.position = initPos;
    }
     void Randomize()
    {
        randDirection.x = Random.Range(-radious, radious);
        randDirection.y = Random.Range(-radious, radious);
    }

    [ContextMenu("Move")]
    public void MovePos()
    {
        if (AccesibilityModel.slowMode) timeToMove *= 3;
        transform.DOMove(randDirection,timeToMove).SetEase(Ease.Linear).OnComplete(()=>{
            Randomize();
            MovePos();    
        });
    }

    private void OnMouseDown()
    {
        ///Llamar a la función que spawnea la pregunta
        ///Esconder
        ///Restart
    }
}
