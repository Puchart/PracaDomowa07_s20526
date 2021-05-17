using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemComponent : MonoBehaviour {
    
    public int quantityNumber;
    PlayerMovement PlayerMovement;

    [Header("Settings")]
    public Item item;
    public KeyCode key;
    public ItemType type;

    [Header("UI Components")]
    public Image frame;
    public Image sprite;
    public Text quantity;
    public GameObject tooltip;
    public Text tooltipName;
    public Text tooltipDescription;

    [Header("Colors")]
    public Color highlightColor;

    void Start() {
        
        if (item != null) {
            quantityNumber = item.defaultQuantity;
            type = item.type;
        }
        UpdateItem();
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
       

    }

    void Update() {
        if (Input.GetKeyDown(key)) {
            Use();
        }
    }

    public void UpdateItem() {
        if (item == null) {
            sprite.sprite = null;
            sprite.color = new Color(1, 1, 1, 0);
            quantity.text = "";
        } else {
            sprite.sprite = item.sprite;
            sprite.color = new Color(1, 1, 1, 1);
            quantity.text = quantityNumber + "";
            tooltipName.text = item.itemName;
            tooltipDescription.text = item.description;
        }
    }

    public void SetTooltip(bool active) {
        if (item == null) {
            tooltip.SetActive(false);
        } else {
            tooltip.SetActive(active);
        }
    }

    public void Use() {
        if (item != null) {
            quantityNumber--;

            if(type == ItemType.HEAL) {
               
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                PlayerHealth health = player.GetComponent<PlayerHealth>();
                health.Heal(1);
                Debug.Log("Heal");
                PlayerMovement.HealUsage();
            } else if (type == ItemType.WEAPON){
              PlayerMovement.WeaponUsage();
                GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
                EnemyHealth health = enemy.GetComponent<EnemyHealth>();
                health.Damagio();


            }

            if (quantityNumber <= 0) {
                item = null;
                SetTooltip(false);
            }

            UpdateItem();
            StartCoroutine(HighlightFrame());
        }
    }

    public IEnumerator HighlightFrame() {
        Color currentColor = frame.color;
        frame.color = highlightColor;
        yield return new WaitForSeconds(0.1f);
        frame.color = currentColor;
    }
    public void SetItem(Item itemToSet)
    {
        if(item == itemToSet)
        {
            quantityNumber += itemToSet.defaultQuantity;
        } else
        {
            item = itemToSet;
            quantityNumber = itemToSet.defaultQuantity;
        }
                
             
        UpdateItem();
    }
}

public enum ItemType {
    HEAL,
    WEAPON
}
