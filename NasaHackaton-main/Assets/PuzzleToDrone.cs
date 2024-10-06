using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PuzzleToDrone : MonoBehaviour
{
    public string password;
    public InputField campo;
    public GameObject UInegative;
    public string senha;
    public GameObject Logon, passwordpanel;
    public PlanetSystem currentplanet;
    public int currentindex;
    public TMP_Text TextoNome;
    public TMP_Text description;
    public TMP_Text Atmosphere;
    public TMP_Text MASS;
    public TMP_Text Type;
    public RawImage render;
    void Start()
    {
        currentindex = 0;
        if (campo != null)
        {
            // Add a listener to detect when the user has finished editing the input field
            campo.onEndEdit.AddListener(OnInputFieldChanged);
        }
    }
 
    // Update is called once per frame
  
    public void verifypassword()
    {
        if(senha == password)
        {
            passwordpanel.SetActive(false);
            Logon.SetActive(true);
        }
        else
        {
            UInegative.SetActive(true);

        }
    }
    public void OnInputFieldChanged(string input)
    {
        senha = input;

        
    }
    public void scanexoplanet()
    {
        currentplanet = GameManager.instance.planetsregistered[currentindex];
        MASS.text = currentplanet.Mass;
        Atmosphere.text = currentplanet.atmosphere;
        Type.text = currentplanet.type;
        description.text = currentplanet.description;
        render.texture = currentplanet.render;

    }
}
