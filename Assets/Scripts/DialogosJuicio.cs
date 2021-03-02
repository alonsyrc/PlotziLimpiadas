using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PersonajeDialogos", menuName ="Dialogo")]
public class DialogosJuicio : ScriptableObject
{
    public enum TrueVeredict { Guilty, Inocent};
    public TrueVeredict trueVeredict;
    public string NameOfVictim;
    public string NameOfSuspect;
    public string CriminalOfRecord;
    public string BriefOfCharge;
    public string BriefOfDate;
    public string BriefOfFacts;
    public string DialogoOfFijo;
    public int indexPregunta;
    public List<string> Questions = new List<string>();
    public List<string> Answers = new List<string>();
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
