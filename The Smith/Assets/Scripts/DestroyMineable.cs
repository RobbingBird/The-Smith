using UnityEngine;

public class DestroyMineable : MonoBehaviour
{
    public float detectionRadius = 1.5f; // Radius within which to check for the Bush
    public LayerMask bushLayer; // Layer mask to specify the Bush layer
    public Animator swing; // Reference to the Animator component
    public float cooldownTime = 2f; // Cooldown time in seconds

    private float cooldownTimer = 0f; // Timer to track the cooldown

    public int currentMine = 0;
    public int maxMine = 3;

    public delegate void gainInventory(string item);
    public static event gainInventory OnGainInventory;

    void Update()
    {
        // Reduce the cooldown timer
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0f)
        {
            CheckForMineable();
            cooldownTimer = cooldownTime; // Reset the cooldown timer
        }
    }

    void CheckForMineable()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, bushLayer);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Bush") || hitCollider.CompareTag("Cow") || hitCollider.CompareTag("Rock"))
            {
                swing.SetTrigger("swing");
                currentMine += 1;
                Debug.Log(currentMine);

                if (currentMine >= maxMine){
                    currentMine = 0;
                    OnGainInventory?.Invoke(hitCollider.tag);
                    Destroy(hitCollider.gameObject);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to visualize the detection radius in the Editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
