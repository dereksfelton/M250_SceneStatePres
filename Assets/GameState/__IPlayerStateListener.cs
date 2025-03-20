using UnityEngine;

public interface __IPlayerStateListener
{
    void SaveState(Transform playerTransform, Rigidbody playerRigidbody);
    void LoadState(Transform playerTransform, Rigidbody playerRigidbody);
}