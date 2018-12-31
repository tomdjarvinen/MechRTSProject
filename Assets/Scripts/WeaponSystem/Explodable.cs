using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Explodable : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameController instance;
    public GameObject explosionParticle;

        public void Explode(GameObject gameObject, float radius = 500F,float force = 1000F,float maxDamage = 100F)
    {
        //input validation
        radius = Mathf.Max(Single.Epsilon,radius);
        Vector3 explosionPos = gameObject.GetComponent<Transform>().position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            float dist = Vector3.Distance(explosionPos,hit.bounds.center);
            float damage = (-dist/radius+1)*maxDamage;

            if (rb != null)
                rb.AddExplosionForce(-force, explosionPos, radius, 3.0F);
        }
        Destroy(gameObject);
        Instantiate(explosionParticle,explosionPos,Quaternion.identity).GetComponent<ExplosionController>().Run();
    }
}
