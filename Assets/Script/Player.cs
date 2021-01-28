using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator animations;   // On cree une variable utilisant le component Animation que l' on apelle animations

    // Variable de vitesse

    public float walkSpeed; // Vitesse marche
    public float runSpeed;  // Vitesse course
    public float turnSpeed; // Vitesse rotation

    //Touche deplacement

    public string inputFront;   // Avancer
    public string inputBack;    // Reculer
    public string inputLeft;    // Gauche
    public string inputRight;   // Droite
    public string Playername = "Squelette"; // Nom du personnage

    // Variable de hauteur de saut
    public Vector3 jumphigh;   // Vector3 haut bas, jumpspeed = hauteur de saut
    
    // Collision du joueur
    CapsuleCollider playerCollider; // On cree une variable utilisant le component Capsule collider que l' on apelle playerCollider qui sert a la collision du joueur

    // Variable de stat
    // Le fait de rajouter public devant une variable permet de rendre publique celle ci dans l' editeur de unity

    public int HPMax = 10;
    public int CurrentHP = 10;
    public int MPMax = 10;
    public int CurrentMP = 10;

    public int Atk = 1;
    public int AtkMag = 1;
    public int Def = 1;
    public int DefMag = 1;

    public int Vit = 1;
    public int Chc = 1;
    public int Crit = 1;

    public int ExpMax = 10;
    public int CurrentExp = 0;

    // Boolean
    public bool Dead = false;   // Mort
    public bool NoMP = false;   // Pas de MP

    // Ici commence le script du joueur
    void Start()    // S' execute au lancement une fois
    {
        animations = gameObject.GetComponent<Animator>();  // On charge le component Animation qui est egal a animations
        playerCollider = gameObject.GetComponent<CapsuleCollider>();     // On charge le component CapsuleCollider qui est egal a playerCollider
    }
    bool isGrounded()
    {
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z), 0.16f);
    }   // - 0.1f = raycast on tire un trait dune petite taille pour verifier le contact du sol en y .  // 0.16f est le radius de du capsulecollider
    void Update()   // S' execute a chaque frame
    {
        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))   // ! Veut dire de ne pas appuyer sur Maj Gauche, && veut dire et
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);  // Personnage avance, on effectue une transformation de la position du joueur par rapport a sa vitesse de marche dans le temp
            animations.Play("Walk01");    // On joue l' animation marcher lier au perso sur Unity       // ATTENTION ANIMATION PAS LU
        }
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);  // Sprint en Avant Maj Gauche + Z
            animations.Play("Run");
        }
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2)* Time.deltaTime);  // Ici le personnage recule il reculera deux fois moins vite quil avancera
            animations.Play("Walk01");
        }
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);    // Ici le personnage tourne a gauche (rotation susceptible de changer)
            animations.Play("Walk01");
        }
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);    // Ici le personnage tourne a droite (rotation susceptible de changer)
            animations.Play("Walk01");
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())    // Ici le personnage saute && isGrounded() sert a verifier que la boolean est vrai, Down veut dire une fois
        {
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;  // Preparation du saut on stock la valeur de la velociter avec .velocity du component rigidbody
            v.y = jumphigh.y;    // Enfin on dis que le vecteur de saut est egal a la hauteur de saut sur laxe y

            gameObject.GetComponent<Rigidbody>().velocity = jumphigh;
        }
    }
}