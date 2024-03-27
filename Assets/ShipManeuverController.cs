using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManeuverController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float maxVelocity = 3;
    public float rotationSpeed = 0.1f;
    public float maxAngularVelocity = 3;

    #region Monobehaviour API
    // Start is called before the first frame update
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal2");

        ThrustForward(yAxis);
        Rotate(transform, xAxis * -rotationSpeed);

        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -maxAngularVelocity, maxAngularVelocity);

    }
    #endregion

    #region Maneuvering API
    private void ClampVelocity(){
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        rb.AddForce(force);
    }

    private void Rotate(Transform t, float amount)
    {
        t.Rotate(0,0,amount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.angularVelocity = 0;
    }

    #endregion
}
