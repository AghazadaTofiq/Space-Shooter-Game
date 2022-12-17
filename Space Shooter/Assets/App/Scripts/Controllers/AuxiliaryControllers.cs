using UnityEngine;

public class AuxiliaryControllers : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, -speed);
    }
}
