using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mejoras : MonoBehaviour
{
    public GameObject pantallaMejoras;
    public Button siguienteOleada;
    public Text textOleada;
    public int numOleada = 1;

    // Start is called before the first frame update
    void Start()
    {
        siguienteOleada.onClick.AddListener(proximaOleada);
        // Obtén el número de oleada actualizado
        int numOleada = PlayerPrefsSettings.instance.getNumOleada();
        // Actualiza el texto del Game Data con el número de oleada actualizado
        textOleada.text = "Oleada: " + numOleada.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void proximaOleada()
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
