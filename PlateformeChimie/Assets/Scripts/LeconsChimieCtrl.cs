using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeconsChimieCtrl
{
    private LeconsChimie leconsChimie = new LeconsChimie();

    private string[] listeLeconsCours;

    public string getLeconActuelle(int i) 
    {
        return listeLeconsCours[i];
    }
    public string[] getLeconsChimieCours1() 
    {
        listeLeconsCours = leconsChimie.getCours1();
        return listeLeconsCours;
    }




}
