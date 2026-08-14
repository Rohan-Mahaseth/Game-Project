using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 2.2f;

    public TMP_Text interactionText;

    private Product currentProduct;

    void Update()
    {
        FindClosestProduct();

        if (currentProduct != null)
        {
            if (interactionText != null)
            {
                interactionText.text =
                    "Press E to collect " + currentProduct.productName;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentProduct.Collect();

                currentProduct = null;

                if (interactionText != null)
                {
                    interactionText.text = "";
                }
            }
        }
        else
        {
            if (interactionText != null)
            {
                interactionText.text = "";
            }
        }
    }

    void FindClosestProduct()
    {
        Collider[] nearbyObjects =
            Physics.OverlapSphere(transform.position, interactionRange);

        Product closestProduct = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider objectFound in nearbyObjects)
        {
            Product product =
                objectFound.GetComponentInParent<Product>();

            if (product != null)
            {
                float distance = Vector3.Distance(
                    transform.position,
                    product.transform.position
                );

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestProduct = product;
                }
            }
        }

        currentProduct = closestProduct;
    }
}