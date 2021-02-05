using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Debug.log("Texte"); permet d' afficher un texte dans la console unity pour tester une fonctionalliter
    Animator animations1;   // On cree une variable utilisant le component Animation que l' on apelle animations
    CapsuleCollider playerCollider; // On cree une variable utilisant le component Capsule collider que l' on apelle playerCollider qui sert a la collision du joueur

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

    // Variable d' attaque

    public float attackcooldown;    // Delai entre chaque attaque
    public bool isAttacking;    // Retourne Oui si entrain d' attaquer retourne Non si aucune attaque
    public float currentcooldown;    // Delai actuel
    public float attackrange;   // Portee de l' attaque

    // Variable de hauteur de saut
    public Vector3 jumphigh;   // Vector3 haut bas, jumpspeed = hauteur de saut
    public GameObject RayHit;

    // Variable de stat
    // Le fait de rajouter public devant une variable permet de rendre publique celle ci dans l' editeur de unity

    public Image hpImage;  // On creer une variable Image HP
    public Image mpImage;  // On creer une variable Image MP
    public Text hpText; // Debug HP
    public Text mpText; // Debug MP
    public Text atkText;
    public Text atkmagText;
    public Text defText;
    public Text defmagText;


    public int Level;
    public int HPMax;
    public int CurrentHP;
    public int MPMax;
    public int CurrentMP;

    public int Atk;
    public int AtkMag;
    public int Def;
    public int DefMag;

    public int MaxAtk;
    public int MaxAtkMag;
    public int MaxDef;
    public int MaxDefMag;

    public int Vit;
    public int Chc;
    public int Crit;

    public int ExpMax;
    public int CurrentExp;

    public int DamageAmount;
    public int HealAmount;
    public int CastAmount;
    public int RechargeMPAmount;

    // Boolean
    public bool Dead = false;   // Mort
    public bool NoMP = false;   // Pas de MP

    // Ici commence le script du joueur
    void Start()    // S' execute au lancement une fois
    {
        hpImage = GameObject.Find("CurrentHP").GetComponent<Image>();  // On cherche l' objet currentHP dans unity et recupere le component Image
        mpImage = GameObject.Find("CurrentMP").GetComponent<Image>();   // Idem pour MP
        hpText = GameObject.Find("HPDebug").GetComponent<Text>();
        mpText = GameObject.Find("MPDebug").GetComponent<Text>();
        atkText = GameObject.Find("Atk1").GetComponent<Text>();
        atkmagText = GameObject.Find("Atkmag1").GetComponent<Text>();
        defText = GameObject.Find("Def1").GetComponent<Text>();
        defmagText = GameObject.Find("Defmag1").GetComponent<Text>();
        animations1 = gameObject.GetComponent<Animator>();  // On charge le component Animation qui est egal a animations
        playerCollider = gameObject.GetComponent<CapsuleCollider>();     // On charge le component CapsuleCollider qui est egal a playerCollider
        RayHit = GameObject.Find("RayHit");
        animations1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
        }
        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);  // Sprint en Avant Maj Gauche + Z

        }
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0, 0, -(walkSpeed / 2)* Time.deltaTime);  // Ici le personnage recule il reculera deux fois moins vite quil avancera
        }
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);    // Ici le personnage tourne a gauche (rotation susceptible de changer)
        }
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);    // Ici le personnage tourne a droite (rotation susceptible de changer)
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())    // Ici le personnage saute && isGrounded() sert a verifier que la boolean est vrai, Down veut dire une fois
        {
            Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;  // Preparation du saut on stock la valeur de la velociter avec .velocity du component rigidbody
            v.y = jumphigh.y;    // Enfin on dis que le vecteur de saut est egal a la hauteur de saut sur laxe y

            gameObject.GetComponent<Rigidbody>().velocity = jumphigh;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))   // Si on effectue un clic gauche a la souris,  mouse 1 = clic droit
        {
            Attack();   // On apelle notre fonction d' attaque
        }

        // Pour la barre HP la barre de vie de l' image est egal au hp courant / HPMax 
        hpImage.fillAmount = CurrentHP / HPMax;
        // Idem pour la barre MP
        mpImage.fillAmount = CurrentMP / MPMax;

        // Section Debug
        hpText.text = CurrentHP.ToString(); // On dit que La variable hpText qui est un component text est egal a la variable CurrentHP que l' on convertit de integer en string pour lajouter au texte
        mpText.text = CurrentMP.ToString();
        atkText.text = Atk.ToString();
        atkmagText.text = AtkMag.ToString();
        defText.text = Def.ToString();
        defmagText.text = DefMag.ToString();

        if (CurrentHP > HPMax)
        {
            CurrentHP = HPMax;  // Si la vie depasse les HPMax on la remet au HPMax
        }
        if (CurrentMP > MPMax)
        {
            CurrentMP = MPMax;  // Idem
        }
        if (CurrentHP <= 0)
        {
            Dead = true;    // Si la vie est egal a 0 boolean Dead retourne vrai = mort du perso
        }
        if (CurrentMP <= 0)
        {
            NoMP = true;    // Si les mp sont egaux a 0 boolean NoMP retourne vrai = impossible de cast 0 mp
        }
        if (Dead == true)
        {
            SceneManager.LoadScene("TitleScreen");
            CurrentHP = HPMax;
        }
        if (NoMP == true)
        {

        }
        if (isAttacking == true)
        {
            currentcooldown -= Time.deltaTime;   // Si on attaque on baisse le temp du cooldown au fur et a mesure
        }
        if (currentcooldown <= 0)   // Une fois le cooldown redescendue a 0 le personnage peut de nouveau attaquer
        {
            currentcooldown = attackcooldown;
            isAttacking = false;
        }
        if (CurrentExp >= ExpMax)
        {
            LevelUp(Level);
        }
    }
    public void Damage(int DamageAmount)
    {
        CurrentHP -= DamageAmount;  // Quand on prend un coup on retire de la vie par rapport a la variable DamageAmount
    }
    public void Heal(int HealAmount)
    {
        CurrentHP += HealAmount;    // Quand on soigne avec un sort ou une potion de HP on ajoute de la vie par rapport a la variable HealAmount
    }
    public void Cast(int CastAmount)
    {
        CurrentMP -= CastAmount;    // Quand on cast un sort on retire des mp par rapport a la variable CastAmount
    }
    public void RechargeMP(int RechargeMPAmount)
    {
        CurrentMP += RechargeMPAmount;  // Quand on utilise une potion de MP ou evenement on ajoute des mp par rapport a la variable RechargeMPAmount
    }
    public void LevelUp(int Level)
    {
            CurrentExp = 0;
            ExpMax += 50;   // On ajoute 50 dexp max en plus necessaire a levelup
            Level += 1; // On rajoute un niveau au personnage
            HPMax += 10; // On augmente ces HP Max de 10 point
            MPMax += 5; // On augmente ces MP Max de 5 point
    }
    public void Attack()    // On joue l' attaque
    {
        if (!isAttacking)   // Si on attaque
        {
            // On cree un raycast qui verifie se quil touche
            if (Physics.Raycast(RayHit.transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, attackrange)) // Si un ennemi est toucher par rapport a la position
            // du joueur sa direction, le coup et la portee.
            {
                Debug.DrawLine(RayHit.transform.position, hit.point, Color.red);    // Un raycast ne saffiche pas de base sur cette ligne on laffiche pour
                // debug verifier que les coups fonctionnent bien .
                if (hit.transform.tag == "Ennemy")
                {
                    print(hit.transform.name + "detecter");
                }
            }
        }
        isAttacking = true;
    }
}