using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public AudioSource audio;
    private System.Random random; // Variable para la librer�a Random
    private List<Vector3> usedPositions; // Lista de posiciones utilizadas

    // Rango del plano
    private float minX = -5f;
    private float maxX = 5f;
    private float minZ = -5f;
    private float maxZ = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar la librer�a Random con una semilla aleatoria basada en el tiempo actual
        random = new System.Random(UnityEngine.Random.seed);

        // Inicializar la lista de posiciones utilizadas
        usedPositions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Jugador"))
        {
            audio.Play();
            RegenerarEnNuevaPosicion();
        }
    }

    private void RegenerarEnNuevaPosicion()
    {
        Vector3 newPosition;
        do
        {
            // Generar una nueva posici�n aleatoria dentro de los l�mites del plano
            float newX = RandomFloat(minX, maxX);
            float newZ = RandomFloat(minZ, maxZ);
            newPosition = new Vector3(newX, transform.position.y, newZ);
        } while (usedPositions.Contains(newPosition)); // Repetir si la posici�n ya fue utilizada

        // Mover el enemigo a la nueva posici�n
        transform.position = newPosition;

        // Agregar la nueva posici�n a la lista de posiciones utilizadas
        usedPositions.Add(newPosition);
    }

    private float RandomFloat(float minValue, float maxValue)
    {
        // Generar un n�mero aleatorio en el rango especificado
        double randomDouble = random.NextDouble();
        double valueRange = maxValue - minValue;
        double randomValue = minValue + (randomDouble * valueRange);
        return (float)randomValue;
    }
}
