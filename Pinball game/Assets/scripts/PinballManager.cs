using UnityEngine;
using TMPro;

public class PinballManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText; //refence to text component that shows the score
    //in order to access text mesh pro components, you must include "using TMPro" up at the top

    int score = 100; //var to track score

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the score text to the score
        //b/c score is an int, it must be translated to a string
        //you can add strings together
        scoreText.text = "Score: " + score.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    //since we want to centralize macro game systems, i would probaly want to actually change
    //the score in the game manager
    public void AddScore()
    {
        //add to score
        //do score effects maybe
        score++;
    }
}
