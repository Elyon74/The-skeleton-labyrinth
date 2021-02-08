using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest1 : MonoBehaviour
{
    BoxCollider Chest1Collider;

    public Key1 Key1;
    public GameObject Cylindre;
    void Start()
    {
        Key1 = GameObject.Find("Key1").GetComponent<Key1>();
        Chest1Collider = gameObject.GetComponent<BoxCollider>();
        Cylindre = GameObject.Find("Cylindre");
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (Key1.Keyy1 == true)
                {
                    Cylindre.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime * 100f), Space.World);
                    Key1.Keyy1 = false;
                }
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.name == "Player")
        {
            Cylindre.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, Time.deltaTime * 100f), Space.World);
        }
    }
    void Update()
    {
    }
}
