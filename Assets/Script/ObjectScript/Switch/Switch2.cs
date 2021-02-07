using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    BoxCollider Switch2Collider;

    public bool Switchh2;
    void Start()
    {
        Switch2Collider = gameObject.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Switchh2 = true;

            }
        }
    }
    void Update()
    {
    }
}
