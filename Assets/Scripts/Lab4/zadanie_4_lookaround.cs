using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_4_lookaround : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 200f;

    private float mouseXMove = 0.0f;
    private float mouseYMove = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseXMove += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseYMove -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        float mouseXMove2 = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouseXMove2);

        mouseYMove = Mathf.Clamp(mouseYMove, -90f, 90f);
        transform.eulerAngles = new Vector3(mouseYMove,  mouseXMove, 0f);

    }
}
