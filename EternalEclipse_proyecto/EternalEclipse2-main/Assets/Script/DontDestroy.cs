using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;
    private AudioSource audioSource;


    void Awake()
    {
        if (instance == null) // Para que la musica no se destruya cuando se inicia de nuevo la partida (pasa a la sigueiten oleada)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else
        {
            Destroy(gameObject);
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si esta en el menu principal o puntuaicones o info no suena la musica
        if ((scene.name == "MenuPrincipal") || (scene.name == "Puntuaciones") || (scene.name == "Info"))
        {
            audioSource.Stop();
        }
        else if (audioSource.isPlaying == false)
        {
            // Si esta en el juego suena la música
            audioSource.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
