using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    public CharacterController player;
    private float launch_jump = 3.0f;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;


    private void OnTriggerEnter(Collider other)
    {
        playerVelocity.y += Mathf.Sqrt(launch_jump * -3.0f * gravityValue);
        player.Move(playerVelocity * Time.deltaTime);
    }
}
