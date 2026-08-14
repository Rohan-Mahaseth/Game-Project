using System.Collections.Generic;
using TMPro;
using UnityEngine;

// UPGRADED VERSION — replaces your old ShoppingListManager.cs
// Same logic, but the list now uses colors and strikethrough:
//   collected  ->  green [X] + crossed-out gray name
//   remaining  ->  orange [ ] + white name
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
        string displayText =
            "<b><color=#3DDC97>SHOPPING LIST</color></b>\n\n";

        foreach (string item in requiredItems)
        {
            if (collectedItems.Contains(item))
            {
                displayText +=
                    "<color=#3DDC97>[X]</color> " +
                    "<s><color=#8A9BB0>" + item + "</color></s>\n";
            }
            else
            {
                displayText +=
                    "<color=#FF9F43>[  ]</color> " +
                    "<color=#F5F7FA>" + item + "</color>\n";
            }
        }

        displayText += "\n<color=#F5F7FA>Items: "
            + collectedItems.Count
            + " / "
            + requiredItems.Count + "</color>";

        if (collectedItems.Count == requiredItems.Count)
        {
            displayText +=
                "\n\n<b><color=#FF9F43>GO TO CHECKOUT!</color></b>";
        }

        shoppingListText.text = displayText;
    }

    public bool AllItemsCollected()
    {
        return collectedItems.Count == requiredItems.Count;
    }
}
