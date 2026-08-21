using UnityEngine;

public class SobeDesce : MonoBehaviour
{
    public float altura = 2f;
    public float velocidade = 2f;

    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        float movimento = Mathf.Sin(Time.time * velocidade) * altura;
        transform.position = posicaoInicial + Vector3.up * movimento;
    }
}