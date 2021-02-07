using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion2 : MonoBehaviour
{
    BoxCollider Potion2Collider;

    public bool Potionn2;
    void Start()
    {
        Potion2Collider = gameObject.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Potionn2 = true;
                Destroy(gameObject, 1);
            }
        }
    }
    void Update()
    {
    }
}
