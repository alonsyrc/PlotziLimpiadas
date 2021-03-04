using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyingObjects : MonoBehaviour
{
    public float radious;
    public float timeToMove=3f;
    public enum QuestionType { feeling,memory,talking}
    public QuestionType questionType;
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

    void HideObjetc()
    {
        transform.localScale = Vector3.zero;
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

        int id;
    private void OnMouseDown()
    {
        switch (questionType)
        {
            case QuestionType.feeling:
                id = 0;
                break;
            case QuestionType.memory:
                id = 1;
                break;
            case QuestionType.talking:
                id = 2;
                break;
        }
        //FindObjectOfType<DialogosJuicio>().SaltoDialogo(id);
        GameManager.instance.suspect.SaltoDialogo(id);
        InspectSuspect.instance.HideInspect();
        RestartPosition();
        HideObjetc();
        ///Llamar a la función que llama la pregunta
        ///Esconder
        ///Restart
    }
}
