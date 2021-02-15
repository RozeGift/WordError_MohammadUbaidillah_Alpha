using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float movementspeed;
    //public GameObject camera;

    public float rotateSpeed = 5f;
    public GameObject playerobj;
    public GameObject bulletobj;
    public GameObject bulletSpawnPoint;
    public Animator animcontroller;
    public float waitTime;
    bool isdead = false;

    //Methods
     void Update()
    {
        /*
        //Plane facing mouse
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if(playerplane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            //rotate by 7 units/sec
            playerobj.transform.rotation = Quaternion.Slerp(playerobj.transform.rotation, targetRotation, 20f * Time.deltaTime);
        }
        */

        //Player Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementspeed * Time.deltaTime);
            animcontroller.SetBool("isRun", true);
        }
      
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));
            animcontroller.SetBool("isLeft", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementspeed * Time.deltaTime);
            animcontroller.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
            animcontroller.SetBool("isRight", true);
        }
        else
        {
            animcontroller.SetBool("isRun", false);
            animcontroller.SetBool("isLeft", false);
            animcontroller.SetBool("isRight", false);
        }
        if(HealthPlayer.health == 0)
        {
            isdead = true;
        }
        if(isdead==true)
        {
            animcontroller.SetTrigger("IsDead");
        }


        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(bulletobj.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
    }


}
