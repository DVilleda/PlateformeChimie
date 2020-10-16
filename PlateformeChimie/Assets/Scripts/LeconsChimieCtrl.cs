using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeconsChimieCtrl
{
    private LeconsChimie leconsChimie = new LeconsChimie();

    private string[] listeLeconsCours;

    //Charger une lecon precise selon l'index
    public string getLeconActuelle(int i) 
    {
        return listeLeconsCours[i];
    }
    //Obtiens toutes les lecons de chimie dans la classe LeconChimie
    public string[] getLeconsChimieCours() 
    {
        listeLeconsCours = leconsChimie.getLeconsComplet();
        return listeLeconsCours;
    }




}
