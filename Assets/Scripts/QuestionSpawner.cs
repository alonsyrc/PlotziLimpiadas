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

    private void Start()
    {
        TweenOut();
    }

    public void SpawnQuestion(string question,DialogosJuicio CaseReport=null/*, QuestionSpawnning functionReturn*/)
    {
        questionText.text = question;
        QuestionPop.GetComponentInChildren<Button>().onClick.AddListener(() => {
            CaseReport.Responder();
            QuestionPop.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
           // QuestionAnswered.Invoke();
            TweenOut();
        }
        ) ;
        TweenIN();
    }

    void TweenIN()
    {
        transform.localScale = Vector3.one;
    }

    void TweenOut()
    {
        transform.localScale = Vector3.zero;
        questionText.text = "";
    }
}
