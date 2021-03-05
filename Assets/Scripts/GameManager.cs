using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public int suspectIndex;
    public enum GameState { None, Started, GetSuspect, Trial, Veredict }
    public GameState gameState;
    public DialogosJuicio[] casosJuicio;
    public DialogosJuicio suspect;
    ReportUIFiller reportUIFiller;
    //RectTransform rectTransform;
    public List<int> casosAtendidosList = new List<int>();
    bool yaSeAtendio;
    Animator animator;
    int animationStateParameter;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        //rectTransform = GameObject.Find("Brief").GetComponent<RectTransform>();
        casosJuicio = (DialogosJuicio[])Resources.FindObjectsOfTypeAll(typeof(DialogosJuicio));
        //rectTransform.DOMoveX(1000f, 0f);
    }
    void Start()
    { 
        StartCase();
    }

    void StartCase()
    {
        if (casosJuicio.Length > 0)
        {
            gameState = GameState.Started;
            suspectIndex = Random.Range(0, casosJuicio.Length);
            yaSeAtendio = casosAtendidosList.Any(item => item == suspectIndex);
            if (!yaSeAtendio)
            {
                casosAtendidosList.Add(suspectIndex);
                gameState = GameState.GetSuspect;
                suspect = casosJuicio[suspectIndex];
                suspect.pixelatedAmount = 20;
                FadeOut();
                suspect.LlegadaCorte();
                gameState = GameState.Trial;
            }
            else
            {
                StartCase();
            }
        }
        else
        {
            StartCase();
        }
    }

    /*public void MoveBriefIn()
    {
        rectTransform.DOLocalMoveX(450f, 1f, true);
    }*/

    /*public void MoveBriefOut()
    {
        rectTransform.DOLocalMoveX(1000f, 1f, true);
    }*/

    // Update is called once per frame
    public void ChangeCase()
    {
        gameState = GameState.Started;
        StartCase();
    }

    public void FadeOut()
    {
        DialogosJuicio2.instance.StartCoroutine(AnimFade(20, 21));
    }
    public void FadeIn()
    {
        DialogosJuicio2.instance.StartCoroutine(AnimFade(10, 11));
    }

    IEnumerator AnimFade(int primero, int segundo)
    {
        if (animator == null)
        {
            animationStateParameter = Animator.StringToHash("AnimState");
            animator = GameObject.Find("Canvas").GetComponent<Animator>();
        }
        animator.SetInteger(animationStateParameter, primero);
        yield return new WaitForSeconds(1f);
        animator.SetInteger(animationStateParameter, segundo);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && casosAtendidosList.Count < 4)
        {
            StartCoroutine(ChangeSuspect(suspect));
        }
        else
        {
            //Periodico
        }
    }

    IEnumerator ChangeSuspect(DialogosJuicio suspect)
    {
        suspect.SalidaCorte();
        yield return new WaitForSeconds(1f);
        StartCase();
    }
}