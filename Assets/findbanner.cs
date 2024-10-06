using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findbanner : MonoBehaviour
{
    public elementsreader readerdata;


    public void troca()
    {
       banner ban =  FindAnyObjectByType<banner>();
        ban.objdata = readerdata;
        ban.exibirdados();
       
    }
}
