using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float maxdist;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxdist += 1 * Time.deltaTime;

        if (maxdist >= 3)
            Destroy(this.gameObject);
    }
}
