using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion1 : MonoBehaviour
{
    BoxCollider Potion1Collider;

    public bool Potionn1;
    void Start()
    {
        Potion1Collider = gameObject.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Potionn1 = true;
                Destroy(gameObject, 1);
            }
        }
    }
    void Update()
    {
    }
}
