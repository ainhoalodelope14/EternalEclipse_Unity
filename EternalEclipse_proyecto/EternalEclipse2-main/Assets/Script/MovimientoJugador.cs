using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    private Animator animador;
    public GameObject menuPausa;
    public GameObject menuMejoras;
    public GameObject menuControles;
    public GameObject menuVictoria;
    public GameObject menuGameOver;

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (menuMejoras.activeSelf || menuControles.activeSelf || menuVictoria.activeSelf || menuGameOver.activeSelf)
        {
            // Si el menú de mejoras está activo, no se debe activar el menú de pausa
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPausa.activeSelf || menuControles.activeSelf || menuVictoria.activeSelf || menuGameOver.activeSelf)
            {
                // Si el menú de pausa está activo, desactívalo
                menuPausa.SetActive(false);
                // Reanuda el juego estableciendo la escala de tiempo a 1
                Time.timeScale = 1f;
            }
            else
            {
                // Si el menú de pausa está inactivo, actívalo
                menuPausa.SetActive(true);
                // Pausa el juego estableciendo la escala de tiempo a 0
                Time.timeScale = 0f;
            }
        }


        // Obtener la entrada del jugador en los ejes horizontal y vertical
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento basado en la entrada del jugador y la velocidad
        Vector3 movimiento = new Vector3(movimientoHorizontal, movimientoVertical, 0f) * PlayerPrefsSettings.instance.getVelocidadPersonaje() * Time.deltaTime;

        // Aplicar el desplazamiento al objeto del jugador
        transform.Translate(movimiento);

        animador.SetFloat("EstaMoviendo", Mathf.Abs(movimientoHorizontal) + Mathf.Abs(movimientoVertical));

        // Invertir el movimiento si el jugador presiona la tecla en la dirección opuesta
        if (movimientoHorizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Invierte la escala en el eje x para voltear el personaje
        }
        else if (movimientoHorizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Restaura la escala original
        }
    }
}
