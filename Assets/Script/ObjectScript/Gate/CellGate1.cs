using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGate1 : MonoBehaviour
{
    public Switch1 Switch1;

    void Start()
    {
        Switch1 = GameObject.Find("chaine interupteur").GetComponent<Switch1>();
    }

    void Update()
    {
      if (Switch1.Switchh1 == true) // Pour recuperer une variable bool on utilise le nom de la variable public cree . le nom de la variable bool voulu.
      {  // Vector3 ensemble de trois axe x z y on rajoute f pour indiquer une valeur float et Space.world Time.deltaTime permet de faire ici une rotation de 70 en en z par seconde.
          this.gameObject.transform.Rotate(new Vector3(0.0f, Time.deltaTime * 50f, 0.0f), Space.World);
      }
    }
}
