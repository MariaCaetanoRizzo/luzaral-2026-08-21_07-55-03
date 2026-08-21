using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float velocidade = 5f;
    public float velocidadeRotacao = 10f;
    public float gravidade = -9.81f;

    public Transform cameraTransform;

    private CharacterController controller;
    private float velocidadeY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(horizontal, 0, vertical).normalized;

        // Movimento relativo à câmera
        if (direcao.magnitude >= 0.1f)
        {
            float angulo = Mathf.Atan2(direcao.x, direcao.z) * Mathf.Rad2Deg;
            angulo += cameraTransform.eulerAngles.y;

            float rotacao = Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                angulo,
                ref velocidadeRotacao,
                0.1f
            );

            transform.rotation = Quaternion.Euler(0, rotacao, 0);

            Vector3 movimento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimento * velocidade * Time.deltaTime);
        }

        // Gravidade
        if (controller.isGrounded && velocidadeY < 0)
            velocidadeY = -2f;

        velocidadeY += gravidade * Time.deltaTime;

        controller.Move(Vector3.up * velocidadeY * Time.deltaTime);
    }
}