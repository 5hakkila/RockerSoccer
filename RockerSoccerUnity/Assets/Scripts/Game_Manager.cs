using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game_Manager : MonoBehaviour {

    // Use this for initialization
    public enum GameState
    {
        STARTGAME,
        BEGIN,
        END,
        SCORE,
        GOALKICK,
    };

    GameState gameState;


    public bool enableBall;
    private float currentTime;
    private float roundTime;
    private float startTime = 60.0f;

    public Text UiTime;
    public Text UiScoreTeam1;
    public Text UiScoreTeam2;
    public Text GameEnded_text;

    public GameObject leftGoal;
    public GameObject rightGoal;

    public Transform ballLocation;
    public Transform ball;

    public bool releaseBall = false;
    //  public GameObject ballObject;
    //  public GameObject PlayerObject;

    public int score_Team1 = 0;
    public int score_Team2 = 0;

    private bool startClock = false;

    void Start() {

        gameState = GameState.STARTGAME;
        EnableBall();
        StartCoroutine(StartDelay());
       
        //  StartCoroutine(ScoreDelay());
        //  Instantiate(ballObject, ballLocation.position, transform.rotation);
        //  Instantiate(PlayerObject, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }

    // Update is called once per frame
    void Update() {

        if (releaseBall == false)
        {
            ball.transform.position = ballLocation.transform.position;
        }


        if (startClock == true) {
            currentTime = Time.time;
            //  Debug.Log(roundTime);

            if (gameState != GameState.END) {
                roundTime = startTime - currentTime;
            }

           

            if (roundTime <= 0.0f)
            {
                gameState = GameState.END;
                StartCoroutine(EndGame());
                roundTime = 0.0f;

            }

        }
        UiTime.text = roundTime.ToString("0");
        UiScoreTeam1.text = score_Team1.ToString();
        UiScoreTeam2.text = score_Team2.ToString();


    }

   
   public IEnumerator ScoreDelay()
    {
        GameObject.Find("Ball").SendMessage("DisableBall");
        yield return new WaitForSeconds(5.0f);
        ball.transform.position = ballLocation.transform.position;
        GameObject.Find("Ball").SendMessage("EnableBall");
        StartCoroutine(StartDelay());
       

    }
    public IEnumerator StartDelay()
    {
        
        releaseBall = false;
        yield return new WaitForSeconds(1.0f);
        releaseBall = true;
        startClock = true;

    }




    void EnableBall()
    {
        GameObject.Find("Player_1").SendMessage("EnableBall");
        GameObject.Find("Player_2").SendMessage("EnableBall");
        GameObject.Find("Player_3").SendMessage("EnableBall");
        GameObject.Find("Player_4").SendMessage("EnableBall");
        GameObject.Find("Player_5").SendMessage("EnableBall");

        GameObject.Find("Ai_1").SendMessage("EnableBall");
        GameObject.Find("Ai_2").SendMessage("EnableBall");
        GameObject.Find("Ai_3").SendMessage("EnableBall");
        GameObject.Find("Ai_4").SendMessage("EnableBall");
        GameObject.Find("Ai_5").SendMessage("EnableBall");

    }

    IEnumerator EndGame()
    {
        GameObject.Find("Ball").SendMessage("DisableBall");
        releaseBall = false;
        GameEnded_text.text = ("Game Over");





        yield return new WaitForSeconds(10.0f);
        Debug.Log("Game ended!!!");
       
    }


}
