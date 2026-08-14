using UnityEngine;

// UPGRADED VERSION — replaces your old Product.cs
// Same logic, plus two OPTIONAL fields:
//   collectSound  -> plays a sound when picked up
//   collectEffect -> spawns a particle prefab when picked up
// If you leave them empty, everything works exactly like before.
public class Product : MonoBehaviour
{
    public string productName;
    public int scoreValue = 100;

    [Header("Optional pickup feedback")]
    public AudioClip collectSound;
    public GameObject collectEffect;

    public void Collect()
    {
        Debug.Log("Collected: " + productName);

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.8f);
        }

        if (collectEffect != null)
        {
            GameObject fx = Instantiate(
                collectEffect,
                transform.position,
                Quaternion.identity
            );
            Destroy(fx, 2f); // clean up the particles after 2 seconds
        }

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
