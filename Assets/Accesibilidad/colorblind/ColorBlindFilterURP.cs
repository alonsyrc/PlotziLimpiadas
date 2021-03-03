using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorBlindFilterURP : MonoBehaviour
{
    Volume globalVolumen;
    ChannelMixer channelMixer;
    public static ColorBlindFilterURP instance;
    public enum ColorBlindMode
    {
        Normal = 0,
        Protanopia = 1,
        Protanomaly = 2,
        Deuteranopia = 3,
        Deuteranomaly = 4,
        Tritanopia = 5,
        Tritanomaly = 6,
        Achromatopsia = 7,
        Achromatomaly = 8,
    }

    private static Color[,] RGB =
    {
        { new Color(1f,0f,0f)*100,   new Color(0f,1f,0f)*100, new Color(0f,0f,1f)*100 },    // Normal
        { new Color(.56667f, .43333f, 0f)*100, new Color(.55833f, .44167f, 0f)*100, new Color(0f, .24167f, .75833f)*100 },    // Protanopia
        { new Color(.81667f, .18333f, 0f)*100, new Color(.33333f, .66667f, 0f)*100, new Color(0f, .125f, .875f)*100    }, // Protanomaly
        { new Color(.625f, .375f, 0f)*100, new Color(.70f, .30f, 0f)*100, new Color(0f, .30f, .70f)*100    },   // Deuteranopia
        { new Color(.80f, .20f, 0f)*100, new Color(.25833f, .74167f, 0)*100, new Color(0f, .14167f, .85833f)*100    },    // Deuteranomaly
        { new Color(.95f, .05f, 0)*100, new Color(0f, .43333f, .56667f)*100, new Color(0f, .475f, .525f)*100 }, // Tritanopia
        { new Color(.96667f, .03333f, 0)*100, new Color(0f, .73333f, .26667f)*100, new Color(0f, .18333f, .81667f)*100 }, // Tritanomaly
        { new Color(.299f, .587f, .114f)*100, new Color(.299f, .587f, .114f)*100, new Color(.299f, .587f, .114f)*100  },   // Achromatopsia
        { new Color(.618f, .32f, .062f)*100, new Color(.163f, .775f, .062f)*100, new Color(.163f, .320f, .516f)*100  }    // Achromatomaly
    };

    private void Awake()
    {
        instance = this;
        globalVolumen = FindObjectOfType<Volume>();
        globalVolumen.sharedProfile.TryGet(out channelMixer);
    }



    [ContextMenu("ChannelMixer")]
    public void ChangeChannelMixer(int id)
    {
        channelMixer.redOutRedIn.value = RGB[id, 0].r;
        channelMixer.redOutGreenIn.value = RGB[id, 0].g;
        channelMixer.redOutBlueIn.value = RGB[id, 0].b;

        channelMixer.greenOutRedIn.value = RGB[id, 1].r;
        channelMixer.greenOutGreenIn.value = RGB[id, 1].g;
        channelMixer.greenOutBlueIn.value = RGB[id, 1].b;

        channelMixer.blueOutRedIn.value = RGB[id, 2].r;
        channelMixer.blueOutGreenIn.value = RGB[id, 2].g;
        channelMixer.blueOutBlueIn.value = RGB[id, 2].b;
        #region switch
        //switch (id)
        //{
        //    case 0:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //    case 1:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //    case 2:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //    case 3:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //    case 4:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //    case 5:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //    case 6:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //    case 7:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //    case 8:
        //        channelMixer.redOutRedIn.value = RGB[0, 0].r;
        //        channelMixer.redOutGreenIn.value = RGB[0, 0].g;
        //        channelMixer.redOutBlueIn.value = RGB[0, 0].b;

        //        channelMixer.greenOutRedIn.value = RGB[0, 1].r;
        //        channelMixer.greenOutGreenIn.value = RGB[0, 1].g;
        //        channelMixer.greenOutBlueIn.value = RGB[0, 1].b;

        //        channelMixer.blueOutRedIn.value = RGB[0, 2].r;
        //        channelMixer.blueOutGreenIn.value = RGB[0, 2].g;
        //        channelMixer.blueOutBlueIn.value = RGB[0, 2].b;
        //        break;
        //}
        #endregion
    }
}
