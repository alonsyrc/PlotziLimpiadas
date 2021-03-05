using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlyingObjects : MonoBehaviour
{
    public float radious;
    public float timeToMove=1f;
    public enum QuestionType { feeling,memory,talking}
    public QuestionType questionType;
    Vector3 randDirection;
    Vector3 initPos;
    bool locked;

    private void Start()
    {
        initPos = transform.position;
        Randomize();

    }

    public void RestartPosition()
    {
        transform.position = initPos;
        locked = false;
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

     public void ShowFlyingObjects()
    {
        transform.localScale = Vector3.one;
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
        if (!locked)
        {
            locked = true;
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
            GameManager.instance.suspect.SaltoDialogo(id);
            InspectSuspect.instance.HideInspect();
            RestartPosition();
            HideObjetc();
        }
        ///Llamar a la función que llama la pregunta
        ///Esconder
        ///Restart
    }
}
