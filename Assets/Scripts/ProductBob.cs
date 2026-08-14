using UnityEngine;

// Add this to the VISUAL child of a product (the model from the asset pack),
// NOT the parent that has the collider and Product.cs.
// It makes the item slowly spin and float up/down like a collectible.
public class ProductBob : MonoBehaviour
{
    public float spinSpeed = 45f;    // degrees per second
    public float bobHeight = 0.08f;  // how high it floats
    public float bobSpeed = 2f;

    private Vector3 startLocalPos;
    private float offset;

    void Start()
    {
        startLocalPos = transform.localPosition;
        offset = Random.Range(0f, 6.28f); // so items don't bob in sync
    }

    void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.World);

        float y = Mathf.Sin(Time.time * bobSpeed + offset) * bobHeight;
        transform.localPosition = startLocalPos + new Vector3(0f, y, 0f);
    }
}
