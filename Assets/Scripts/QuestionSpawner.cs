using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSpawner : MonoBehaviour
{
    ///suscribe evento
    ///instancia pregunta
    ///hace click
    ///Profit
    ///

    public delegate void QuestionSpawnning();
    public static event QuestionSpawnning QuestionAnswered;

    public GameObject QuestionPop;
    public TMPro.TextMeshProUGUI questionText;

    public void SpawnQuestion(string question,DialogosJuicio CaseReport=null/*, QuestionSpawnning functionReturn*/)
    {
        
        questionText.text = question;
        QuestionPop.GetComponentInChildren<Button>().onClick.AddListener(() => {

            QuestionAnswered.Invoke();
            TweenOut();
        }
        ) ;
        TweenIN();
    }

    void TweenIN()
    {

    }

    void TweenOut()
    {

    }
}
