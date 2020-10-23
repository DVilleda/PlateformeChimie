using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlProfesseur : MonoBehaviour
{
    public string leconsCoursActuelle="";
    public int index;
    public GameObject leconAffichage;
    public Text leconText;
    private LeconsChimieCtrl leconsChimieCtrl = new LeconsChimieCtrl();

    private new Rigidbody2D rigidbody;

    //Fonction en charge de montrer une lecon de chimie selon le numero du professeur
    public void MontrerLecon() 
    {
        leconsCoursActuelle = leconsChimieCtrl.getLeconsChimieCours().GetValue(index).ToString();
        leconText.text = leconsCoursActuelle?.ToString();
    }

    //Cache la lecon et remet le jeu en marche
    private void CacherLecon() 
    {
        if (leconAffichage.activeSelf && Input.GetKeyDown("z")) 
        {
            leconAffichage.SetActive(false);
            Time.timeScale = 1f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        leconAffichage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CacherLecon();
    }

    //Gestion des collision avec le joueur.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Joueur"))
        {
            leconAffichage.SetActive(true);
            MontrerLecon();
            Time.timeScale = 0f;
        }
    }
}
