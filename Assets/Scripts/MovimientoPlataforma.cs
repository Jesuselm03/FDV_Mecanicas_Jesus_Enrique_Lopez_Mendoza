using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaDeMovimiento = 5f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float movimiento = Mathf.Sin(Time.time * velocidad) * distanciaDeMovimiento;

        transform.position = posicionInicial + new Vector3(movimiento, 0, 0);
    }
}