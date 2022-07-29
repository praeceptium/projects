using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    public bool score;
    public bool playerLastHit = false;
    public bool aiLastHit = false;
    public bool playerServiceShot=true;
    public bool aiServiceShot=false;
    public bool playersFirstShot = true;
    public bool aisFirstShot = false;

    public long playerBounce=0;
    public long aiBounce=0;
    public long playerScore = 0;
    public long aiScore = 0;
    public long serviceCounter = 0;

    public TextMeshProUGUI Pscore = new TextMeshProUGUI();
    public TextMeshProUGUI Ascore = new TextMeshProUGUI();
    public BallTeleport ballTP;

    public AudioSource scoreSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator SleepCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(0.25f);
        ballTP.ballTeleport();
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    public void fileAddScore()
    {
        if (playerLastHit == true)
        {
            aiScore += 1;
            Ascore.SetText(aiScore.ToString());
            StartCoroutine(SleepCoroutine());
            playerLastHit = false;
            aiLastHit = false;
        }
        else
        {
            playerScore += 1;
            Pscore.SetText(playerScore.ToString());
            StartCoroutine(SleepCoroutine());
            playerLastHit = false;
            aiLastHit = false;
            scoreSound.Play();
        }
    }

    public void SetScore()
    {
        if (playerScore > aiScore)
        {
            PlayerPrefs.SetFloat("score", (playerScore - aiScore));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (serviceCounter == 2)
        {
            if (playerServiceShot == true)
            {
                playerServiceShot = false;
                aiServiceShot = true;
                serviceCounter = 0;
            }
            else
            {
                playerServiceShot = true;
                aiServiceShot = false;
                serviceCounter = 0;
            }
        }
        if(playerLastHit == true && playerBounce >0 && playersFirstShot==false)
        {
            aiScore += 1;
            Ascore.SetText(aiScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            Debug.Log("1");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
        }
        if(playerLastHit==true && playerBounce==1 && playersFirstShot == true)
        {
            playersFirstShot = false;
            playerBounce = 0;
        }
        
        if (playerLastHit == true && aiBounce > 1)
        {
            playerScore += 1;
            Pscore.SetText(playerScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            Debug.Log("2");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
            scoreSound.Play();
        }
        if (playerLastHit == true && score==true && aiBounce==1)
        {
            playerScore += 1;
            Pscore.SetText(playerScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            score = false;
            Debug.Log("39");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
            scoreSound.Play();
        }
        if (playerLastHit == true && playerBounce == 0 && playersFirstShot == true && aiBounce > 0)
        {
            aiScore += 1;
            Ascore.SetText(aiScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            score = false;
            Debug.Log("70");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
        }
        else if(playerLastHit == true && score == true && aiBounce < 1)
        {
            aiScore += 1;
            Ascore.SetText(aiScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            score = false;
            Debug.Log("72");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
        }
        if(playerLastHit==true && playerBounce==0 && aiBounce == 0 && score == true)
        {
            aiScore += 1;
            Ascore.SetText(aiScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            score = false;
            Debug.Log("74");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
        }
        //ai
        if (aiLastHit == true && aiBounce > 0 && aisFirstShot==false)
        {
            playerScore += 1;
            Pscore.SetText(playerScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            Debug.Log("4");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
            scoreSound.Play();
        }
        if(aiLastHit==true && aiBounce==1 && aisFirstShot == true)
        {
            aisFirstShot = false;
            aiBounce = 0;
        }
        if (aiLastHit == true && playerBounce > 1)
        {
            aiScore += 1;
            Ascore.SetText(aiScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            Debug.Log("5");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
        }
        if (aiLastHit == true && score==true && playerBounce==1)
        {
            aiScore += 1;
            Ascore.SetText(aiScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            score = false;
            Debug.Log("6");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
        }
        else if(aiLastHit == true && score == true && playerBounce < 1){
            playerScore += 1;
            Pscore.SetText(playerScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            score = false;
            Debug.Log("3");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
            scoreSound.Play();
        }
        if(aiLastHit==true && aiBounce==0 && playerBounce == 0 && score==true)
        {
            playerScore += 1;
            Pscore.SetText(playerScore.ToString());
            aiBounce = 0;
            playerBounce = 0;
            StartCoroutine(SleepCoroutine());
            score = false;
            Debug.Log("30");
            serviceCounter += 1;
            playerLastHit = false;
            aiLastHit = false;
            scoreSound.Play();
        }
    }
}
