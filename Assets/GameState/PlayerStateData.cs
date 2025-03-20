using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStateData", menuName = "Game State/PlayerStateData")]
public class PlayerStateData : ScriptableObject
{
    // events regarding player state that other systems might care about
    public static event Action HandleScoreChange;


    // values we only need to update and restore when leaving the scene
    [SerializeField] private Vector3 position;
    [SerializeField] private Quaternion rotation;
    [SerializeField] private Vector3 linearVelocity;

    public Vector3 Position
    {
        get => position;
        set { position = value; }
    }

    public Quaternion Rotation
    {
        get => rotation;
        set { rotation = value; }
    }

    public Vector3 LinearVelocity
    {
        get => linearVelocity;
        set { linearVelocity = value; }
    }

    // values which other systems might care about when they change during play
    [SerializeField] private int playerScore;
    public int PlayerScore
    {
        get => playerScore;
        set
        {
            playerScore = value;
            HandleScoreChange?.Invoke();
        }
    }   

    // handle state saving and restoring
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