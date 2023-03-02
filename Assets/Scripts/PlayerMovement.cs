using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;


public class PlayerMovement : NetworkTransform
{
    // public float speed = 5f;

    // private Rigidbody2D rb;
    // public static Dictionary<ulong, PlayerMovement> Players = new Dictionary<ulong, PlayerMovement>();

    // protected override bool OnIsServerAuthoritative()
    // {
    //     return false;
    // }
    // public override void OnNetworkSpawn()
    // {
    //     if (IsOwner)
    //     {
    //         var temp = transform.position;
    //         temp.y = 0.5f;
    //         transform.position = temp;
    //         rb = GetComponent<Rigidbody2D>();

    //         Players[OwnerClientId] = this;
    //         base.OnNetworkSpawn();
    //     }
    // }

    // public override void OnNetworkDespawn()
    // {
    //     if (Players.ContainsKey(NetworkObjectId))
    //     {
    //         Players.Remove(NetworkObjectId);
    //     }
    //     base.OnNetworkDespawn();
    // }

    // private void FixedUpdate()
    // {
    //     if (!IsSpawned || !IsOwner)
    //     {
    //         return;
    //     }
    //     else
    //     {
    //         transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    //     }
    // }
}
