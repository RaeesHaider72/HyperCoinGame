using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GMSinglePlayer : MonoBehaviour
{
    public static GMSinglePlayer instance;

    [Header("GameObjects")]
    public GameObject objectiveScreen;
    public GameObject singlePlayerScreen;
    public GameObject winnerPanel;
    public GameObject loserPanel;
    public WinPanel congratsPanel;
    public LosePanel losePanel;
    public GameObject pausePanel;

    public GameObject rowPrefab;
    public RectTransform rowParent;


    [Header("Buttons")]
    public Button objectiveBtn;
    public Button startBtn;
    public Button nextBtn;
    public Button winRestartBtn;
    public Button winHomeBtn;
    public Button failRestartBtn;
    public Button failHomeBtn;

    public Button pauseBtn;


    public Image progressBar;

    [Header("Texts")]
    public Text countDownTimer;
    public Text roundNumber;
    public Text congratsTxt;
    public Text winStatus;
    public GameObject topBar;


    public int maxLevels;

    public bool startTimer;
    public float maxRoundTime;
    public int timeToShow;


    public float winRangeStart = 0.3f; 
    public float winRangeEnd = 0.6f;
    public float fillSpeed;

    public GameObject groupObject1;
    public GameObject groupObject2;
    public GameObject groupObject3;
    public GameObject groupObject4;




    public GameObject gamePlayCharacter;

    public List<RowInfo> allRows = new List<RowInfo>();


    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
      //  UpdateUI();
    }
    private void Start()
    {

        roundNumber.text = "Round " + (RuntimeVariables.Instance.roundNumber + 1).ToString();

        TimeLevelWise();

        if (RuntimeVariables.Instance.isSceneRestarted)
        {
            objectiveScreen.SetActive(false);
            singlePlayerScreen.SetActive(true);
            startTimer = true;
            startBtn.transform.GetChild(1).gameObject.SetActive(true);
            RuntimeVariables.Instance.unlockLevels.Clear();
            RuntimeVariables.Instance.roundStatus.Clear();
            RuntimeVariables.Instance.totalCash = 100;
        }
        AddListenerToBtns();
        RowInformation();
      //  MakeRows();
        UpdateUI();
        ShowGroups();
    }

    private void Update()
    {
        if (startTimer)
        {
            maxRoundTime -= Time.deltaTime;
            timeToShow = (int)maxRoundTime;
            countDownTimer.text = timeToShow.ToString();

            float fillAmount = 1f - (maxRoundTime / 10); // Smoothly increase from 0 to 1
          //  fillAmount = fillAmount * fillSpeed; // Loop from 0 to 1
            allRows[RuntimeVariables.Instance.roundNumber].progressBar.fillAmount = fillAmount ;

            if (maxRoundTime <= 0)
            {
                maxRoundTime = 0;
                startTimer = false;
                allRows[RuntimeVariables.Instance.roundNumber].progressBar.fillAmount = 1f; // Ensure it's exactly 1 at the end
                DetermineOutcome(fillAmount);
            }
        }
    }



    public void TimeLevelWise()
    {
        if (RuntimeVariables.Instance.roundNumber > 0 && RuntimeVariables.Instance.roundNumber <= 10)
        {
            maxRoundTime = 10;
        }
        else if(RuntimeVariables.Instance.roundNumber > 10 && RuntimeVariables.Instance.roundNumber <= 20)
        {
            maxRoundTime = 5;
        }
    }
    private void AddListenerToBtns()
    {
        
        startBtn.onClick.AddListener(() => StartBtnReference());
        objectiveBtn.onClick.AddListener(() => ObjectiveBtnReference());
        nextBtn.onClick.AddListener(() => NextLevelReference());
        winRestartBtn.onClick.AddListener(() => RestartBtnReference());
        failRestartBtn.onClick.AddListener(() => RestartBtnReference());
        winHomeBtn.onClick.AddListener(() => HomeReference());
        failHomeBtn.onClick.AddListener(() => HomeReference());
        pauseBtn.onClick.AddListener(() => PauseBtnReference());
    }

    private void PauseBtnReference()
    {
        Time.timeScale = 0;
        SoundManager.instance.soundAudio.Play();
        gamePlayCharacter.SetActive(false);
        pausePanel.SetActive(true);
    }

    private void RestartBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        RuntimeVariables.Instance.roundNumber = 0;
        RuntimeVariables.Instance.unlockLevels.Clear();
        RuntimeVariables.Instance.roundStatus.Clear();
        RuntimeVariables.Instance.totalCash = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void HomeReference()
    {
        SoundManager.instance.soundAudio.Play();
        RuntimeVariables.Instance.roundNumber = 0;
        RuntimeVariables.Instance.unlockLevels.Clear();
        RuntimeVariables.Instance.roundStatus.Clear();
        RuntimeVariables.Instance.totalCash = 100;
        SceneManager.LoadScene("StartMenu");
    }

    private void NextLevelReference()
    {
        maxRoundTime = 10;
        startTimer = true;
        gamePlayCharacter.SetActive(true);
        RuntimeVariables.Instance.isSceneRestarted = false;
       // pauseBtn.interactable = false;
        startBtn.transform.GetChild(1).gameObject.SetActive(true);
        RowInformation();
        UpdateUI();
        ShowGroups();
    }


    public void RowInformation()
    {
        for (int i = 0; i < allRows.Count; i++)
        {
            if (i == RuntimeVariables.Instance.roundNumber)
            {
                allRows[RuntimeVariables.Instance.roundNumber].rowProgress.SetActive(true);
                allRows[RuntimeVariables.Instance.roundNumber].rowLocking.SetActive(false);
            }
            else
            {
                allRows[i].rowLocking.SetActive(true);
                allRows[i].levelLockDesc.text = $"Play Round {i} to Unlock this";
                allRows[i].rowProgress.SetActive(false);
            }
        }
    }


    public void MakeRows()
    {
        List<GameObject> instantiatedRows = new List<GameObject>();

        for (int i = 0; i < maxLevels; i++)
        {
            GameObject rowForLevel = Instantiate(rowPrefab, rowParent);
            rowForLevel.name = i.ToString();
            allRows.Add(rowForLevel.GetComponent<RowInfo>());
            instantiatedRows.Add(rowForLevel);

            if (i == RuntimeVariables.Instance.roundNumber)
            {
                allRows[RuntimeVariables.Instance.roundNumber].rowProgress.SetActive(true);
                allRows[RuntimeVariables.Instance.roundNumber].rowLocking.SetActive(false);
            }
            else
            {
                allRows[i].rowLocking.SetActive(true);
                allRows[i].levelLockDesc.text = $"Play Round {i} to Unlock this";
                allRows[i].rowProgress.SetActive(false);
            }
        }

        // Reverse the list and set sibling indices
        instantiatedRows.Reverse();
        for (int i = 0; i < instantiatedRows.Count; i++)
        {
            instantiatedRows[i].transform.SetSiblingIndex(i);
        }
    }

   // 2186
  //  2800


    public void ShowGroups()
    {
        if(RuntimeVariables.Instance.roundNumber > 0 && RuntimeVariables.Instance.roundNumber < 5)
        {
            groupObject1.SetActive(true);
            groupObject2.SetActive(false);
            groupObject3.SetActive(false);
            groupObject4.SetActive(false);
        }
        else if(RuntimeVariables.Instance.roundNumber >= 5 && RuntimeVariables.Instance.roundNumber < 10)
        {
            groupObject2.SetActive(true);
            groupObject1.SetActive(false);
            groupObject3.SetActive(false);
            groupObject4.SetActive(false);
        }
        else if (RuntimeVariables.Instance.roundNumber >= 10 && RuntimeVariables.Instance.roundNumber < 15)
        {
            groupObject3.SetActive(true);
            groupObject2.SetActive(false);
            groupObject1.SetActive(false);
            groupObject4.SetActive(false);
        }
        else if (RuntimeVariables.Instance.roundNumber >= 15 && RuntimeVariables.Instance.roundNumber < 20)
        {
            groupObject4.SetActive(true);
            groupObject1.SetActive(false);
            groupObject2.SetActive(false);
            groupObject3.SetActive(false);
        }
    }

    private void ObjectiveBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        objectiveScreen.SetActive(false);
        singlePlayerScreen.SetActive(true);
    }

    private void StartBtnReference()
    {
        SoundManager.instance.soundAudio.Play();
        startTimer = true;
      //  pauseBtn.interactable = false;
        startBtn.transform.GetChild(1).gameObject.SetActive(true);
    }
    private bool isWin;
    private void DetermineOutcome(float stoppingPoint)
    {
        int currentRound = RuntimeVariables.Instance.roundNumber;
        allRows[currentRound].isLevelPlayed = true;
        RuntimeVariables.Instance.unlockLevels.Add(currentRound);
        isWin = UnityEngine.Random.value < 0.5f;

        if (isWin)
        {
            allRows[currentRound].isWin = true;
            //    gamePlayCharacter.SetActive(false);
            if (RuntimeVariables.Instance.roundNumber > 0 && RuntimeVariables.Instance.roundNumber <= 4)
            {
                RuntimeVariables.Instance.totalCash *= 2;
            }
            else if (RuntimeVariables.Instance.roundNumber >= 5 && RuntimeVariables.Instance.roundNumber <= 10)
            {
                RuntimeVariables.Instance.totalCash *= 3;
            }
            else if (RuntimeVariables.Instance.roundNumber >= 10 && RuntimeVariables.Instance.roundNumber <= 15)
            {
                RuntimeVariables.Instance.totalCash *= 4;
            }
            else if (RuntimeVariables.Instance.roundNumber >= 16 && RuntimeVariables.Instance.roundNumber <= 18)
            {
                RuntimeVariables.Instance.totalCash *= 5;
            }
            else if(RuntimeVariables.Instance.roundNumber == 19)
            {
                RuntimeVariables.Instance.totalCash *= 20;
            }

            congratsPanel.totalCoins.text = RuntimeVariables.Instance.totalCash.ToString();
            congratsPanel.earnedCoins.text = RuntimeVariables.Instance.totalCash.ToString();
            congratsPanel.rewardedCoins.text = "-";
            ShowCongrats();
            allRows[currentRound].showStats = "Won";
            UpdateCash.ins.UpdateCashUI();
            RuntimeVariables.Instance.roundStatus.Add(  "Win");
            // Add your win logic here
            UpdateUI();
            topBar.SetActive(true);
            winStatus.text = $" You Won {RuntimeVariables.Instance.totalCash} cash.";


            RuntimeVariables.Instance.roundNumber++;

        }
        else
        {
            gamePlayCharacter.SetActive(false);
            allRows[currentRound].showStats = "Lose";
            ShowFailPanel();
            losePanel.totalCoins.text = RuntimeVariables.Instance.totalCash.ToString();
            losePanel.rewardedCoins.text = "0";
            losePanel.earnedCoins.text = "0";
            RuntimeVariables.Instance.roundStatus.Add("Lose");
            RuntimeVariables.Instance.roundNumber = 0;
            Debug.Log("You lose!");
            UpdateUI();
            // Add your lose logic here
        }

        if(RuntimeVariables.Instance.roundNumber >= allRows.Count)
        {
           
            if(RuntimeVariables.Instance.roundStatus.Last() == "Win")
            {
                congratsPanel.gameObject.SetActive(true);
            }
            else 
            {
                losePanel.gameObject.SetActive(true);

            }
        }
    }


    

    public void UpdateUI()
    {
      //  UpdateCash.ins.UpdateCashUI();

        if (RuntimeVariables.Instance.unlockLevels.Count > 0)
        {
            for (int i = 0; i < RuntimeVariables.Instance.unlockLevels.Count; i++)
            {
                allRows[i].showStats = RuntimeVariables.Instance.roundStatus[i];
                allRows[i].rowStatus.SetActive(true);
                allRows[i].rowProgress.SetActive(false);
                allRows[i].rowLocking.SetActive(false);
                allRows[i].roundNumber.text = $"Round {i + 1}";
                allRows[i].roundStats.text = allRows[i].showStats;
            }
        }
    }

    public void ShowCongrats()
    {
        StartCoroutine(ShowCongratsDelay());
    }

    IEnumerator ShowCongratsDelay()
    {
       // congratsPanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
      //  congratsPanel.gameObject.SetActive(false);
        NextLevelReference();
        //winnerPanel.SetActive(true);
        singlePlayerScreen.SetActive(true);
        yield return new WaitForSeconds(4);
        topBar.SetActive(false);
    }


    public void ShowFailPanel()
    {
        StartCoroutine(ShowFailDelay());
    }

    IEnumerator ShowFailDelay()
    {
        losePanel.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        losePanel.gameObject.SetActive(false);
        RuntimeVariables.Instance.isSceneRestarted = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //winnerPanel.SetActive(true);
       singlePlayerScreen.SetActive(true);
    }
}
