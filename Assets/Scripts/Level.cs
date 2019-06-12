using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Text objectsLeftText;

    public Transform pickup;
    public Transform[] objects;
    public Transform leftPlatform;
    public Transform rightPlatform;

    // Update is called once per frame
    void Update()
    {
        //buttonText.text = "L: " + leftPlatform.gameObject.GetComponent<Platform>().GetWeight() + " R: " + rightPlatform.gameObject.GetComponent<Platform>().GetWeight();
        objectsLeftText.text = "Objects Left: " + ObjectsLeft();
        LevelClear();
    }

    int ObjectsLeft()
    {
        int objectsLeft = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].gameObject.GetComponent<Object>().GetBool() == false)
            {
                objectsLeft++;
            }
        }
        return objectsLeft;
    }

    void LevelClear()
    {
        if (leftPlatform.gameObject.GetComponent<Platform>().GetWeight() == rightPlatform.gameObject.GetComponent<Platform>().GetWeight() && ObjectsLeft() == 0 && !pickup.gameObject.GetComponent<Pickup>().Holding())
            //if the left and right platform are equal
            //and if all objects have been placed
            //and if the user is not holding an object
        {
            LevelManager.instance.NextLevel();
        }
    }

    public int GetObjectsAmount()
    {
        return (objects.Length + 1);
    }

}
