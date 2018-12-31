using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocket : MonoBehaviour
{
    public GameObject Missle;
    public string primaryFire = "space";
    public float force = 50000;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        //Check for keystroke, call ShootRocket()
        if (Input.GetKeyDown(primaryFire))
            {
                Shoot();
            }
    }
    public void Shoot()
    {
        Vector3 rotationVect = gameObject.GetComponent<Transform>().eulerAngles;
        rotationVect.z = 90;
        var rotation = Quaternion.identity;
        rotation.eulerAngles = rotationVect;
        GameObject doge = Instantiate(Missle,pos.position,rotation);
        doge.GetComponent<MissleController>().IgnoreParent(gameObject.GetComponent<Collider>());
        doge.GetComponent<Rigidbody>().AddForce(force*gameObject.GetComponent<Transform>().forward);
    }
}