using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class banner : MonoBehaviour
{
    public elementsreader objdata;
    public TMP_Text NOME;
    public TMP_Text NUMEROATOMICO;
    public TMP_Text simbolo;
    public TMP_Text tipo;
    public Color cor;
    public Image corla;
  
    public void exibirdados()
    {
        NOME.text = objdata.Nomelemento.text;
        NUMEROATOMICO.text = objdata.numeroatomico.text;
        simbolo.text = objdata.Simbolo.text;
        tipo.text = objdata.elementodata.tipo.ToString();
        cor = objdata.cor;
        corla.color = cor;
    }
}
