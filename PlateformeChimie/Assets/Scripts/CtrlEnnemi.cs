using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlEnnemi : MonoBehaviour
{
    float vitesse = 1.5f;
    private new Rigidbody2D rigidbody;

    bool regardeDroite = true;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        anim.SetFloat("VitHorEn", Mathf.Abs(rigidbody.velocity.x));
        anim.SetFloat("VitVerEn", rigidbody.velocity.y);
        deplacer(-vitesse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void retourner()
    {
        Vector2 echelle = new Vector2(-transform.localScale.x, transform.localScale.y);
        transform.localScale = echelle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TomberMort")) 
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}
