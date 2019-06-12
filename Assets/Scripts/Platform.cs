using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    public string whichPlatform;
    public Text weightText;
    //public Camera cam;

    float weight;
    // Start is called before the first frame update
    void Start()
    {
        weight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        weightText.text = whichPlatform + weight + "kg";
    }

    public void AddWeight(float mass)
    {
        weight = weight + mass;
    }

    public void SubtractWeight(float mass)
    {
        weight = weight - mass;
    }

    public float GetWeight()
    {
        return weight;
    }

    public void ResetWeight()
    {
        weight = 0;
    }

}
