using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChimie
{
    private static string Cours1Question1 = "On parle de la loi d'Avogadroi comme une qui décrit la relation enter le volume et la quantité de gaz. " +
        "Existe-t-il d'autres facteurs qui peuvent influencer la validité de cette formule?";
    private static string Cours1Reponse1 = "La réponse est oui. En effet, il y a deux facteurs qui déterminent si on peut appliquer cette loi. Ces deux facteurs sont avoir une température et pression constantes.";

    private static string Cours1Question2 = "Quel est la relation de la loi d'avogadro correcte?";
    private static string Cours1Reponse2 = "Les quatres constantes de la relation sont V1, n1, V2 et n2. Cette relation s'exprime par : V1/n1 = V2/n2";

    private static string Cours1Question3 = "Une ballon en caoutchouc de 2L contient 5 mol d'oxygène. Si on ajoute 5 mol d'oxygène supplémentaires, quel sera le nouveau volume du ballon? ";
    private static string Cours1Reponse3 = "On a V1=2L , n1=5mol et n2=5mol+5mol=10mol. Donc, le calcul sera 2x10/5 qui va donner V2=4L";

    public string[] obtenirTestCours1() 
    {
        string[] listeQuestionReponse = new string[6];
        listeQuestionReponse[0] = Cours1Question1;
        listeQuestionReponse[1] = Cours1Reponse1;
        listeQuestionReponse[2] = Cours1Question2;
        listeQuestionReponse[3] = Cours1Reponse2;
        listeQuestionReponse[4] = Cours1Question3;
        listeQuestionReponse[5] = Cours1Reponse3;

        return listeQuestionReponse;
    }
}
