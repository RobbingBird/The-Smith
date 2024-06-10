using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 2f; // Speed of movement
    public float moveTime = 2f; // Duration of moving in one direction
    public float stopTime = 1f; // Duration of stopping

    private float timer;
    private Vector2 moveDirection;
    private SpriteRenderer spriteRenderer;
    private enum State { Moving, Stopping }
    private State currentState;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChooseNewDirection();
        currentState = State.Moving;

        moveTime = Random.Range(0f, 2f);
        stopTime = Random.Range(0f, 8f);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        switch (currentState)
        {
            case State.Moving:
                if (timer <= 0)
                {
                    currentState = State.Stopping;
                    timer = stopTime;
                }
                else
                {
                    transform.Translate(moveDirection * speed * Time.deltaTime);
                    UpdateSpriteDirection();
                }
                break;

            case State.Stopping:
                if (timer <= 0)
                {
                    ChooseNewDirection();
                    currentState = State.Moving;
                }
                break;
        }
    }

    void ChooseNewDirection()
    {
        float angle = Random.Range(0f, 360f); // Choose a random angle in degrees
        float radians = angle * Mathf.Deg2Rad; // Convert angle to radians
        moveDirection = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)); // Calculate the direction vector
        timer = moveTime;
    }

    void UpdateSpriteDirection()
    {
        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = true; // Flip the sprite to face left
        }
        else if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = false; // Flip the sprite to face right
        }
    }
}
