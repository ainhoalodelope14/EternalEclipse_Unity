using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemigos : MonoBehaviour
{
    public List<GameObject> prefabsEnemigos;
    public float tiempoEntreGeneraciones = 3f;
    public float radioArea = 5f;
    public Transform jugador; // Referencia al GameObject del jugador
    private float tiempoPasado = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (prefabsEnemigos.Count == 0)
        {
            Debug.LogWarning("La lista de prefabs de enemigos está vacía.");
        }

        if (jugador == null)
        {
            Debug.LogError("La referencia al jugador no está asignada.");
        }
    }

    private void Update()
    {
        tiempoPasado += Time.deltaTime;
        if (tiempoPasado >= tiempoEntreGeneraciones) // Generar enemigo cada vez que pasa el tiempo establecido
        {
            GenerarEnemigo();
            tiempoPasado = 0f;
        }
    }

    private void GenerarEnemigo()
    {
        if (prefabsEnemigos.Count == 0)
        {
            Debug.LogWarning("La lista de prefabs de enemigos está vacía.");
            return;
        }

        // Seleccionar un prefab de enemigo al azar de la lista
        GameObject prefabEnemigo = prefabsEnemigos[Random.Range(0, prefabsEnemigos.Count)];

        // Generar posición aleatoria dentro del radio especificado
        Vector3 posicionGeneracion = GetRandomPosition();

        // Instanciar el enemigo en la posición generada
        GameObject nuevoEnemigo = Instantiate(prefabEnemigo, posicionGeneracion, Quaternion.identity);
        
        // Asignar el jugador al enemigo generado
        MovimientoEnemigo movimientoEnemigo = nuevoEnemigo.GetComponent<MovimientoEnemigo>();
        if (movimientoEnemigo != null)
        {
            movimientoEnemigo.jugador = jugador;
        }
        else
        {
            Debug.LogWarning("El enemigo generado no tiene el componente MovimientoEnemigo.");
        }
    }

    private Vector3 GetRandomPosition()
    {
        // Definir el tamaño del cuadrado donde los enemigos pueden aparecer
        float squareSize = radioArea * 2f;

        // Generar posiciones aleatorias dentro del cuadrado
        float randomX = Random.Range(transform.position.x - radioArea, transform.position.x + radioArea);
        float randomY = Random.Range(transform.position.y - radioArea, transform.position.y + radioArea);

        // Retornar la posición aleatoria dentro del cuadrado
        return new Vector3(randomX, randomY, transform.position.z);
    }
}
