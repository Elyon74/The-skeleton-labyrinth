using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book1 : MonoBehaviour
{
    BoxCollider Book1Collider;

    public bool Bookk1;
    void Start()
    {
        Book1Collider = gameObject.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Bookk1 = true;
                Destroy(gameObject, 1);
            }
        }
    }
    void Update()
    {
    }
}
