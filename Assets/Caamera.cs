using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform alvo;

    public float distancia = 5f;
    public float altura = 2f;
    public float sensibilidade = 3f;

    private float rotacaoX;
    private float rotacaoY;

    void Start()
    {
        rotacaoY = transform.eulerAngles.y;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidade;

        rotacaoY += mouseX;
        rotacaoX -= mouseY;

        rotacaoX = Mathf.Clamp(rotacaoX, -30f, 60f);

        Quaternion rotacao = Quaternion.Euler(rotacaoX, rotacaoY, 0);

        Vector3 posicao = alvo.position + Vector3.up * altura;
        posicao -= rotacao * Vector3.forward * distancia;

        transform.position = posicao;
        transform.rotation = rotacao;
    }
}