using UnityEngine;

public class Product : MonoBehaviour
{
    public string productName;

    public int scoreValue = 100;

    public void Collect()
    {
        Debug.Log("Collected: " + productName);

        if (ShoppingListManager.instance != null)
        {
            ShoppingListManager.instance.CollectItem(productName);
        }

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}