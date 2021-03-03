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
        briefName.text = CaseReport.name;
        briefRecord.text = CaseReport.CriminalOfRecord;
        briefVictim.text = CaseReport.NameOfVictim;
        briefDate.text = CaseReport.BriefOfDate;
        briefFacts.text = CaseReport.BriefOfFacts;

        photograph.sprite = CaseReport.spritePersonaje;
    }
}
