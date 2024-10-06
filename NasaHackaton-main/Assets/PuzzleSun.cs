using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSun : MonoBehaviour
{
    public GameObject mira;         // Referência ao objeto mira
    public GameObject exoplanet;    // Referência ao objeto exoplanet
    public bool nextPlanet;         // Indica se o exoplanet está na posição correta
    public float tolerance = 0.1f;  // Tolerância para comparação de posições (distância mínima)

    private void Update()
    {
        // Você pode chamar o método check() dentro do Update para checar constantemente.
        check();
    }

    public void check()
    {
        // Calcula a distância entre os dois objetos
        float distance = Vector3.Distance(exoplanet.transform.position, mira.transform.position);

        // Se a distância for menor que a tolerância, consideramos que estão na mesma posição
        if (distance <= tolerance)
        {
            nextPlanet = true;
            Debug.LogWarning("DEU CERTOOOOOOOOOO! Exoplanet está na mesma posição que a mira.");
        }
        else
        {
            nextPlanet = false;
        }
    }
}
