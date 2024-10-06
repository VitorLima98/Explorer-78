using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleImage : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private float initialAngle;
    public RectTransform rectTransform;
    public float rotationSensitivity = 0.5f;  // Fator de sensibilidade da rota��o
    public float rotationSmoothing = 0.1f;    // Fator de suaviza��o da rota��o
    private float targetAngle;  // O �ngulo desejado para a rota��o

    void Start()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }

        targetAngle = rectTransform.eulerAngles.z;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Calcula o �ngulo inicial entre o clique e o centro do elemento da UI
        Vector2 direction = eventData.position - (Vector2)rectTransform.position;
        initialAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rectTransform.eulerAngles.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calcula o novo �ngulo e aplica a rota��o suavizada
        Vector2 direction = eventData.position - (Vector2)rectTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - initialAngle;

        // Ajusta o �ngulo com base na sensibilidade
        targetAngle = Mathf.Repeat(rectTransform.eulerAngles.z + (angle * rotationSensitivity), 360f);
    }

    void Update()
    {
        // Aplica suaviza��o � rota��o
        float currentZRotation = rectTransform.eulerAngles.z;
        float smoothedAngle = Mathf.LerpAngle(currentZRotation, targetAngle, rotationSmoothing);

        rectTransform.rotation = Quaternion.Euler(0, 0, smoothedAngle);
    }

    // Fun��o p�blica para obter a rota��o atual do objeto
    public float GetCurrentZRotation()
    {
        return rectTransform.eulerAngles.z;
    }
}
