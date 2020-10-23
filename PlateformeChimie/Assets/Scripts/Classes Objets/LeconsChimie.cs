using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeconsChimie
{
    /**
     * Classe qui contient toutes les lecons de chimie a utiliser
     */
    private static string Cours1Lecon1 = "La loi d'Avogadro décrit la relation entre le volume et la quantité d'un gaz. " +
                "La loi dit que, à température et pression constantes, le volume d'un gaz est directement proportionnel à sa quantité exprimée en nombre de moles.";
 
    private string Cours1Lecon2 = "Comme la division du volume par le nombre de moles est égale à une constante," +
                " on peut comparer deux situations pour le même gaz, en autant que la pression et la température ne varient pas. Il en résulte la relation suivante: "
                + "où V1 représente le volume initial (en mL ou L)   "
                + "n1 représente le nombre de moles initial (en mol)   "
                + "V2 représente le volume final (en mL ou L)   "
                + "n2 représente le nombre de moles final (en mol)";

    private static string Cours1Lecon3 = "Exemple : Un ballon en caoutchouc de 6L contient 3,5mol d'hélium. " +
                "Quel sera le nouveau volume du ballon si on ajoute 5mol d'hélium en considérant la pression et la température constantes?" +
        "Nous avons V1=6L , n1=3.5mol , n2=5mol+3.5mol=8.5mol donc il faut trouver V2. Le calcul sera 6 x 8.5 / 3.5. Le résultat sera 14.6L pour V2.";

    private static string Cours2Lecon1 = "La loi de Boyle_Mariotte dit que le volume d'un gaz est inversement proportionnel à sa pression." +
        "À température constante, si la pression externe exercée sur un gaz augmente, le volume diminue et les particules de gaz se raproche et entre en collision plus souvent." +
        "Donc, avec plus de collision, la pression augmente. Inversement, si le volume du contenant est augmenté, la fréquence des collisions diminue et la pression du gaz devient donc plus faible.";
    private static string Cours2Lecon2 = "Comme le produit de la pression par le volume est égal à une constante, on peut comparer deux situations pour le même gaz, en autant que la quantité de gaz et la température ne varient pas." +
        "On aura la relation suivante: P1V1 = P2V2. P1 représente la pression initiale, V1 représente le volume initiale, P2 représente la pression finale et V2 le volume final.";
    private static string Cours2Lecon3 = "Un volume de 20L de dioxyde de carbone a une pression de 120,4 kPa. Quel sera son volume si la pression augmente à 152,2 kPa?" +
        "Avec la formule P1V1=P2V2, on voit qu'on a P1= 120.4kPa, V1=20L et P2=152.2kPa.Pour avoir P2, on fera le calcul suivant: 120.4x20/152.2 = 15.8L=V2.";

    private string[] getCours1() 
    {
        string[] cours1 = new string[3];
        cours1[0] = Cours1Lecon1;
        cours1[1] = Cours1Lecon2;
        cours1[2] = Cours1Lecon3;

        return cours1;
    }

    private string[] getCours2()
    {
        string[] cours2 = new string[3];
        cours2[0] = Cours2Lecon1;
        cours2[1] = Cours2Lecon2;
        cours2[2] = Cours2Lecon3;

        return cours2;
    }

    public string[] getLeconsComplet() 
    {
        string[] listeLecons = new string[6];

        listeLecons[0] = Cours1Lecon1;
        listeLecons[1] = Cours1Lecon2;
        listeLecons[2] = Cours1Lecon3;
        listeLecons[3] = Cours2Lecon1;
        listeLecons[4] = Cours2Lecon2;
        listeLecons[5] = Cours2Lecon3;
        return listeLecons;
    }
}
