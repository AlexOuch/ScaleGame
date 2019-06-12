using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    Rigidbody rigi;
    float mass;
    LayerMask triggerLayer = 11;
    bool onPlatform;
    // Start is called before the first frame update
    void Start()
    {
        rigi = transform.GetComponent<Rigidbody>();
        mass = rigi.mass;
        onPlatform = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == triggerLayer)
        {
            other.transform.parent.gameObject.GetComponent<Platform>().AddWeight(mass);
            onPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == triggerLayer)
        {
            other.transform.parent.gameObject.GetComponent<Platform>().SubtractWeight(mass);
            onPlatform = false;
        }
    }

    public bool GetBool()
    {
        return onPlatform;
    }

    public float GetMass()
    {
        return mass;
    }
}
