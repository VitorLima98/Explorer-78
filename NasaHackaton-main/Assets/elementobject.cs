using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableElement", menuName = "ElementsCreate/Add New Element", order = 1)]
public class elementobject : ScriptableObject
{
    public string nomeElemento;
    public tipo.tipodeelemento tipo;
    public float numeroatomico;
    public string Simbolo;

}
public class tipo
{
    public enum tipodeelemento
    {
        metais_alcalinos,
        semimetais,
        Actinideos,
        Ametais_reativos,
        gases_nobres,
        Lantanideos,
        metais_alcalinoterrosos,
        metais_de_transicao,
        propriedade_desconhecida,
        metais_pos_transicoes
    };
   tipodeelemento Tipoelemento;
  

   

}