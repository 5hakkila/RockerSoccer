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
    public float currentTime;
    public float roundTime;
    public float startTime = 30.0f;

    public Text UiTime;
    public Text UiScoreTeam1;
    public Text UiScoreTeam2;

    public GameObject leftGoal;
    public GameObject rightGoal;

    public Transform ballLocation;
    public Transform ball;

  //  public GameObject ballObject;
  //  public GameObject PlayerObject;

    public int score_Team1 = 0;
    public int score_Team2 = 0;

	void Start () {

        gameState = GameState.STARTGAME;
        ball.transform.position = ballLocation.transform.position;
      //  Instantiate(ballObject, ballLocation.position, transform.rotation);
      //  Instantiate(PlayerObject, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {

        currentTime = Time.time;
      //  Debug.Log(roundTime);

        if (gameState !=GameState.END) {
            roundTime = startTime - currentTime;
        }

        UiTime.text = roundTime.ToString("0");
        UiScoreTeam1.text = score_Team1.ToString();
        UiScoreTeam2.text = score_Team2.ToString();

        if (roundTime <= 0.0f)
        {
            gameState = GameState.END;
            roundTime = 0.0f;
           
        }


        


    }
}
