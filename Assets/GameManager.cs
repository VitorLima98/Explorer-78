using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<bool> Puzzlesequence;
    public List<PlanetSystem> planetsregistered;
    public static GameManager instance;
    public List<GameObject> puzzlelist;
    public int planetindex;
    public int i;
    public GameObject computertoturnOn;
    public GameObject scanbutton;
    public bool scanned;
    public GameObject sendronebutton;
    public GameObject textsignal;
    public bool tableopen;
    private void Awake()
    {
        instance = this;
        
    }
    public void Nextpuzzle()
    {   
        i++;
        puzzlelist[i].SetActive(true);
    }
   public void Updateprogress()
    {
        isReady();
    }
    public void tableswitch()
    {
        tableopen = !tableopen;
    }
    public void isReady()
    {
        if (Puzzlesequence.Count >= 2 && Puzzlesequence[0] && Puzzlesequence[1])
        {
            scanbutton.GetComponent<Button>().interactable = true;
            textsignal.SetActive(false); 

        }
        else
        {
            Debug.Log("Um ou ambos dos primeiros elementos são false.");
        }
    }
    public void turnonpc()
    {
        computertoturnOn.SetActive(true);
    }
 
    public void scannede()
    {
        sendronebutton.GetComponent<Button>().interactable = true;
    }
    public void Quit()
    {
      Application.Quit();
    }
}
