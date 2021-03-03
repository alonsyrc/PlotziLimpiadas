using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public int suspectIndex;
    public enum GameState { Started, GetSuspect, Trial, Veredict }
    public GameState gameState;
    public DialogosJuicio[] casosJuicio;
    DialogosJuicio dialogosJuicio;
    ReportUIFiller reportUIFiller;
    RectTransform rectTransform;
    // Start is called before the first frame update

    private void Awake()
    {
        rectTransform = GameObject.Find("Brief").GetComponent<RectTransform>();
        casosJuicio = (DialogosJuicio[])Resources.FindObjectsOfTypeAll(typeof(DialogosJuicio));
        if(casosJuicio.Length>0)
            suspectIndex = Random.Range(0, casosJuicio.Length);

        rectTransform.DOMoveX(1000f, 0f);
    }
    void Start()
    {
        gameState = GameState.Started; 
        gameState = GameState.GetSuspect;
        var suspect = casosJuicio[suspectIndex];
        suspect.pixelatedAmount = 20;
        suspect.LlegadaCorte();
    }

    public void MoveBriefIn()
    {
        rectTransform.DOLocalMoveX(450f, 1f, true);
    }

    public void MoveBriefOut()
    {
        rectTransform.DOLocalMoveX(1000f, 1f, true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
