using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleImage : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private float initialAngle;
    public RectTransform rectTransform;
    public float rotationSensitivity = 0.5f;  // Fator de sensibilidade da rotação
    public float rotationSmoothing = 0.1f;    // Fator de suavização da rotação
    private float targetAngle;  // O ângulo desejado para a rotação

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
        // Calcula o ângulo inicial entre o clique e o centro do elemento da UI
        Vector2 direction = eventData.position - (Vector2)rectTransform.position;
        initialAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rectTransform.eulerAngles.z;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calcula o novo ângulo e aplica a rotação suavizada
        Vector2 direction = eventData.position - (Vector2)rectTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - initialAngle;

        // Ajusta o ângulo com base na sensibilidade
        targetAngle = Mathf.Repeat(rectTransform.eulerAngles.z + (angle * rotationSensitivity), 360f);
    }

    void Update()
    {
        // Aplica suavização à rotação
        float currentZRotation = rectTransform.eulerAngles.z;
        float smoothedAngle = Mathf.LerpAngle(currentZRotation, targetAngle, rotationSmoothing);

        rectTransform.rotation = Quaternion.Euler(0, 0, smoothedAngle);
    }

    // Função pública para obter a rotação atual do objeto
    public float GetCurrentZRotation()
    {
        return rectTransform.eulerAngles.z;
    }
}
