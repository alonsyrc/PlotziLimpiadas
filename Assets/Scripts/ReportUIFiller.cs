using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReportUIFiller : MonoBehaviour
{

    public TextMeshProUGUI briefName;
    public TextMeshProUGUI briefRecord;
    public TextMeshProUGUI briefVictim;
    public TextMeshProUGUI briefDate;
    public TextMeshProUGUI briefFacts;
    public Image photograph;

    public void ShowBrief(DialogosJuicio CaseReport)
    {
        FillBrief(CaseReport);
        //Tweening
    }

    public void CloseBrief()
    {
        //Tweening off
    }

    public void FillBrief(DialogosJuicio CaseReport)
    {
        briefName.text =   "<b>•Suspect: </b>" + CaseReport.NameOfSuspect;
        briefRecord.text = "<b>•Criminal Record: </b>" + CaseReport.CriminalOfRecord;
        briefVictim.text = "<b>•Victim: </b>" + CaseReport.NameOfVictim;
        briefDate.text =   "<b>•Date: </b>" + CaseReport.BriefOfDate;
        briefFacts.text =  "<b>•Facts: </b>" + CaseReport.BriefOfFacts;
        photograph.sprite = CaseReport.spritePersonaje;
    }
}
