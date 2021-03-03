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
        randDirection.x = Random.Range(-radious,radious);
        randDirection.y = Random.Range(-radious,radious);
    }

    public void RestartPosition()
    {
        transform.position = initPos;
    }

    public void MovePos()
    {
        transform.DOMove(randDirection,timeToMove).OnComplete(()=>{
            MovePos();    
        });
    }
}
