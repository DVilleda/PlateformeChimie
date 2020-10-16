using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CtrlEnnemi : MonoBehaviour
{
    [SerializeField]
    float vitesse = 1.5f;
    [SerializeField]
    float rangeMouvement = 5f;

    private new Rigidbody2D rigidbody;
    private Vector3 ennemiPositionInitiale;
    private Vector3 ennemiPosition;

    bool regardeDroite = true;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ennemiPositionInitiale = transform.position;
    }

    void FixedUpdate()
    {
        anim.SetFloat("VitHorEn", Mathf.Abs(rigidbody.velocity.x));
        anim.SetFloat("VitVerEn", rigidbody.velocity.y);

        //Verifier si on a un ennemi de type 1 ou 2 pour lui donner le deplacement correct
        if (rigidbody.CompareTag("Ennemi"))
        {
            deplacer(-vitesse);
        }
        else if (rigidbody.CompareTag("EnnemiV2"))
        {
            DeplacerBidirection(rangeMouvement);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ennemiPosition = transform.position;
    }
    //Fonction en charge de faire l'ennemi se deplacer 
    public void deplacer(float direction)
    {
        if (direction > 0 && !regardeDroite)
        {
            regardeDroite = true;
            retourner();
        }
        else if (direction < 0 && regardeDroite)
        {
            regardeDroite = false;
            retourner();
        }
        rigidbody.velocity = new Vector2(vitesse * direction, rigidbody.velocity.y);
    }

    //Fonction en charge de faire une ennemi se deplace de gauche a droite dans une distance fixe
    void DeplacerBidirection(float rangeMouvement) 
    {
        if (regardeDroite == true )
        {
            deplacer(vitesse);
            if (ennemiPosition.x > ennemiPositionInitiale.x + rangeMouvement) {
               regardeDroite = false;
                retourner();
            }
        } else if (!regardeDroite)
        {
            deplacer(-vitesse);
            if (ennemiPosition.x < ennemiPositionInitiale.x - rangeMouvement)
            {
                regardeDroite = true;
                retourner();
            }
        }
    }

    //Retourner le sprite
    public void retourner()
    {
        Vector2 echelle = new Vector2(-transform.localScale.x, transform.localScale.y);
        transform.localScale = echelle;
    }
    //Detruire l'ennemi s'il tombe de la map
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TomberMort")) 
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}
