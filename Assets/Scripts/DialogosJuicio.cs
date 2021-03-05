using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
    public int sumQuestions;
    public List<string> Questions = new List<string>();
    public List<string> Answers = new List<string>();
    public Sprite spritePersonaje;
    SpriteRenderer spriteRenderer;
    Material material;
    public int pixelatedAmountInicial;
    public int pixelatedAmount;
    ReportUIFiller reportUIFiller;
    GameManager gameManager;


    private void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
        reportUIFiller = FindObjectOfType<ReportUIFiller>();
        spriteRenderer = GameObject.FindGameObjectWithTag("SpritePersonaje").GetComponent<SpriteRenderer>();
        if (material == null)
            material = spriteRenderer.material;
    }

    private void Start()
    {
        material.SetFloat("_PixelateSize", 20);
        pixelatedAmount = pixelatedAmountInicial;
    }
    public string DialogoJuez()
    {
        return "Anything to say?";
    }

    public void LlegadaCorte( )
    {
        sumQuestions = 0;
        AnimarLlegada();
        Transcript.instance.NewTranscriptLine(DialogoJuez());
        Transcript.instance.NewTranscriptLine(PrimerDialogo());

        if(reportUIFiller == null)
            reportUIFiller = FindObjectOfType<ReportUIFiller>();
        reportUIFiller.ShowBrief(this);

        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
        //gameManager.MoveBriefIn();
    }

    public void AnimarLlegada()
    {
       if(spriteRenderer == null)
          spriteRenderer = GameObject.FindGameObjectWithTag("SpritePersonaje").GetComponent<SpriteRenderer>();
       spriteRenderer.sprite = spritePersonaje;
       if(material == null)
          material = spriteRenderer.material;

       DOTween.To(() => pixelatedAmount, x => pixelatedAmount = x,512 , 2).OnComplete(()=> {
           InspectSuspect.instance.ShowInspect();
           InspectSuspect.instance.isOn = true ;
       });   
       DialogosJuicio2.instance.StartCoroutine(CorrutineAjam(material, pixelatedAmount));
    }

    IEnumerator CorrutineAjam (Material material, float amount)
    {
        yield return new WaitForSeconds(.1f);
        material.SetFloat("_PixelateSize", amount);
        if (amount < 512)
            DialogosJuicio2.instance.StartCoroutine(CorrutineAjam(material, pixelatedAmount));
        else
            material.SetFloat("_PixelateSize", 9999);
    }

    public void SalidaCorte()
    {
        gameManager.FadeIn();
        AnimarLlegada();
    }
    public string PrimerDialogo()
    {
        return DialogoOfFijo;
    }

    public void Responder()
    {
        sumQuestions++;
        Transcript.instance.NewTranscriptLine(Questions[indexPregunta]);
        Transcript.instance.NewTranscriptLine(Answers[indexPregunta]);
        if(sumQuestions<2){
            InspectSuspect.instance.ShowInspect();
            InspectSuspect.instance.isOn=true;
        }
        else
        {
            Debug.Log("TOMAR DECISION");
            ///AQUI DEBE IR EL: TOMA UNA DECISION NO PUEDES PREGUNTAR MÁS
        }
    }
    public void SaltoDialogo(int id)
    {
        indexPregunta = id;
        FindObjectOfType<QuestionSpawner>().SpawnQuestion(Questions[id],this);
    }
}