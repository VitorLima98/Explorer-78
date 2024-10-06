using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class elementsreader : MonoBehaviour
{
    public elementobject elementodata;  // Objeto com informações sobre o elemento
    public TMP_Text numeroatomico;
    public TMP_Text Nomelemento;
    public TMP_Text Simbolo;
    public Image color;
    public Color cor;

    void Start()
    {
        // Atualiza os textos na interface
        numeroatomico.text = elementodata.numeroatomico.ToString();
        Nomelemento.text = elementodata.nomeElemento.ToString();
        Simbolo.text = elementodata.Simbolo.ToString();

        // Atribui a cor com base no tipo de elemento
        cor = GetColorByElementType(elementodata.tipo);

       

        color.color = cor;
    }

    // Função para retornar a cor baseada no tipo do elemento
    private Color GetColorByElementType(tipo.tipodeelemento tipoElemento)
    {
        switch (tipoElemento)
        {
            case tipo.tipodeelemento.Ametais_reativos:
                return HexToColor("#2F4DB4");
            case tipo.tipodeelemento.metais_alcalinoterrosos:
                return HexToColor("#64303B");
            case tipo.tipodeelemento.Actinideos:
                return HexToColor("#633D2A");  
            case tipo.tipodeelemento.metais_alcalinos:
                return HexToColor("#26505A");  
            case tipo.tipodeelemento.gases_nobres:
                return HexToColor("#653B44");  
            case tipo.tipodeelemento.metais_de_transicao:
                return HexToColor("#433C65");
            case tipo.tipodeelemento.metais_pos_transicoes:
                return HexToColor("##2F4D47");
            case tipo.tipodeelemento.Lantanideos:
                return HexToColor("#014C78");
         
            case tipo.tipodeelemento.propriedade_desconhecida:
                return HexToColor("#48494E");
                case tipo.tipodeelemento.semimetais:
                return HexToColor("#CA7047");
            default:
                return Color.white;  
        }
    }

    // Função para converter um código hexadecimal em uma cor
    public Color HexToColor(string hex)
    {
        hex = hex.Replace("#", "");  // Remove o símbolo '#' se existir

        // O código hex deve ter 6 ou 8 caracteres (RGB ou RGBA)
        if (hex.Length == 6)
        {
            hex += "FF";  // Adiciona Alpha como 255 (cor totalmente opaca)
        }

        if (hex.Length != 8)
        {
            Debug.LogError("Código hex inválido.");
            return Color.black;  // Retorna preto em caso de erro
        }

        // Converte as partes do hex para RGBA
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        byte a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);

        // Retorna a cor normalizada (valores de 0 a 1)
        return new Color32(r, g, b, a);
    }
   
}
