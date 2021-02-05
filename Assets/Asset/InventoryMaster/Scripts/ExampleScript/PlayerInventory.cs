using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject characterSystem;
    public GameObject craftSystem;
    private Inventory craftSystemInventory;
    private CraftSystem cS;
    private Inventory mainInventory;
    private Inventory characterSystemInventory;
    private Tooltip toolTip;

    private InputManager inputManagerDatabase;
    public Player Player;   // On cree une variable public Player

    int normalSize = 3;

    public void OnEnable()
    {
        Inventory.ItemEquip += OnBackpack;
        Inventory.UnEquipItem += UnEquipBackpack;

        // Desactiver voir ligne 152 a 214 simplement supprimer les // Inventory.ItemEquip += OnGearItem;
        // Desactiver voir ligne 152 a 214 simplement supprimer les // Inventory.ItemConsumed += OnConsumeItem;
        // Desactiver voir ligne 152 a 214 simplement supprimer les // Inventory.UnEquipItem += OnUnEquipItem;

        Inventory.ItemEquip += EquipWeapon;
        Inventory.UnEquipItem += UnEquipWeapon;
    }
    public void OnDisable()
    {
        Inventory.ItemEquip -= OnBackpack;
        Inventory.UnEquipItem -= UnEquipBackpack;

        // Desactiver voir ligne 152 a 214 simplement supprimer les // Inventory.ItemEquip -= OnGearItem;
        // Desactiver voir ligne 152 a 214 simplement supprimer les // Inventory.ItemConsumed -= OnConsumeItem;
        // Desactiver voir ligne 152 a 214 simplement supprimer les // Inventory.UnEquipItem -= OnUnEquipItem;

        Inventory.UnEquipItem -= UnEquipWeapon;
        Inventory.ItemEquip -= EquipWeapon;
    }
    void EquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //add the weapon if you equip the weapon
        }
    }
    void UnEquipWeapon(Item item)
    {
        if (item.itemType == ItemType.Weapon)
        {
            //delete the weapon if you unequip the weapon
        }
    }
    void OnBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
        {
            for (int i = 0; i < item.itemAttributes.Count; i++)
            {
                if (mainInventory == null)
                    mainInventory = inventory.GetComponent<Inventory>();
                mainInventory.sortItems();
                if (item.itemAttributes[i].attributeName == "Slots")
                    changeInventorySize(item.itemAttributes[i].attributeValue);
            }
        }
    }
    void UnEquipBackpack(Item item)
    {
        if (item.itemType == ItemType.Backpack)
            changeInventorySize(normalSize);
    }
    void changeInventorySize(int size)
    {
        dropTheRestItems(size);

        if (mainInventory == null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (size == 3)
        {
            mainInventory.width = 3;
            mainInventory.height = 1;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        if (size == 6)
        {
            mainInventory.width = 3;
            mainInventory.height = 2;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 12)
        {
            mainInventory.width = 4;
            mainInventory.height = 3;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 16)
        {
            mainInventory.width = 4;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
        else if (size == 24)
        {
            mainInventory.width = 6;
            mainInventory.height = 4;
            mainInventory.updateSlotAmount();
            mainInventory.adjustInventorySize();
        }
    }
    void dropTheRestItems(int size)
    {
        if (size < mainInventory.ItemsInInventory.Count)
        {
            for (int i = size; i < mainInventory.ItemsInInventory.Count; i++)
            {
                GameObject dropItem = (GameObject)Instantiate(mainInventory.ItemsInInventory[i].itemModel);
                dropItem.AddComponent<PickUpItem>();
                dropItem.GetComponent<PickUpItem>().item = mainInventory.ItemsInInventory[i];
                dropItem.transform.localPosition = GameObject.FindGameObjectWithTag("Player").transform.localPosition;
            }
        }
    }
    void Start()
    {
        Player = GetComponent<Player>();    // On recupere les variables de stat l' objet Player et de sont component Player
        if (inputManagerDatabase == null)
            inputManagerDatabase = (InputManager)Resources.Load("InputManager");

        if (craftSystem != null)
            cS = craftSystem.GetComponent<CraftSystem>();

        if (GameObject.FindGameObjectWithTag("Tooltip") != null)
            toolTip = GameObject.FindGameObjectWithTag("Tooltip").GetComponent<Tooltip>();
        if (inventory != null)
            mainInventory = inventory.GetComponent<Inventory>();
        if (characterSystem != null)
            characterSystemInventory = characterSystem.GetComponent<Inventory>();
        if (craftSystem != null)
            craftSystemInventory = craftSystem.GetComponent<Inventory>();
    }
    // public void OnConsumeItem(Item item)    // Desactiver car les valeurs d' ajout de restauration, ajout de stat des objets sont ajouter sur l' objet lui meme et pas par rapport au script de l' inventaire (TEST)
    //{
        //for (int i = 0; i < item.itemAttributes.Count; i++)
        //{
            //if (item.itemAttributes[i].attributeName == "Health")
            //{
                //if ((Player.CurrentHP + item.itemAttributes[i].attributeValue) > Player.HPMax)
                //    Player.CurrentHP = Player.HPMax;
                //else
                //    Player.CurrentHP += item.itemAttributes[i].attributeValue;
            //}
            //if (item.itemAttributes[i].attributeName == "Mana")
            //{
                //if ((Player.CurrentMP + item.itemAttributes[i].attributeValue) > Player.MPMax)
                //    Player.CurrentMP = Player.MPMax;
                //else
                //    Player.CurrentMP += item.itemAttributes[i].attributeValue;
            //}
            //if (item.itemAttributes[i].attributeName == "Armor")
            //{
                //if ((Player.Def + item.itemAttributes[i].attributeValue) > Player.MaxDef)
                //    Player.Def = Player.MaxDef;
                //else
                    //Player.Def += item.itemAttributes[i].attributeValue;
            //}
            //if (item.itemAttributes[i].attributeName == "Damage")
            //{
                //if ((Player.Atk + item.itemAttributes[i].attributeValue) > Player.MaxAtk)
                    //Player.Atk = Player.MaxAtk;
                //else
                    //Player.Atk += item.itemAttributes[i].attributeValue;
            //}
        //}
    //}
    // Desactiver car les valeurs d' ajout de stat des armes armures sont ajouter sur l' objet lui meme et pas par rapport au script de l' inventaire (TEST)
    // public void OnGearItem(Item item)    Fonction qui permet lors de l' equipement d'une arme/armure daugmenter les stats associer.
    //{
        //for (int i = 0; i < item.itemAttributes.Count; i++)
        //{
          //  if (item.itemAttributes[i].attributeName == "Health") Ici on augmente les HPMax du perso
          //      Player.HPMax += item.itemAttributes[i].attributeValue;
          //  if (item.itemAttributes[i].attributeName == "Mana") Ici on augmente les MPMax du perso
          //      Player.MPMax += item.itemAttributes[i].attributeValue;
          //  if (item.itemAttributes[i].attributeName == "Armor") Ici on augmente la valeur actuelle de defense du perso sachant que la valeur de MaxDef est de 999
          //      Player.Def += item.itemAttributes[i].attributeValue;
          //  if (item.itemAttributes[i].attributeName == "Damage")
          //      Player.Atk += item.itemAttributes[i].attributeValue;
        //}
    //}
    // public void OnUnEquipItem(Item item) Fonction utiliser lorsque l' on desequipe une arme/armure
    //{
        //for (int i = 0; i < item.itemAttributes.Count; i++)
        //{
            // if (item.itemAttributes[i].attributeName == "Health")
            //    Player.HPMax -= item.itemAttributes[i].attributeValue;
            // if (item.itemAttributes[i].attributeName == "Mana")
            //    Player.MPMax -= item.itemAttributes[i].attributeValue;
            // if (item.itemAttributes[i].attributeName == "Armor")
            //    Player.Def -= item.itemAttributes[i].attributeValue;
            // if (item.itemAttributes[i].attributeName == "Damage")
            //    Player.Atk -= item.itemAttributes[i].attributeValue;
        //}
    //}
    void Update()
    {
        if (Input.GetKeyDown(inputManagerDatabase.CharacterSystemKeyCode))
        {
            if (!characterSystem.activeSelf)
            {
                characterSystemInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                characterSystemInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.InventoryKeyCode))
        {
            if (!inventory.activeSelf)
            {
                mainInventory.openInventory();
            }
            else
            {
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                mainInventory.closeInventory();
            }
        }

        if (Input.GetKeyDown(inputManagerDatabase.CraftSystemKeyCode))
        {
            if (!craftSystem.activeSelf)
                craftSystemInventory.openInventory();
            else
            {
                if (cS != null)
                    cS.backToInventory();
                if (toolTip != null)
                    toolTip.deactivateTooltip();
                craftSystemInventory.closeInventory();
            }
        }

    }

}
