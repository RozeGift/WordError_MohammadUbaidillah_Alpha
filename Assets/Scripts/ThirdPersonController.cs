using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontalinput, 0f, verticalinput) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}
