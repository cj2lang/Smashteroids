using UnityEngine;

public class ShipManeuverController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float thrustForce = 3.0f;
    public float rotationSpeed = 100.0f;
    public float maxAngularVelocity = 3.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float thrustInput = 0f;
        float rotateInput = 0f;

        // Determine if the player is Player1 or Player2 based on the object name
        if (gameObject.name == "Player")
        {
            // For Player1: Use the Vertical axis for up and down movement, and Horizontal for rotation
            thrustInput = Input.GetAxis("Vertical");
            rotateInput = Input.GetAxis("Horizontal");
        }
        else if (gameObject.name == "Player2")
        {
            // For Player2: Use Vertical2 for up and down movement, and Horizontal2 for rotation
            thrustInput = Input.GetAxis("Vertical2");
            rotateInput = Input.GetAxis("Horizontal2");
        }

        ThrustForward(thrustInput);
        Rotate(rotateInput);

        // Clamp the angular velocity to the max value
        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxAngularVelocity, maxAngularVelocity);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount * thrustForce;
        rb.AddForce(force);
    }

    private void Rotate(float amount)
    {
        // Assuming amount is already scaled by rotation speed and time in the input, 
        // if not, you might want to do: amount * rotationSpeed * Time.deltaTime
        transform.Rotate(0,0,amount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.angularVelocity = 0;
    }
}
