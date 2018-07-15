using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Game_Manager : MonoBehaviour {
   

    // Use this for initialization
    public enum GameState
    {
        STARTGAME,
        BEGIN,
        END,
        SCORE,
        GOALKICK,
        SLOWMO,
        PLAY
    };
    private enum color1
    {
        RED,
        WHITE
    };

    color1 timeColor;

    GameState gameState;

    public bool draw = false;
    public bool aiWin = false;
    public bool playerWin = false;
    private bool isQuittingAsked;
    private bool isOptionsMenuOn = false; //Onko options menu klikattu päälle
    private bool ReturnMainMenuClicked = false; //Pelin päätyttyä onko klikattu palaamainmenuun
    private bool startClicked = false; //onko painettu START
    private float xp = 0; //saavutettu xp
    private int roundedxp; //saavutettu xp pyöristettynä, mikä tallennetaan
    private float startClickedTime; //aikaleima kun start on painettu

    public bool enableBall;
    private float currentTime;
    private float roundTime;
    private float resetTime;
    public float startTime = 20.0f;

    public Text UiTime;
    public Text UiScoreTeam1;
    public Text UiScoreTeam2;
    public Text GameEnded_text;

    GameObject StartButton;
    public GameObject quittingCanvas;
    public GameObject menuButton;
    public GameObject leftGoal;
    public GameObject rightGoal;
    public GameObject gOCanvas; //GameOver canvas
    public GameObject uiCanvas; //Ui buttons
    public GameObject optionsMenu;
    public GameObject resultText; //Shows the match result in the end
    public GameObject xpResultText; //Shows gained xp in the end

    //public GameObject canvas;
   

    public Transform ballLocation;
    public Transform ball;
    public Transform left_End;
    public Transform right_End;

    public bool releaseBall = false;
    public bool goalkick = false;
    //  public GameObject ballObject;
    //  public GameObject PlayerObject;

    public int score_Team1 = 0;
    public int score_Team2 = 0;

    private bool startClock = false;

    public bool SlowMo = false;


    private void Awake()
    {
        quittingCanvas = GameObject.Find("Quitting");
        menuButton = GameObject.Find("MenuButton");
        resultText = GameObject.Find("ResultText");
        xpResultText = GameObject.Find("XpGained");
        uiCanvas = GameObject.Find("UiCanvas");
        gOCanvas = GameObject.Find("GameOverCanvas");
        optionsMenu = GameObject.Find("OptionsMenu");
        optionsMenu.SetActive(false);
        quittingCanvas.SetActive(false);
        gOCanvas.SetActive(false);
        StartButton = GameObject.Find("StartButton");
        GameObject.Find("Ball").SendMessage("EnableBall"); ///FIX
    }

    void Start() {



        StartCoroutine(WaitForStartClicked());
        // Application.targetFrameRate = 60;

        //  gameState = GameState.STARTGAME;
        // EnableBall();
        if (PlayerPrefs.HasKey("PlayTime"))
        {
            startTime = PlayerPrefs.GetFloat("PlayTime");
           
        }
        else
        {
            startTime = 5.0f;
        }
        
        // StartCoroutine(StartDelay());
        resetTime = 0.0f;

        //  StartCoroutine(ScoreDelay());
        //  Instantiate(ballObject, ballLocation.position, transform.rotation);
        //  Instantiate(PlayerObject, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
    }


    
    //Odotetaan, että pelaaja klikkaa START
    IEnumerator WaitForStartClicked()
    {
        yield return new WaitUntil(() => startClicked == true); 
        gameState = GameState.STARTGAME;
        EnableBall();
        StartCoroutine(StartDelay());
    }


    // Update is called once per frame
    void Update() {
      //  print(score_Team1);
       // print(score_Team2);

        //Jos options menu päällä
        if (isOptionsMenuOn == true || isQuittingAsked == true)
        {
            menuButton.SetActive(false);
            StartButton.SetActive(false);
            uiCanvas.SetActive(false);
        }
         else if(isOptionsMenuOn == false && startClicked == true)
        {
            menuButton.SetActive(true);
            uiCanvas.SetActive(true);
        }
         else if(isOptionsMenuOn == false && startClicked == false)
        {
            menuButton.SetActive(true);
            StartButton.SetActive(true);
            uiCanvas.SetActive(true);
        }
   





         if (releaseBall == false)
        {
             ball.transform.position = ballLocation.transform.position;
        }





        if (startClock == true)
        {
            currentTime = Time.time;
            //  Debug.Log(roundTime);

            if (gameState != GameState.END)
            {
                roundTime = startTime - currentTime + startClickedTime;
            }



            if (roundTime <= 0.0f)
            {
                gameState = GameState.END;
                StartCoroutine(EndGame());
                roundTime = 0.0f;

            }

        }

        

       


        if ((int)roundTime < 10)
        {
                UiTime.GetComponent<Text>().color = Color.red;
        }
     



        else 
        {
            UiTime.GetComponent<Text>().color = Color.white;
        }
            UiTime.text = roundTime.ToString("0");
            UiScoreTeam1.text = score_Team1.ToString();
            UiScoreTeam2.text = score_Team2.ToString();

        if (TouchControl.inputState == TouchControl.InputState.InputStart && SlowMo == true && gameState != GameState.END)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;

        }
        else
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;

        }
    }


    public IEnumerator ScoreDelay()
    {
        GameObject.Find("Ball").SendMessage("DisableBall"); 
        GameObject.Find("marker").GetComponent<SpriteRenderer>().enabled = false; //markkeri pois
        yield return new WaitForSeconds(5.0f);
        GameObject.Find("Ball").SendMessage("StopBall");
        ball.transform.position = ballLocation.transform.position;
        GameObject.Find("Ball").SendMessage("EnableBall");
        StartCoroutine(StartDelay());
        //GameObject.Find("marker").GetComponent<SpriteRenderer>().enabled = true;  //markkeri päälle


    }
    public IEnumerator GoalkickDelayLeft()
    {
        if (gameState != GameState.END)
        {
            GameObject.Find("Ball").SendMessage("DisableBall");
            yield return new WaitForSeconds(3.0f);
            GameObject.Find("Ball").SendMessage("StopBall");
            ball.transform.position = left_End.transform.position;
            GameObject.Find("Ball").SendMessage("EnableBall");
            goalkick = true;
            StartCoroutine(StartDelay());
        }

    }
    public IEnumerator GoalkickDelayRight()
    {
        if (gameState != GameState.END)
        {
            GameObject.Find("Ball").SendMessage("DisableBall");
            yield return new WaitForSeconds(3.0f);
            GameObject.Find("Ball").SendMessage("StopBall");
            ball.transform.position = right_End.transform.position;
            GameObject.Find("Ball").SendMessage("EnableBall");
            goalkick = true;
            releaseBall = false;
            yield return new WaitForSeconds(1.0f);
            releaseBall = true;
            startClock = true;
            goalkick = false;
        }

    }
    public IEnumerator GoalkickDelay()
    {
        if (gameState != GameState.END)
        {
            releaseBall = false;
            yield return new WaitForSeconds(1.0f);
            releaseBall = true;
            startClock = true;
            goalkick = false;
        }
    }

    public IEnumerator StartDelay()
    {

        releaseBall = false;
        yield return new WaitForSeconds(1.0f);
        releaseBall = true;
        startClock = true;
        GameObject.Find("marker").GetComponent<SpriteRenderer>().enabled = true;

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
        GameObject.Find("Ball").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("marker").GetComponent<SpriteRenderer>().enabled = false; //markkeri pois
        uiCanvas.SetActive(false); //Poistetaan uibuttonit
        GameObject.Find("Ball").SendMessage("DisableBall");
        
        releaseBall = false;
        GameEnded_text.text = ("Game Over");
        calculateXp(); //Lasketaan xp pelin päätyttyä
        yield return new WaitForSeconds(3.0f);
        if(playerWin == true)
        {
            resultText.GetComponent<Text>().text = "You win";
        }
        else if(aiWin == true)
        {
            resultText.GetComponent<Text>().text = "You lose";
        }
        else if(draw == true)
        {
            resultText.GetComponent<Text>().text = "draw";
        }
         
        // Debug.Log("Game ended!!!");
        gOCanvas.SetActive(true);
        // canvas.SetActive(false);
        yield return new WaitUntil(() => ReturnMainMenuClicked == true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //SceneManager.LoadScene("Main");

    }

    public void SlowMoActivate()
    {
        SlowMo = true;

    }
    public void SlowMoDeActivate()
    {
        SlowMo = false;

    }

    //Algoritmi xp:n laskemiseen ja tallentamiseen
    public void calculateXp() 
    {
        int scoreDifference = score_Team1 - score_Team2; //maaliero
        
        if (scoreDifference > 0) //pelaajavoittaa
        {
            playerWin = true;
            xp = (this.startTime * 1.5f) + (Mathf.Log10(scoreDifference)) * 100;
        }
        else if(scoreDifference < 0) //tietokonevoittaa
        {
            aiWin = true;
            scoreDifference = -1 * scoreDifference;
            xp = (this.startTime * 1.5f) - ((Mathf.Log10(scoreDifference)) * 20); 
           
        }
        else if (scoreDifference == 0) //tasapeli
        {
            draw = true;
            xp = this.startTime * 0.5f;
        }
        roundedxp = (int)Mathf.Round(xp);
        Debug.Log(roundedxp);
        if (roundedxp < 0) //tallennetaan 0xp
        {
            PlayerPrefs.SetInt("lastRoundXp", 0);
        }
        else if(roundedxp >= 0) //tallennetaan saatu xp
        {
            PlayerPrefs.SetInt("lastRoundXp", roundedxp);
        }
        xpResultText.GetComponent<Text>().text = "+" + roundedxp + "xp";



    }

    //Kutsutaan kun startbuttonia painetaan
    public void clickStart()
    {
        startClicked = true;
        startClickedTime = Time.time;
        StartButton.SetActive(false);
        
    }

    public void ReturnToMainMenu()
    {

        PlayerPrefs.SetInt("nextScene", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ResetGame()
    {
        startClock = false;
        resetTime = currentTime + 2.0f;
        gameState = GameState.STARTGAME;
        score_Team1 = 0;
        score_Team2 = 0;
        EnableBall();
        GameEnded_text.text = ("");
        StartCoroutine(StartDelay());
        GameObject.Find("Ball").SendMessage("EnableBall");

    }

    public void ClickReturnMainMenu()
    {
        ReturnMainMenuClicked = true;
    }

    public void OptionsMenuOn()
    {
        isOptionsMenuOn = true;
    }
    public void OptionsMenuOff()
    {
        isOptionsMenuOn = false;
    }

    public void askQuitting()
    {
        isQuittingAsked = true;

        optionsMenu.SetActive(false);
        quittingCanvas.SetActive(true);
        isOptionsMenuOn = false;
    }
    public void quitGame()
    {
        PlayerPrefs.SetInt("nextScene", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void returnOptionsMenu()
    {
        quittingCanvas.SetActive(false);
        optionsMenu.SetActive(true);
        isOptionsMenuOn = true;
        isQuittingAsked = false;
    }


}
