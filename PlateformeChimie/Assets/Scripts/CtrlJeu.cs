using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class CtrlJeu : MonoBehaviour
{
    PersonnageCtrl personnageCtrl;

    //Scores des niveaux
    [SerializeField]
    double ScoreNiveau1Ctrl;
    [SerializeField]
    double ScoreNiveau2Ctrl;
    [SerializeField]
    int questionBonnes = 0;

    //Variables Pour le test de chimie
    public Rigidbody2D rbFinMonde;
    private TestChimie testChimie = new TestChimie();
    string[] testChimieContenu;
    bool TestActif = false;
    public GameObject Question1, Question2, Question3,FinQuiz;
    public Text Contenu1, Contenu2, Contenu3;


    TextMeshProUGUI chancesRestantes;
    public GameObject ecranFinPartie;

    //Vérification de l'existance du singleton
    void Start()
    {
        TestActif = false;
        Scene sceneActuelle = SceneManager.GetActiveScene();
        if(sceneActuelle.name == "Level 1"){
            chancesRestantes = GameObject.Find("Chances Restantes").GetComponent<TextMeshProUGUI>();
            personnageCtrl = GameObject.Find("Personnage").GetComponent<PersonnageCtrl>();
            testChimieContenu = testChimie.obtenirTestCours1();
        }
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (personnageCtrl != null) {
            personnageCtrl.deplacer(Input.GetAxis("Horizontal"));

            if (Input.GetAxis("Vertical") > 0)
            {
                personnageCtrl.sauter();
            }

            if (personnageCtrl.getErreursRestantes() < 0)
            {
                gameOver();
            }
            if (personnageCtrl.finNiveau && TestActif == false) 
            {
                TestActif = true;
                Question1.SetActive(true);
                Time.timeScale = 0f;
            }
            chancesRestantes.text = personnageCtrl.getErreursRestantes().ToString();
        }
    }

    public void validerQuestion(bool boolean) 
    {
        if (boolean)
        {
            questionBonnes++;
            changerQuestion();
        }
        else 
        {
            changerQuestion();
        }
    }

    void changerQuestion()
    {
        if (Question1.activeSelf)
        {
            Question1.SetActive(false);
            Question2.SetActive(true);
        }
        else if (Question2.activeSelf)
        {
            Question2.SetActive(false);
            Question3.SetActive(true);
        } else if(Question3.activeSelf)
        {
            Question3.SetActive(false);
            FinQuiz.SetActive(true);
            if(Input.anyKeyDown)
            {
                CompleterNiveau();
            }
        }
    }

    void CalculerPointage() 
    {
        Scene sceneActuelle = SceneManager.GetActiveScene();
        if (sceneActuelle.name == "Level 1")
        {
            ScoreNiveau1Ctrl = (questionBonnes + personnageCtrl.getErreursRestantes())/6*100;
            PlayerPrefs.SetInt("ScoreNiveau1", (int)Math.Ceiling(ScoreNiveau1Ctrl));
        }
    }
    void gameOver() 
    {
        ecranFinPartie.SetActive(true);
        if (Input.anyKeyDown) {
            SceneManager.LoadScene("Main Menu");
        }
    }

    void CompleterNiveau() 
    {
        Save();
        CalculerPointage();
        SceneManager.LoadScene("Selecteur Niveau");
        Time.timeScale = 1f;
    }

    public void Save() 
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream fichier = File.Create(Application.persistentDataPath + "/saveData.dat");

        SaveData dataJeu = new SaveData();
        dataJeu.ScoreNiveau1 = ScoreNiveau1Ctrl;
        dataJeu.ScoreNiveau2 = ScoreNiveau2Ctrl;

        bf.Serialize(fichier, dataJeu);
        fichier.Close();
    }

    public void Load() 
    {
        if (File.Exists(Application.persistentDataPath +"/saveData.dat")) 
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fichier = File.Open(Application.persistentDataPath + "/saveData.dat",FileMode.Open);
            SaveData dataJeu = (SaveData)bf.Deserialize(fichier);
            fichier.Close();

            ScoreNiveau1Ctrl = dataJeu.ScoreNiveau1;
            ScoreNiveau2Ctrl = dataJeu.ScoreNiveau2;
        }
    }
}
