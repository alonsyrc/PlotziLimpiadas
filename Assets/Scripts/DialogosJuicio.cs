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
    public List<string> Questions = new List<string>();
    public List<string> Answers = new List<string>();
    public Sprite spritePersonaje;
    SpriteRenderer spriteRenderer;
    Material material;
    public int pixelatedAmountInicial;
    public int pixelatedAmount;
    ReportUIFiller reportUIFiller;
    GameManager gameManager;
    Animator animator;
    int animationStateParameter;

    private void Awake()
    {
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
        return "Algo que decir?";
    }

    public void LlegadaCorte( )
    {
        FadeOut();
        AnimarLlegada();
        DialogoJuez();
        PrimerDialogo();

        if(reportUIFiller == null)
            reportUIFiller = FindObjectOfType<ReportUIFiller>();
        reportUIFiller.ShowBrief(this);

        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
        gameManager.MoveBriefIn();
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

    public void AnimarLlegada()
    {
       if(spriteRenderer == null)
          spriteRenderer = GameObject.FindGameObjectWithTag("SpritePersonaje").GetComponent<SpriteRenderer>();
       spriteRenderer.sprite = spritePersonaje;
       if(material == null)
          material = spriteRenderer.material;

       DOTween.To(() => pixelatedAmount, x => pixelatedAmount = x,512 , 2);   
       DialogosJuicio2.instance.StartCoroutine(CorrutineAjam(material, pixelatedAmount));
    }

    IEnumerator CorrutineAjam (Material material, float amount)
    {
        yield return new WaitForSeconds(.1f);
        material.SetFloat("_PixelateSize", amount);
        if(amount < 512)
            DialogosJuicio2.instance.StartCoroutine(CorrutineAjam(material, pixelatedAmount));
    }

    void Update()
    {
        material.SetFloat("_PixelateSize", pixelatedAmount);
    }

    public void SalidaCorte()
    {
        AnimarLlegada();
    }
    public string PrimerDialogo()
    {
        return DialogoOfFijo;
    }
    public void SaltoDialogo()
    { 
        
    }
}