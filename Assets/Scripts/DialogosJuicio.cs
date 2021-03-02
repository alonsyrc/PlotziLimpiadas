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
    int pixelatedAmount;

    private void Awake()
    {
        spriteRenderer = GameObject.Find("SpritePersonaje").GetComponent<SpriteRenderer>();
        if (material == null)
            material = spriteRenderer.material;
    }

    private void Start()
    {
        material.SetFloat("_PixelateSize", 20);
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
        spriteRenderer.sprite = spritePersonaje;
        if(material == null)
            material = spriteRenderer.material;
        //DOTween.To(() => pixelatedAmount, x => pixelatedAmount = x,512, 10f);

            DialogosJuicio2.instance.StartCoroutine(StartAjam(material));
    }

    IEnumerator StartAjam(Material material)
    {
        pixelatedAmount++;
        yield return new WaitForSeconds(1f);
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