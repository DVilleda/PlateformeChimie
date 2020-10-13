using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeCtrl : MonoBehaviour
{
    private Rigidbody2D plateforme2D;
    float vitesse = 2f;
    float deltaY = 3f;
    private Vector2 positionInitiale;
    // Start is called before the first frame update
    void Start()
    {
        positionInitiale = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        deplacementVertical(vitesse);
    }

    void deplacementVertical(float vitesse) 
    {
        transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.time * vitesse,deltaY) -3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Joueur"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Joueur") || collision.gameObject.CompareTag("Ennemi"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
