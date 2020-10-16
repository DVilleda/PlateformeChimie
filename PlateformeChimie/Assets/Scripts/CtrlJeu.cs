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
    bool TestActif = false;
    public GameObject Question1, Question2, Question3,FinQuiz,Correct,Incorrect;
    public Text Contenu1, Contenu2, Contenu3;


    TextMeshProUGUI chancesRestantes;
    public GameObject ecranFinPartie;

    void Start()
    {
        TestActif = false;
        chancesRestantes = GameObject.Find("Chances Restantes").GetComponent<TextMeshProUGUI>();
        personnageCtrl = GameObject.Find("Personnage").GetComponent<PersonnageCtrl>();
        Load();
    }

    // Update is called once per frame
    void Update()
    {
            personnageCtrl.deplacer(Input.GetAxis("Horizontal"));

            if (Input.GetAxis("Vertical") > 0)
            {
                personnageCtrl.sauter();
            }

            if (personnageCtrl.getErreursRestantes() < 1)
            {
                gameOver();
            }
            //Verifier qu'on a obtenu le trophé et commencer le test
            if (personnageCtrl.finNiveau && TestActif == false) 
            {
                TestActif = true;
                Question1.SetActive(true);
                Time.timeScale = 0f;
            }
            //Mettre a jour le HP restant
            chancesRestantes.text = personnageCtrl.getErreursRestantes().ToString();
            
            //Rétroaction lorsqu' on répond à une question
            if (Correct.activeSelf || Incorrect.activeSelf) 
            {
                if (Input.anyKeyDown)
                {
                    Correct.SetActive(false);
                    Incorrect.SetActive(false);
                }
            }
            if (FinQuiz.activeSelf) {
                if (Input.anyKeyDown)
                {
                    changerQuestion();
                }
            }
    }
    
    //Valider la question et changer la question
    public void validerQuestion(bool boolean) 
    {
        if (boolean)
        {
            questionBonnes++;
            Correct.SetActive(true);
                changerQuestion();
        }
        else 
        {
            Incorrect.SetActive(true); 
            changerQuestion();
        }
    }

    //Fontionc en chager de changer la question ou de finir le quiz
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
        }
        else if (FinQuiz.activeSelf)
        {
            if (Input.GetKeyDown("z"))
            {
                CompleterNiveau();
            }
            
        }
    }

    //Fonction en charge de calculer les points
    void CalculerPointage() 
    {
        Scene sceneActuelle = SceneManager.GetActiveScene();
        if (sceneActuelle.name == "Level 1")
        {
            ScoreNiveau1Ctrl = (questionBonnes + personnageCtrl.getErreursRestantes())/6*100;
            PlayerPrefs.SetInt("ScoreNiveau1", (int)Math.Ceiling(ScoreNiveau1Ctrl));
        }
    }
    //Fonction pour finir le niveau si on perds
    void gameOver() 
    {
        ecranFinPartie.SetActive(true);
        if (Input.anyKeyDown) {
            SceneManager.LoadScene("Main Menu");
        }
    }

    //Fonction qui sauvegarde, calcule les points et finis le niveau.
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
