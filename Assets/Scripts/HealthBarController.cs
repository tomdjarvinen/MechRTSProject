using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public string healthBarName = "HealthIndicator";
    private Transform pos;
    private Vector3 maxSize;
    private float translate = 0;
    public void SetHealth(float percent)
    {
        Debug.Log(percent.ToString());
        if( 0 < percent  && percent < 1)
        {
            pos.localScale = new Vector3(maxSize[0],maxSize[1]*percent,maxSize[2]);
        }

    }
    // Start is called before the first frame update
    void Awake()
    {
        pos = gameObject.GetComponent<Transform>().Find(healthBarName).GetComponent<Transform>();
        maxSize = pos.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
