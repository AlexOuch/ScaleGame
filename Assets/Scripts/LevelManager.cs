using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    void Awake()
    {
        instance = this;
    }

    //scoring system
    float totalScore;
    float score;
    float buttonPressed;
    int objectsAmount;

    public Text levelText;
    int levelTextNumber;
    public Text scoreText;


    public Transform leftPlatform;
    public Transform rightPlatform;    

    public GameObject[] levels;
    int levelNumber;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        levelNumber = 0;
        /*for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }*/
        levels[levelNumber].SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + totalScore;
        levelTextNumber = levelNumber + 1;
        levelText.text = "Level: " + levelTextNumber;
    }

    public void NextLevel()
    {
        AddScore();
        StartCoroutine("LevelComplete");
        levels[levelNumber].SetActive(false);
        leftPlatform.gameObject.GetComponent<Platform>().ResetWeight();
        rightPlatform.gameObject.GetComponent<Platform>().ResetWeight();
        
    }

    void AddScore()
    {
        objectsAmount = levels[levelNumber].gameObject.GetComponent<Level>().GetObjectsAmount();
        buttonPressed = transform.gameObject.GetComponent<Pickup>().GetButtonPressed();
        score = 200 * (objectsAmount / buttonPressed);
        totalScore = totalScore + score;
    }

    IEnumerator LevelComplete()
    {
        anim.Play("LevelComplete", 0, 0);
        yield return new WaitForSeconds(5f);
        levelNumber++;
        levels[levelNumber].SetActive(true);
    }
}
