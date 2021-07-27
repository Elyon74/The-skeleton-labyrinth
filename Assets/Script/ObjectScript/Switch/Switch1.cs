using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    BoxCollider Switch1Collider;
    public bool Switchh1;
void Start()
    {
        Switch1Collider = gameObject.GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider col)   // On indique le collider de base col
    {
        if (col.name == "Player")   // si le collider qui rentre dans la zone sapelle Player on execute
        {
        if (Input.GetKey(KeyCode.E))
        {
            Switchh1 = true;
        }
        }
    }
void Update()
    {

    }
}
