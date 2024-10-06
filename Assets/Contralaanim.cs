using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Contralaanim : MonoBehaviour
{
    public Animator animator;
    public bool change;
    public TMP_Text text;
   public void play()
    {
      change = !change;
        animator.SetBool("Isactive",change);
        if(change)
        {
            text.text = ">>";
        }
        else
        {
            text.text = "<<";
        }
    }
    
}
