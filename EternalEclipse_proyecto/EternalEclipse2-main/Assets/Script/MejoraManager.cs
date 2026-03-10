using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MejoraManager : MonoBehaviour
{
    public GameObject pantallaMejoras; // Pantalla donde se van a mostar las mejoras
    public Button[] botonesMejora;   // Botones que tendrán las mejoras
    public GameObject tooltipPanel; // El panel que actúa como el tooltip

    public Text tooltipText; // El texto dentro del panel que muestra la descripción de la mejora

    private List<Mejora> mejorasDisponibles = new List<Mejora>(); // Lista con todas las mejoras

    public Sprite[] abilitySprites; // Inicializa los sprites para usar en los botones

    public GameObject boss;

    void Start()
    {
        // Inicializar las mejoras
        mejorasDisponibles.Add(new Mejora("Velocidad", "Aumenta la velocidad del personaje", MejorarVelocidad));
        mejorasDisponibles.Add(new Mejora("Cooldown Habilidad", "Reduce el cooldown de la habilidad", MejorarCooldownHabilidad));
        mejorasDisponibles.Add(new Mejora("Velocidad Habilidad", "Aumenta la velocidad de la habilidad", MejorarVelocidadHabilidad));
        mejorasDisponibles.Add(new Mejora("Regeneración de Vida", "Aumenta la regeneración de vida", MejorarRegeneracionVida));
        mejorasDisponibles.Add(new Mejora("Tiempo de Regeneración", "Reduce el tiempo de regeneración de vida", MejorarTiempoRegeneracionVida));
        mejorasDisponibles.Add(new Mejora("Salud Máxima", "Aumenta la salud máxima", MejorarSaludMaxima));

        // Asignar mejoras aleatorias a los botones
        AsignarMejorasAleatorias();
    }

    void AsignarMejorasAleatorias()
    {
        List<Mejora> mejorasSeleccionadas = new List<Mejora>();

        while (mejorasSeleccionadas.Count < 3) // Se repite hasta que tenga 3 mejoras
        {
            int index = Random.Range(0, mejorasDisponibles.Count);
            Mejora mejora = mejorasDisponibles[index];
            if (!mejorasSeleccionadas.Contains(mejora)) // Si contiene esa mejora ya no es valido
            {
                mejorasSeleccionadas.Add(mejora); // Añade la mejora a las mejoras seleccionadas
            }
        }

        for (int i = 0; i < 3; i++) // Bucle para colocar en los botones las tres mejoras
        {
            string nombreHabilidad = mejorasSeleccionadas[i].nombre;
            Sprite habilidadSprite = null;
            switch (nombreHabilidad) // Según el nombre de la habilidad se aplica dicho metodo y se coloca el sprite correspondiente
            {
                case "Velocidad":
                    botonesMejora[i].onClick.AddListener(MejorarVelocidad);
                    habilidadSprite = abilitySprites[0];
                    break;
                case "Cooldown Habilidad":
                    botonesMejora[i].onClick.AddListener(MejorarCooldownHabilidad);
                    habilidadSprite = abilitySprites[1];
                    break;
                case "Velocidad Habilidad":
                    botonesMejora[i].onClick.AddListener(MejorarVelocidadHabilidad);
                    habilidadSprite = abilitySprites[2];
                    break;
                case "Regeneración de Vida":
                    botonesMejora[i].onClick.AddListener(MejorarRegeneracionVida);
                    habilidadSprite = abilitySprites[3];
                    break;
                case "Tiempo de Regeneración":
                    botonesMejora[i].onClick.AddListener(MejorarTiempoRegeneracionVida);
                    habilidadSprite = abilitySprites[4];
                    break;
                case "Salud Máxima":
                    botonesMejora[i].onClick.AddListener(MejorarSaludMaxima);
                    habilidadSprite = abilitySprites[5]; 
                    break;
                default:
                    Debug.LogWarning("Habilidad no existe: " + nombreHabilidad);
                    break;
            }

            botonesMejora[i].image.sprite = habilidadSprite; // Se coloca el sprite
            botonesMejora[i].gameObject.AddComponent<BotonesHover>().tooltipPanel = tooltipPanel; // Panel para mostrar descripción de mejora
            botonesMejora[i].gameObject.GetComponent<BotonesHover>().tooltipText = tooltipText; // Tooltip con la descripción de la mejora
            botonesMejora[i].gameObject.GetComponent<BotonesHover>().upgradeDescription = mejorasSeleccionadas[i].descripcion; // Se coloca dicha descripción
        }
    }

    void MejorarVelocidad() // Mejora velocidad del jugador
    {
        PlayerPrefsSettings.instance.setVelocidadPersonaje(PlayerPrefsSettings.instance.getVelocidadPersonaje() + 0.8f);
        proximaOleada();
    }

    void MejorarCooldownHabilidad() // Mejora cooldown de la habilidad del jugador
    {
        PlayerPrefsSettings.instance.setCooldownHabilidad(PlayerPrefsSettings.instance.getCooldownHabilidad() - 0.5f);
        proximaOleada();
    }

    void MejorarVelocidadHabilidad() // Mejora velocdad de habilidad
    {
        PlayerPrefsSettings.instance.setVelocidadHabilidad(PlayerPrefsSettings.instance.getVelocidadHabilidad() + 1f);
        proximaOleada();
    }

    void MejorarRegeneracionVida() // Mejora regeneración de vida
    {
        PlayerPrefsSettings.instance.setRegeneracionVida(PlayerPrefsSettings.instance.getRegeneracionVida() + 0.5f);
        proximaOleada();
    }

    void MejorarTiempoRegeneracionVida() // Reduce el tiempo de regeneración de vida
    {
        PlayerPrefsSettings.instance.setTiempoRegeneracionVida(PlayerPrefsSettings.instance.getTiempoRegeneracionVida() - 0.5f);
        proximaOleada();
    }

    void MejorarSaludMaxima() // Mejora de la salud maxima
    {
        PlayerPrefsSettings.instance.setSaludMaxima(PlayerPrefsSettings.instance.getSaludMaxima() + 5f);
        proximaOleada();
    }

    void proximaOleada() // Se para a la siguiente oleada
    {
        Time.timeScale = 1f; //Vuelva a empezar la oleada
        pantallaMejoras.SetActive(false); //Pantalla mejoras quitar
        // Incrementar el número de oleada
        int numOleada = PlayerPrefsSettings.instance.getNumOleada() + 1;
        PlayerPrefsSettings.instance.setNumOleada(numOleada);
        // Actualizar el texto del número de la oleada
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}

