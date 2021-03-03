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
    private void Awake()
    {
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

    public void LlegadaCorte()
    {
        AnimarLlegada();
        DialogoJuez();
        PrimerDialogo();
        PrintBrief();
    }

    public void AnimarLlegada()
    {
        //fade spritte y eso
        if(spriteRenderer == null)
            spriteRenderer = GameObject.FindGameObjectWithTag("SpritePersonaje").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spritePersonaje;
        if(material == null)
            material = spriteRenderer.material;

        DOTween.To(() => pixelatedAmount, x => pixelatedAmount = x,512 , 2);

        //pixelatedAmountInicial = DOTween.To(() => pixelatedAmountInicial, x => pixelatedAmountInicial = x,512, 10f);
        //material.SetFloat("_PixelateSize", pixelatedAmount);        
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

    public void PrintBrief()
    {
        //obtener brief y printearlo en la wea
    }

    public void SalidaCorte()
    {
        // fade screen y volver a llmar a 
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