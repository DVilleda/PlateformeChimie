using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlJeu : MonoBehaviour
{
    PersonnageCtrl personnageCtrl;
    // Start is called before the first frame update
    void Start()
    {
        personnageCtrl = GameObject.Find("Personnage").GetComponent<PersonnageCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        personnageCtrl.deplacer(Input.GetAxis("Horizontal"));

        if (Input.GetAxis("Vertical") > 0) {
            personnageCtrl.sauter();
        }
    }
}
