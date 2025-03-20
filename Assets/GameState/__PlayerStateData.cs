using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateData", menuName = "Game State/PlayerStateData")]
public class __PlayerStateData : ScriptableObject, IPlayerStateListener
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 linearVelocity;
    public int playerScore;

    private void OnEnable()
    {
        // Subscribe to player state and scene change events
        PlayerStateEvents.OnSaveState += SaveState;
        PlayerStateEvents.OnLoadState += LoadState;
    }

    private void OnDisable()
    {
        // Unsubscribe from events
        PlayerStateEvents.OnSaveState -= SaveState;
        PlayerStateEvents.OnLoadState -= LoadState;
    }

    public void SaveState(Transform playerTransform, Rigidbody playerRigidbody)
    {
        position = playerTransform.position;
        rotation = playerTransform.rotation;
        linearVelocity = playerRigidbody.linearVelocity;
    }

    public void LoadState(Transform playerTransform, Rigidbody playerRigidbody)
    {
        playerTransform.position = position;
        playerTransform.rotation = rotation;
        playerRigidbody.linearVelocity = linearVelocity;
    }
}