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

    private void Awake()
    {
        spriteRenderer = GameObject.Find("SpritePersonaje").GetComponent<SpriteRenderer>();
        material = spriteRenderer.GetComponent<Material>();
        material.SetFloat("_PixelateSize", 24);

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
            material = spriteRenderer.GetComponent<Material>();
        material.SetFloat("_PixelateSize", 512);
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
