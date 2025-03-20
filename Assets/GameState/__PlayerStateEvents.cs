using System;
using UnityEngine;

public static class __PlayerStateEvents
{
    public static event Action<Transform, Rigidbody> OnSaveState;
    public static event Action<Transform, Rigidbody> OnLoadState;

    public static void SaveState(Transform playerTransform, Rigidbody playerRigidbody)
    {
        OnSaveState?.Invoke(playerTransform, playerRigidbody);
    }

    public static void LoadState(Transform playerTransform, Rigidbody playerRigidbody)
    {
        OnLoadState?.Invoke(playerTransform, playerRigidbody);
    }
}