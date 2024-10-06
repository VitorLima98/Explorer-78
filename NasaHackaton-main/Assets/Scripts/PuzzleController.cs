using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public PuzzleImage puzzlePiece1;  // Referência para o primeiro objeto
    public PuzzleImage puzzlePiece2;  // Referência para o segundo objeto
    public GameObject uipuzzle1,uipuzzle2;
    public bool isPuzzleComplete = false;
    public float tolerance = 5f;  // Margem de erro aceitável para comparar as rotações

    void Update()
    {
     
    }
    public void check()
    {
        // Obtenha as rotações Z de ambos os objetos
        float rotation1 = puzzlePiece1.GetCurrentZRotation();
        float rotation2 = puzzlePiece2.GetCurrentZRotation();

        // Verifique se as rotações estão dentro da tolerância
        if (Mathf.Abs(Mathf.DeltaAngle(rotation1, rotation2)) <= tolerance)
        {
            if (!isPuzzleComplete)
            {
                isPuzzleComplete = true;
                OnPuzzleCompleted();
            }
        }
        else
        {
            isPuzzleComplete = false;
        }
    }
    void OnPuzzleCompleted()
    {
        GameManager.instance.Puzzlesequence[1] = true;
        uipuzzle1.SetActive(false);
        uipuzzle2.SetActive(false);
        GameManager.instance.Nextpuzzle();
    }
}