using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key1 : MonoBehaviour
{
    BoxCollider Key1Collider;

    public bool Keyy1;
    void Start()
    {
        Key1Collider = gameObject.GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Keyy1 = true;
                Destroy(gameObject, 1);
            }
        }
    }
    void Update()
    {
    }
}