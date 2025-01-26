using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private Rigidbody sphereRigidbody;

    [SerializeField] private float ballSpeed;

    [SerializeField] private float jumpHeight;

    private bool isGrounded = false; // To prevent double jumps

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        } 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MoveBall(Vector3 input)
    {
        Vector3 force = new Vector3(input.x, 0, input.z) * ballSpeed;
        sphereRigidbody.AddForce(force, ForceMode.Force);

        if(input.y > 0 && isGrounded)
        {
            Vector3 jumpForceVector = Vector3.up * jumpHeight;

            sphereRigidbody.AddForce(jumpForceVector, ForceMode.Impulse);
            isGrounded=false;
        }
    }
}
