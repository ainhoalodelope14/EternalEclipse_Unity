using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnemy : MonoBehaviour
{

    public string tag; // Tag de la colision

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisión es con un objeto con el tag "enemigo"
        if (collision.gameObject.CompareTag(tag))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
