using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary bound;

    public GameObject bullet;
    public Transform bulletSp;

    public float fireRate;
    private float timeRate;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > timeRate)
        {
            timeRate = Time.time + fireRate;
            Instantiate(bullet, bulletSp.position, bulletSp.rotation);
        }
    }
    private void FixedUpdate()
    {
        var hoz = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(hoz, 0, ver) * speed;

        transform.position = new Vector3(
                                         Mathf.Clamp(transform.position.x, bound.xMin, bound.xMax)
                                         , 0,
                                         Mathf.Clamp(transform.position.z, bound.zMin, bound.zMax)
            );
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, GetComponent<Rigidbody>().velocity.x * -tilt));


    }
}
