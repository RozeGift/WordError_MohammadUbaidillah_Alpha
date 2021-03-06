﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject PlayerGO;

    public Transform playerTransform;

    public bool rotateAroundPlayer = true;
    public bool LookatPlayer = false;

    public float rotationspeed = 5f;

    Vector3 posoffset = new Vector3(0f, 1.5f, -5f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameramouse();
    }
    //camera follow mouse
    void cameramouse()
    {
        //focus on player
        transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + posoffset, 0.1f);

        //rotate around the player
        if (rotateAroundPlayer)
        {
            Quaternion CamTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationspeed, Vector3.up);

            posoffset = CamTurnAngle * posoffset;
        }

        if (LookatPlayer || rotateAroundPlayer)
        {
            transform.LookAt(playerTransform);
        }

    }


}
