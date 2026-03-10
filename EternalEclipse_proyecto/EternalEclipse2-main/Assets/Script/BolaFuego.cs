using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego : MonoBehaviour
{
    public GameObject prefabProyectil; // Prefab del proyectil a disparar
    public float distanciaMaxima = 10f; // Distancia máxima a la que el proyectil puede viajar
    public float velocidadProyectil = 10f; // Velocidad del proyectil
    public float tiempoDeVida = 3f; // Tiempo de vida de la habilidad en segundos
    public float distanciaSegura = 2f; // Distancia segura entre la habilidad y el jugador al instanciar
    public float cooldown = 1f; // Tiempo de enfriamiento entre disparos
    private float tiempoUltimoDisparo; // Tiempo en el que se realizó el último disparo
    GameObject proyectil;

    void Start()
    {
        tiempoUltimoDisparo = -PlayerPrefsSettings.instance.getCooldownHabilidad(); // Inicializar el tiempo del último disparo para permitir el primer disparo
    }

    void Update()
    {
        // Verifica si se puede disparar nuevamente
        if (Time.time >= tiempoUltimoDisparo + PlayerPrefsSettings.instance.getCooldownHabilidad())
        {
            // Verifica si se presiona el botón de disparo (en este caso, el botón izquierdo del mouse)
            if (Input.GetMouseButtonDown(0))
            {
                DispararHaciaCursor();
            }
        }
    }

    void DispararHaciaCursor()
    {
        // Obtener la posición del cursor en la pantalla
        Vector3 posicionCursor = Input.mousePosition;

        // Convertir la posición del cursor de la pantalla a una posición en el mundo
        Vector3 posicionCursorEnMundo = Camera.main.ScreenToWorldPoint(new Vector3(posicionCursor.x, posicionCursor.y, Camera.main.transform.position.z));

        // Obtener la posición del jugador
        Vector3 posicionJugador = transform.position;

        // Calcular la dirección desde la posición del jugador hacia la posición del cursor
        Vector3 direccion = (posicionCursorEnMundo - posicionJugador).normalized;

        // Calcular la posición inicial de la habilidad asegurándose de que esté a una distancia segura del jugador
        Vector3 posicionInicial = posicionJugador + direccion * distanciaSegura;

        // Instanciar el proyectil desde la posición inicial calculada
        proyectil = Instantiate(prefabProyectil, posicionInicial, Quaternion.identity);

        // Configurar la velocidad del proyectil
        Rigidbody2D rbProyectil = proyectil.GetComponent<Rigidbody2D>();
        if (rbProyectil != null)
        {
            // Aplicar la velocidad al proyectil en la dirección del cursor
            rbProyectil.velocity = direccion * PlayerPrefsSettings.instance.getVelocidadHabilidad();
        }

        // Destruir el proyectil después de un cierto tiempo
        Destroy(proyectil, tiempoDeVida);

        // Actualizar el tiempo del último disparo
        tiempoUltimoDisparo = Time.time;
    }
    
}
