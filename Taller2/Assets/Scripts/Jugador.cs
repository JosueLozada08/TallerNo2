using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector3 escalaInicial = new Vector3(1, 1, 1); // Escala inicial
    private float incrementoEscala = 0.1f;

    // Límites del mapa
    private float minX = -4.5f;
    private float maxX = 4.5f;
    private float minZ = -4.5f;
    private float maxZ = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        escalaInicial = transform.localScale; // Guardar la escala inicial
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1));
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        Vector3 nuevaPosicion = transform.position + (movimiento * velocidad * Time.deltaTime);

        // Verificar si la nueva posición está dentro de los límites del mapa
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, minX, maxX);
        nuevaPosicion.z = Mathf.Clamp(nuevaPosicion.z, minZ, maxZ);

        transform.position = nuevaPosicion;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            AumentarEscala();
            // Desactivar el enemigo al colisionar
            other.gameObject.SetActive(false);
        }
    }

    private void AumentarEscala()
    {
        transform.localScale = escalaInicial + new Vector3(incrementoEscala, incrementoEscala, incrementoEscala);
    }
}
