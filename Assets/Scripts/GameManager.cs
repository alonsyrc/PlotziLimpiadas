using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int suspectIndex;
    public enum GameState { Started, GetSuspect, Trial, Veredict }
    public GameState gameState;
    public DialogosJuicio[] casosJuicio;
    DialogosJuicio dialogosJuicio;
    // Start is called before the first frame update

    private void Awake()
    {
        casosJuicio = (DialogosJuicio[])Resources.FindObjectsOfTypeAll(typeof(DialogosJuicio));
        if(casosJuicio.Length>0)
            suspectIndex = Random.Range(0, casosJuicio.Length);
    }
    void Start()
    {
        gameState = GameState.Started; 
        gameState = GameState.GetSuspect;
        var suspect = casosJuicio[suspectIndex];
        suspect.pixelatedAmount = 20;
        suspect.LlegadaCorte();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
