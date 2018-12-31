using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameController : MonoBehaviour
{

    public static GameController instance;
    public GameObject explosionParticle;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if(instance != this)
            //...destroy this one because it is a duplicate.
            Destroy (gameObject);    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode(GameObject gameObject, float radius = 500F,float force = 10000F,float maxDamage = 10F)
    {
        //input validation
        radius = Mathf.Max(Single.Epsilon,radius);
        Vector3 explosionPos = gameObject.GetComponent<Transform>().position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            IMortal[] damaged = hit.GetComponents<IMortal>();
            if (damaged.Length > 0)
            {
                float dist = Vector3.Distance(explosionPos,hit.bounds.center);
                float damage = (-dist/radius+1)*maxDamage;
                damaged[0].ApplyDamage(damage,0);
            }
            if (rb != null)
                rb.AddExplosionForce(force, explosionPos, radius, 3.0F);
        }
        Destroy(gameObject);
        Instantiate(explosionParticle,explosionPos,Quaternion.identity).GetComponent<ExplosionController>().Run();
    }
    
}
