using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleController : MonoBehaviour
{
    public float maxLifespan = 5F;
    float timeAlive = 0F;
    public void IgnoreParent(Collider parent)
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(),parent);
    }
    // Start is called before the first frame update
    // Update is called once per frame

    void OnCollisionEnter(Collision coll) {
        Debug.Log("Hello World");
        GameController.instance.Explode(gameObject);
        
    }

    void FixedUpdate(){
        timeAlive += Time.deltaTime;
        if(timeAlive >= maxLifespan){
            GameController.instance.Explode(gameObject);
        }
    }
}
