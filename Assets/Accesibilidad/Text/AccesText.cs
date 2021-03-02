using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesText : MonoBehaviour
{
    List<TMPro.TextMeshProUGUI> texts = new List<TMPro.TextMeshProUGUI>();

    public delegate void TextEvent();
    public static event TextEvent FontEvent;
    public static event TextEvent FontSizeEvent;

    /// AccesText.FontEvent += function;
    /// AccesText.FontSizeEvent += function;

    ///Todos los textos se suscriben a este script y si se le da a un texto una propiedad X
    ///Que cambie tamaños, fuente a Open Dyslexic y así// Start is called before the first frame update
}
