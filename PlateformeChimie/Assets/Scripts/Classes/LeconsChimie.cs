using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeconsChimie
{
    private static string Cours1Lecon1 = "La loi d'Avogadro décrit la relation entre le volume et la quantité d'un gaz. " +
                "Elle stipule que, à température et pression constantes, le volume d'un gaz est directement proportionnel à sa quantité exprimée en nombre de moles.";
 
    private string Cours1Lecon2 = "Comme la division du volume par le nombre de moles est égale à une constante," +
                " on peut comparer deux situations pour le même gaz, en autant que la pression et la température ne varient pas. Il en résulte la relation suivante: "
                + "où V1 représente le volume initial (en mL ou L)   "
                + "n1 représente le nombre de moles initial (en mol)   "
                + "V2 représente le volume final (en mL ou L)   "
                + "n2 représente le nombre de moles final (en mol)";

    private static string Cours1Lecon3 = "Exemple : Un ballon en caoutchouc de 6L contient 3,5mol d'hélium. " +
                "Quel sera le nouveau volume du ballon si on ajoute 5mol d'hélium en considérant la pression et la température constantes?";

    public string[] getCours1() 
    {
        Cours1Lecon2.Replace("//n","/n");
        string[] cours1 = new string[3];
        cours1[0] = Cours1Lecon1;
        cours1[1] = Cours1Lecon2;
        cours1[2] = Cours1Lecon3;

        return cours1;
    }

}
