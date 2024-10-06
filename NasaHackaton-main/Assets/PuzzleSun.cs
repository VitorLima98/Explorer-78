using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSun : MonoBehaviour
{
    public GameObject mira;         // Refer�ncia ao objeto mira
    public GameObject exoplanet;    // Refer�ncia ao objeto exoplanet
    public bool nextPlanet;         // Indica se o exoplanet est� na posi��o correta
    public float tolerance = 0.1f;  // Toler�ncia para compara��o de posi��es (dist�ncia m�nima)

    private void Update()
    {
        // Voc� pode chamar o m�todo check() dentro do Update para checar constantemente.
        check();
    }

    public void check()
    {
        // Calcula a dist�ncia entre os dois objetos
        float distance = Vector3.Distance(exoplanet.transform.position, mira.transform.position);

        // Se a dist�ncia for menor que a toler�ncia, consideramos que est�o na mesma posi��o
        if (distance <= tolerance)
        {
            nextPlanet = true;
            Debug.LogWarning("DEU CERTOOOOOOOOOO! Exoplanet est� na mesma posi��o que a mira.");
        }
        else
        {
            nextPlanet = false;
        }
    }
}
