using UnityEngine;

public class Checkout : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ShoppingListManager.instance.AllItemsCollected())
            {
                Debug.Log("Shopping Completed!");

                GameController.instance.WinGame();
            }
            else
            {
                Debug.Log("You still need to collect all items!");
            }
        }
    }
}