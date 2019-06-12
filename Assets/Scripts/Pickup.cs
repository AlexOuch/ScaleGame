using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    int buttonPressed = 0;

    public Button button;
    public Text buttonText;
    public Text objectWeightText;

    public Transform cam;
    public LayerMask objectLayer;
    RaycastHit hit;

    GameObject whatIRemember;
    GameObject whatImHolding;
    bool holding;

    // Start is called before the first frame update
    void Start()
    {
        objectWeightText.text = "";
        buttonText.text = "Hold";
        button.gameObject.GetComponent<Image>().color = new Color(30f / 255f, 1, 0, 1); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 999f, objectLayer))
        {
            if (hit.collider.gameObject != whatIRemember)
            {
                objectWeightText.text = "" + hit.collider.gameObject.GetComponent<Object>().GetMass() + "kg";
                hit.collider.gameObject.GetComponent<Outline>().enabled = true;
                whatIRemember = hit.collider.gameObject;
            }
        }

        else
        {

            if (whatIRemember != null)
            {
                objectWeightText.text = "";
                whatIRemember.GetComponent<Outline>().enabled = false;
                whatIRemember = null;
            }
        }

        if (holding)
            whatImHolding.transform.position = Vector3.Lerp(whatImHolding.transform.position, cam.position + cam.forward * 0.5f, 0.1f);
    }

    public void PressButton()
    {
        buttonPressed++;
        if (!holding)
        {
            buttonText.text = "Drop";
            button.gameObject.GetComponent<Image>().color = new Color(1, 30f / 255f, 0, 1);
            //whatIRemember.GetComponent<BoxCollider>().enabled = false;
            whatIRemember.GetComponent<Rigidbody>().isKinematic = true;
            whatImHolding = whatIRemember;
            holding = true;
        }

        else
        {
            buttonText.text = "Hold";
            button.gameObject.GetComponent<Image>().color = new Color(30f / 255f, 1, 0, 1);
            //whatImHolding.GetComponent<BoxCollider>().enabled = true;
            whatImHolding.transform.position = cam.localPosition + cam.forward * 0.5f;
            whatImHolding.gameObject.SetActive(true);
            whatImHolding.GetComponent<Rigidbody>().isKinematic = false;
            whatImHolding.GetComponent<Rigidbody>().AddForce(cam.forward * 10f);
            whatImHolding = null;
            holding = false;
        }
    }

    public int GetButtonPressed()
    {
        int number = buttonPressed;
        buttonPressed = 0;
        return number;
    }

    public bool Holding()
    {
        return holding;
    }
}
