using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShoppingListManager : MonoBehaviour
{
    public static ShoppingListManager instance;

    public TMP_Text shoppingListText;

    private List<string> requiredItems = new List<string>()
    {
        "Apple",
        "Milk",
        "Bread",
        "Cereal",
        "Juice"
    };

    private HashSet<string> collectedItems = new HashSet<string>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateShoppingList();
    }

    public void CollectItem(string itemName)
    {
        if (requiredItems.Contains(itemName))
        {
            collectedItems.Add(itemName);
        }

        UpdateShoppingList();
    }

    void UpdateShoppingList()
    {
        string displayText = "<b>SHOPPING LIST</b>\n\n";

        foreach (string item in requiredItems)
        {
            if (collectedItems.Contains(item))
            {
                displayText += "[X] " + item + "\n";
            }
            else
            {
                displayText += "[ ] " + item + "\n";
            }
        }

        displayText += "\nItems: "
            + collectedItems.Count
            + " / "
            + requiredItems.Count;

        if (collectedItems.Count == requiredItems.Count)
        {
            displayText += "\n\nGO TO CHECKOUT!";
        }

        shoppingListText.text = displayText;
    }

    public bool AllItemsCollected()
    {
        return collectedItems.Count == requiredItems.Count;
    }
}