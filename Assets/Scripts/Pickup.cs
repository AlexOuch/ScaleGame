using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform cam;
    public LayerMask objectLayer;
    RaycastHit hit;

    GameObject whatIRemember;
    GameObject whatImHolding;
    bool holding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 999f, objectLayer))
        {
            if (hit.collider.gameObject != whatIRemember)
            {
                hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                whatIRemember = hit.collider.gameObject;
            }
        }

        else
        {

            if (whatIRemember != null)
            {
                whatIRemember.GetComponent<Outline>().enabled = false;
                whatIRemember = null;
            }
        }

        if (holding)
            whatImHolding.transform.position = Vector3.Lerp(whatImHolding.transform.position, cam.position + cam.forward * 0.5f, 0.1f);
    }

    public void PressButton()
    {
        if (!holding)
        {
            whatIRemember.GetComponent<BoxCollider>().enabled = false;
            whatIRemember.GetComponent<Rigidbody>().isKinematic = true;
            whatImHolding = whatIRemember;
            holding = true;
        }

        else
        {
            whatImHolding.GetComponent<BoxCollider>().enabled = true;
            whatImHolding.transform.position = cam.localPosition + cam.forward * 0.5f;
            whatImHolding.gameObject.SetActive(true);
            whatImHolding.GetComponent<Rigidbody>().isKinematic = false;
            whatImHolding.GetComponent<Rigidbody>().AddForce(cam.forward * 10f);
            whatImHolding = null;
            holding = false;
        }
    }
}
