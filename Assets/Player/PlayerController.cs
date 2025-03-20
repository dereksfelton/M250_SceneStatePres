using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PlayerStateData playerStateData;
    public float moveSpeed = 8.0f;

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // call scriptable object to load state when I'm enabled
    void OnEnable()
    {
        // PlayerStateEvents.LoadState(transform, rb);
        playerStateData.LoadState(transform, rb);
    }

    // call scriptable object to store state when I'm disabled
    void OnDisable()
    {
        // PlayerStateEvents.SaveState(transform, GetComponent<Rigidbody>());
        playerStateData.SaveState(transform, GetComponent<Rigidbody>());
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 movementValue = context.ReadValue<Vector2>();
        movementX = movementValue.x;
        movementY = movementValue.y;
    }

    public void Pause(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("MainMenu");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            // do pickup stuff related to the player, e.g., increment score
            int pickupPoints = other.gameObject.GetComponent<PickupController>().PickupValue;
            playerStateData.PlayerScore += pickupPoints;
        }
    }

    public void SaveState(Transform playerTransform, Rigidbody playerRigidbody)
    {
        playerStateData.Position = playerTransform.transform.position;
        playerStateData.Rotation = playerTransform.transform.rotation;
        playerStateData.LinearVelocity = playerRigidbody.linearVelocity;
    }

    public void LoadState(Transform playerTransform, Rigidbody playerRigidbody)
    {
        playerTransform.position = playerStateData.Position;
        playerTransform.rotation = playerStateData.Rotation;
        playerRigidbody.linearVelocity = playerStateData.LinearVelocity;
    }
}
