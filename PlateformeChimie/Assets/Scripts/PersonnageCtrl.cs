using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageCtrl : MonoBehaviour
{
    [SerializeField]
    float vitesse = 0.1f;

    [SerializeField]
    float poussee = 10f;

    private Rigidbody2D rb;
    private Vector2 positionDebutNiveau;
    [SerializeField]
    int erreursRestantes = 3;
    Animator anim;

    bool regardeDroite = true;
    public bool finNiveau = false;

    //paramètres pour la vérification du contact au sol
    [SerializeField]
    bool toucheSol = true;
    [SerializeField]
    Transform objDetectSol;
    [SerializeField]
    float rayonDetectSol = 0.02f;
    [SerializeField]
    LayerMask coucheSol;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        positionDebutNiveau = transform.position;

        anim.SetBool("ToucheSol", true);
    }

    void FixedUpdate()
    {
        toucheSol = Physics2D.OverlapCircle(objDetectSol.position, rayonDetectSol, coucheSol);
        anim.SetBool("ToucheSol", toucheSol);
        anim.SetFloat("VitHor", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("VitVert", rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fonction en charge du deplacement du joueur
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
        rb.velocity = new Vector2(vitesse * direction, rb.velocity.y);
    }
    
    //Retourne le sprite
    public void retourner()
    {
        Vector2 echelle = new Vector2(-transform.localScale.x, transform.localScale.y);
        transform.localScale = echelle;
    }

    //Fait le personnage sauter
    public void sauter()
    {
        if (toucheSol)
        {
            rb.AddForce(new Vector2(0, poussee));
        }
    }

    //REtourner le nombre de vies qui reste
    public double getErreursRestantes() 
    {
        return erreursRestantes;
    }

    //En charge d'animer la blessure, repositionner le joueur et enlever une vie
    public void blesser() 
    {
        anim.SetTrigger("Blessure");
        rb.position = positionDebutNiveau;
        erreursRestantes--;
    }

    //Repositionne le joueur au debut du niveau
    void recommencerNiveau() 
    {
        rb.position = positionDebutNiveau;
        erreursRestantes--;
    }
    
    //Met le joueur comme ayant fini le niveau
    void finNiveauCourant() 
    {
        finNiveau = true;
    }

    //Gestion de collision avec les differents objet du monde
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi") || collision.gameObject.CompareTag("EnnemiV2"))
        {
            blesser();
        }
        else if (collision.gameObject.CompareTag("TomberMort"))
        {
            recommencerNiveau();
        } else if (collision.gameObject.CompareTag("FinNiveau")) 
        {
            finNiveauCourant();
        }
    }
}
