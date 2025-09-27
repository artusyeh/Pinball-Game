using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PinballManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText; //refence to text component that shows the score
    //in order to access text mesh pro components, you must include "using TMPro" up at the top

    int score = 0; //var to track score

    [SerializeField]
    GameObject ballObj;

    Vector3 ballStartPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ballStartPos = ballObj.transform.position;

        score = PlayerPrefs.GetInt("Score");
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
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("MainGame");
            //set the ball's position to its original position
            //ballObj.transform.position = ballStartPos;
        }
    }
}
