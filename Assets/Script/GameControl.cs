using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl instance = null;

    public bool chill;
    public bool normal;
    public bool xtreme;
    [Header("- Theme Name -")]
    public bool nature;
    public bool snow;
    public bool city21;
    public bool glass;
    public bool Oseas;
    public bool Nippon;

    [Header("- Script Components -")]
    public AudioSource audioSpawn;
    public GameObject iapPanel;
    public Transform iapTarget;
	[SerializeField]
	Text highScoreText;

    [SerializeField]
    private Text HighSkor;

	[SerializeField]
	Text yourScoreText;

	[SerializeField]
	Transform spawnPoint;
    public Transform kointarget;
    public Transform powtarget;

	[SerializeField]
	private float spawnRate = 3f;
	float nextSpawn;

	[SerializeField]
	private float timeToBoost = 10f;
	private float nextBoost;

	int highScore = 0, yourScore = 0, SkorFinis = 0;

	public static bool gameStopped;
    public static int jumlahduit;
    public static int jumlahNambahnya; // buat koin + berapa UI
    public static bool pickincoin;
    public static bool pickinHeart;
    public static bool shieldIsRunnin;
    public static int shieldpicked = 0;
    public static int nyawaValue;
    public static bool magnetYes;
    public static int magnetInt;
    private bool magnetCoolDown;
    public static int tabrakValue;
    private int spawnPowerupOrNo;

    public Text nyawaText;
	public Text jumlahDuit;
	public Text jumlahDuit2;
    public Text jumlahDuit3;
    private int realtimemoney;
    //private int jumlahduit2;

	float nextScoreIncrease = 0f;
    private int numTry = 0;
    private float boostbar = 0f;
    public static int stopcode;
    private float currenttime = 0;
    public Text conCost;
    private int concost;

    public GameObject FailUi;
    public GameObject GameUI;
    public GameObject PauseUi;
    public GameObject continueUI;
    public Text countdown;
    public static bool holupp; // IAP hold waktu
    public Text speed;
    private float countDown = 6;
    private bool Stillwaitin = false;
    private bool adsAlreadyShown;
    public static bool adsFinished;
    public Animator conAnime;
    public Animator faded;
    //character anim sleded false if pause
    public Animator animator;
    public Animator anim2;
    public Animator ninjaanim;
    public Animator introAnime;
    public GameObject plus1;
    public Transform plustarget;
    public GameObject plusHeart;
    public GameObject shieldUI;
    public GameObject magnetUI;
    public GameObject[] demShields;
    //gem over alasan stuff
    public GameObject[] reasonTexts;
    

    void Awake()
    {
    #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    #endif
    }
    // Use this for initialization
    void Start () 
    {      
		if (instance == null) 
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		yourScore = 0;
        SkorFinis = 0;
        jumlahduit = 0;
        nyawaValue = 0;
        shieldpicked = 0;
        spawnPowerupOrNo = 0;
        //jumlahduit2 = PlayerPrefs.GetInt("money");
        gameStopped = false;
        magnetYes = false;
        magnetCoolDown = false;
        pickincoin = false;
        pickinHeart = false;
        adsAlreadyShown = false;
        adsFinished = false;
        magnetInt = 0;
        stopcode = 0;
		Time.timeScale = 1.1f;		
        numTry = 1;
		nextSpawn = Time.time + spawnRate;
		nextBoost = Time.unscaledTime + timeToBoost;
        holupp = false;
        SpawnObstacle();
        StartCoroutine(introAwal());
        if (chill == true)
        {
            if (nature == true)
                highScore = PlayerPrefs.GetInt("NchillHS");
            if (snow == true)
                highScore = PlayerPrefs.GetInt("SWchillHS");
            if (city21 == true)
                highScore = PlayerPrefs.GetInt("21chillHS");
            if (glass == true)
                highScore = PlayerPrefs.GetInt("GchillHS");
            if (Oseas == true)
                highScore = PlayerPrefs.GetInt("OschillHS");
            if (Nippon == true)
                highScore = PlayerPrefs.GetInt("NichillHS");
        }
        if (normal == true)
        {
            if (nature == true)
                highScore = PlayerPrefs.GetInt("NnormalHS");
            if (snow == true)
                highScore = PlayerPrefs.GetInt("SWnormalHS");
            if (city21 == true)
                highScore = PlayerPrefs.GetInt("21normalHS");
            if (glass == true)
                highScore = PlayerPrefs.GetInt("GnormalHS");
            if (Oseas == true)
                highScore = PlayerPrefs.GetInt("OsnormalHS");
            if (Nippon == true)
                highScore = PlayerPrefs.GetInt("NinormalHS");
        }
        if (xtreme == true)
        {
            if (nature == true)
                highScore = PlayerPrefs.GetInt("NxtremeHS");
            if (snow == true)
                highScore = PlayerPrefs.GetInt("SWxtremeHS");
            if (city21 == true)
                highScore = PlayerPrefs.GetInt("21xtremeHS");
            if (glass == true)
                highScore = PlayerPrefs.GetInt("GxtremeHS");
            if (Oseas == true)
                highScore = PlayerPrefs.GetInt("OsxtremeHS");
            if (Nippon == true)
                highScore = PlayerPrefs.GetInt("NixtremeHS");
        }

        // UPGRADES SPAWN
        if (PlayerPrefs.GetInt("liveplus") == 1)
        {
            ObjectPooler.Instance.SpawnFromPool("hati", kointarget.position, Quaternion.identity);
        }
        if (PlayerPrefs.GetInt("hyperpack") == 1)
        {
            ObjectPooler.Instance.SpawnFromPool("hypercheat", powtarget.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameStopped)
        {
            //IncreaseYourScore
            if (Time.unscaledTime > nextScoreIncrease)
            {
                yourScore += 1;
                SkorFinis += 1;
                nextScoreIncrease = Time.unscaledTime + 0.02f;
            }
        }
        if (yourScore > highScore)
        {
            if(chill == true)
            {
                if (nature == true)
                    PlayerPrefs.SetInt("NchillHS", yourScore);
                if (snow == true)
                    PlayerPrefs.SetInt("SWchillHS", yourScore);
                if (city21 == true)
                    PlayerPrefs.SetInt("21chillHS", yourScore);
                if (glass == true)
                    PlayerPrefs.SetInt("GchillHS", yourScore);
                if (Oseas == true)
                    PlayerPrefs.SetInt("OschillHS", yourScore);
                if (Nippon == true)
                    PlayerPrefs.SetInt("NichillHS", yourScore);
            }
            if (normal == true)
            {
                if (nature == true)
                    PlayerPrefs.SetInt("NnormalHS", yourScore);
                if (snow == true)
                    PlayerPrefs.SetInt("SWnormalHS", yourScore);
                if (city21 == true)
                    PlayerPrefs.SetInt("21normalHS", yourScore);
                if (glass == true)
                    PlayerPrefs.SetInt("GnormalHS", yourScore);
                if (Oseas == true)
                    PlayerPrefs.SetInt("OsnormalHS", yourScore);
                if (Nippon == true)
                    PlayerPrefs.SetInt("NinormalHS", yourScore);
            }
            if (xtreme == true)
            {
                if (nature == true)
                    PlayerPrefs.SetInt("NxtremeHS", yourScore);
                if (snow == true)
                    PlayerPrefs.SetInt("SWxtremeHS", yourScore);
                if (city21 == true)
                    PlayerPrefs.SetInt("21xtremeHS", yourScore);
                if (glass == true)
                    PlayerPrefs.SetInt("GxtremeHS", yourScore);
                if (Oseas == true)
                    PlayerPrefs.SetInt("OsxtremeHS", yourScore);
                if (Nippon == true)
                    PlayerPrefs.SetInt("NixtremeHS", yourScore);
            }
        }
            //PlayerPrefs.SetInt("HIGHSCORE", yourScore);

        highScoreText.text = "HIGHEST SCORE :  " + highScore;
        yourScoreText.text = "" + yourScore;
        HighSkor.text = "You Scored :  " + SkorFinis;
        realtimemoney = PlayerPrefs.GetInt("money");
        jumlahDuit.text = jumlahduit.ToString();
        jumlahDuit2.text = jumlahduit.ToString();
        jumlahDuit3.text = realtimemoney.ToString();       
        speed.text = "Speed : " + Time.timeScale * 1; 
        conCost.text = concost.ToString();
        nyawaText.text = nyawaValue.ToString();
        currenttime = boostbar + 1.1f;

        if(pickincoin == true)
        {
            PlayerPrefs.SetInt("money", realtimemoney + jumlahNambahnya);
        }

        // countdown mechanism
        if (gameStopped == true && nyawaValue == 0)
        {
            conAnime.SetBool("fadeup", true);
            if (Stillwaitin == true & countDown > 0)
            {
                if(holupp == false)
                {
                    countdown.text = countDown.ToString();
                    countDown -= Time.deltaTime;
                }              
            }
            if (countDown < 1)
            {
                conAnime.SetBool("fadedown", true);
                FailUi.SetActive(true);
                if (adsAlreadyShown == false)
                {
                    int adsvar2 = PlayerPrefs.GetInt("adsvar2");
                    if (adsvar2 < 4)
                    {
                        adsvar2 += 1;
                        PlayerPrefs.SetInt("adsvar2", adsvar2);
                    }
                    if (adsvar2 == 4)
                    {
                        Invoke("showIads", 0.35f);
                        adsvar2 = 0;
                        PlayerPrefs.SetInt("adsvar2", adsvar2);
                    }
                    adsAlreadyShown = true;
                }
            }
        }
        if (Stillwaitin == false & countDown == 0)
        {
            continueUI.SetActive(false);
        }
        // spawn stuffs
        if (Time.time > nextSpawn)
        {
            if (stopcode == 0)
            {
                SpawnObstacle();
                if(yourScore > 950)
                {
                    Invoke("SpawnCoin", 2);
                    spawnPowerupOrNo = Random.Range(1, 4);
                    Invoke("SpawnPowerUps", 2);
                }                           
            }
        }
        if(nyawaValue > 2)
        {
            nyawaValue -= 1;
        }
        // score kalahin high
        if (yourScore > highScore)
        {
            highScoreText.text = "HIGHEST SCORE : " + yourScore;
        }
        // tambah waktu mechanism
        if (Time.unscaledTime > nextBoost && !gameStopped)
        {
            if (boostbar < 2.8f & currenttime < 2.8f)
                BoostTime();
        }
        // plus +1 koin UI
        if (pickincoin == true)
        {
            plus1lol();
        }
        if (pickinHeart == true)
        {
            Instantiate(plusHeart, plustarget.position, Quaternion.identity);           
        }
        if(shieldpicked == 1)
        {
            Instantiate(shieldUI, plustarget.position, Quaternion.identity);
            for(int i = 0; i < demShields.Length; i++)
            {
                demShields[i].SetActive(true);
            }
        }
        if (shieldpicked == 0)
        {
            shieldIsRunnin = false;
            for (int i = 0; i < demShields.Length; i++)
            {
                demShields[i].SetActive(false);
            }
        }
        if(magnetInt == 1)
        {
            Instantiate(magnetUI, plustarget.position, Quaternion.identity);
            magnetInt = 0;
        }
        if (adsFinished == true)
        {
            StartCoroutine(respawn());
            conAnime.SetBool("fadedown", true);
            numTry += 3;
            //jumlahduit = 0;
            adsFinished = false;
            //holupp = false;
        }
    }     
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused();
        }
    }

    // Voids
	public void DinoHit()
	{ 
        Time.timeScale = 1.1f;
        if (nyawaValue == 0)
        {
            //if (yourScore > highScore)
                //PlayerPrefs.SetInt("HIGHSCORE", yourScore);           
            gameStopped = true;
            Stillwaitin = true;
            countDown = 6.0f;
            continueUI.SetActive(true);
            GameUI.SetActive(false);
            //PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + jumlahduit);
            stopcode = 1;
            conAnime.SetBool("fadeup", true);
            concost = 50 * numTry;
        }
        if(nyawaValue > 0)
        {
            pickinHeart = false;
            gameStopped = true;
            DinoControl.nobutton = true;
            Invoke("respawned", 0.65f);
            stopcode = 1;
        }
        if(tabrakValue == 0)
        {
            reasonTexts[0].SetActive(true);
            reasonTexts[1].SetActive(false);
            reasonTexts[2].SetActive(false);
            reasonTexts[3].SetActive(false);
        }
        if (tabrakValue == 1)
        {
            reasonTexts[0].SetActive(false);
            reasonTexts[1].SetActive(true);
            reasonTexts[2].SetActive(false);
            reasonTexts[3].SetActive(false);
        }
        if (tabrakValue == 2)
        {
            reasonTexts[0].SetActive(false);
            reasonTexts[1].SetActive(false);
            reasonTexts[2].SetActive(true);
            reasonTexts[3].SetActive(false);
        }
        if (tabrakValue == 3)
        {
            reasonTexts[0].SetActive(false);
            reasonTexts[1].SetActive(false);
            reasonTexts[2].SetActive(false);
            reasonTexts[3].SetActive(true);
        }
    }   
	private void SpawnObstacle()
	{
        // for object pooling mechanism, i used a kinda complex (at sight) if conditions
        if(nature)
        #region Algorithm
        {
            if (chill)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 6);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 10);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (normal)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 7);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 12);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 10:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 11:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (xtreme)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 5);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 4);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 11);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 10:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
        }
        #endregion
        if (snow)
        #region Algorithm
        {
            if (chill)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 6);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 10);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (normal)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 7);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 12);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 10:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 11:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (xtreme)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 5);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 4);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 11);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 10:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
        }
        #endregion
        if (Nippon)
        #region Algorithm
        {
            if (chill)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 7);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("jump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("gate", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("jump", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 8);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("jump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("gate", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (normal)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 8);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("gate", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("jump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("jump", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 10);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("gate", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("jump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (xtreme)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 7);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("gate", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 8);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("house", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("short", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("gate", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("gate", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
        }
        #endregion
        if (Oseas)
        #region Algorithm
        {
            if (chill)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 4);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("barrel", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("kursi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("box", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("box", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 9);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("barrel", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("kursi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("box", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("barrel", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (normal)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 6);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("barrel", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("box", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("kursi", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("box", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 10);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("kursi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("barrel", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("barrel", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("box", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (xtreme)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 5);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 9);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("tinggi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("kursi", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("barrel", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
        }
        #endregion
        if (city21)
        #region Algorithm
        {
            if (chill)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 6);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("jamp", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("halte", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("bas", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("jamp", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("drone", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 4);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("blok", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("tiang", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("jamp", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 8);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("drone", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("tiang", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("halte", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("jamp", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bas", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (normal)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 6);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("jamp", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("halte", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("bas", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("drone", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 4);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("blok", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("tiang", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("jamp", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 10);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("drone", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("tiang", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("blok", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("halte", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("jamp", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("bas", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (xtreme)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 6);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("drone", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("tiang", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("bas", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 4);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("blok", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("tiang", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("jamp", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 11);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("blok", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("tiang", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("halte", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bas", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("bas", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
        }
        #endregion
        if (glass)
        #region Algorithm
        {
            if (chill)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 6);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 10);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (normal)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 7);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 3);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 12);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("rock2", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 10:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 11:
                            ObjectPooler.Instance.SpawnFromPool("jumpsled", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
            if (xtreme)
            {
                if (yourScore < 1000)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 5);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 1000 & yourScore < 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 4);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
                if (yourScore > 2200)
                {
                    nextSpawn = Time.time + spawnRate;
                    int randomObstacle = Random.Range(0, 11);
                    switch (randomObstacle)
                    {
                        case 0:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 1:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 2:
                            ObjectPooler.Instance.SpawnFromPool("log", spawnPoint.position, Quaternion.identity);
                            break;
                        case 3:
                            ObjectPooler.Instance.SpawnFromPool("sled", spawnPoint.position, Quaternion.identity);
                            break;
                        case 4:
                            ObjectPooler.Instance.SpawnFromPool("rock1", spawnPoint.position, Quaternion.identity);
                            break;
                        case 5:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                        case 6:
                            ObjectPooler.Instance.SpawnFromPool("bird", spawnPoint.position, Quaternion.identity);
                            break;
                        case 7:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 8:
                            ObjectPooler.Instance.SpawnFromPool("trap", spawnPoint.position, Quaternion.identity);
                            break;
                        case 9:
                            ObjectPooler.Instance.SpawnFromPool("5coinjump", spawnPoint.position, Quaternion.identity);
                            break;
                        case 10:
                            ObjectPooler.Instance.SpawnFromPool("hyper", spawnPoint.position, Quaternion.identity);
                            break;
                    }
                }
            }
        }
        #endregion
    }
    private void SpawnCoin()
    {
        int ranKoin = Random.Range(0, 3);
      
        if (ranKoin == 2)
        {           
            if (shieldpicked == 2)
            {
                int ranKoin2 = Random.Range(0, 2);
                if(ranKoin2 == 1)
                    ObjectPooler.Instance.SpawnFromPool("coinbag", kointarget.position, Quaternion.identity);
                else
                    ObjectPooler.Instance.SpawnFromPool("coin", kointarget.position, Quaternion.identity);
            }
            if (shieldpicked == 0)
            {
                int ranKoin3 = Random.Range(0, 3);
                switch(ranKoin3)
                {
                    case 0:
                        ObjectPooler.Instance.SpawnFromPool("coin", kointarget.position, Quaternion.identity);
                        break;
                    case 1:
                        ObjectPooler.Instance.SpawnFromPool("coinbag", kointarget.position, Quaternion.identity);
                        break;
                    case 2:
                        if(!xtreme)
                            ObjectPooler.Instance.SpawnFromPool("shield", kointarget.position, Quaternion.identity);
                        break;
                }
            }                
        }
        else
        {
            if(ranKoin == 0)
                ObjectPooler.Instance.SpawnFromPool("coin", kointarget.position, Quaternion.identity);
            else
                ObjectPooler.Instance.SpawnFromPool("coinbag", kointarget.position, Quaternion.identity);
        }
    }
    private void SpawnPowerUps()
    {  // hanya terjadi jika spawnPowerupOrNo == 3 or 2     
        if (spawnPowerupOrNo == 3)
        {
            int spawnOrNo = Random.Range(0, 2); // seleksi lagi antara 0 dan 1, jika 1 maka spawn
            if (spawnOrNo == 1)
            {
                int randomPow = Random.Range(0, 3); // seleksi mana yg di spawn: 0 hati, 1 magnet, 2 koin8
                if (randomPow == 0) // hati
                {
                    if(nyawaValue < 2)
                    {
                        if (!xtreme)
                            ObjectPooler.Instance.SpawnFromPool("hati", powtarget.position, Quaternion.identity);
                    }
                }
                if (randomPow == 1) // magnet
                {
                    if (magnetYes == false && magnetCoolDown == false)
                    {
                        ObjectPooler.Instance.SpawnFromPool("magnet", powtarget.position, Quaternion.identity);
                        magnetCoolDown = true;
                        StartCoroutine(magnetCool());
                    }
                    if (magnetYes == false && magnetCoolDown == true)
                    {
                        ObjectPooler.Instance.SpawnFromPool("8coin", powtarget.position, Quaternion.identity); //spawn koin8
                    }                    
                }
                if (randomPow == 2) // 8 koin
                {
                    ObjectPooler.Instance.SpawnFromPool("8coin", powtarget.position, Quaternion.identity); //spawn koin8
                }
            }
        }
        if (spawnPowerupOrNo == 2)
        {
            int rendemAgein = Random.Range(0, 2);
            if(rendemAgein == 0)
            {
                if (magnetYes == false && magnetCoolDown == false)
                {
                    int magnetrendem = Random.Range(0, 2);
                    if (magnetrendem == 1)
                    {
                        ObjectPooler.Instance.SpawnFromPool("magnet", powtarget.position, Quaternion.identity);
                        magnetCoolDown = true;
                        StartCoroutine(magnetCool());
                    }
                }
                else
                    ObjectPooler.Instance.SpawnFromPool("8coin", powtarget.position, Quaternion.identity); //spawn koin8
            }                  
            if(rendemAgein == 1 && timeToBoost > 900) // only for chill mode
            {
                 ObjectPooler.Instance.SpawnFromPool("8coin", powtarget.position, Quaternion.identity); //spawn koin8
            }
        }
    }
    IEnumerator magnetCool()
    {
        yield return new WaitForSeconds(15);
        magnetCoolDown = false;
    }
    public void plus1lol()
    {
        Instantiate(plus1, plustarget.position, Quaternion.identity);
        pickincoin = false;
    }
    public void Continue()
    {
        if (PlayerPrefs.GetInt("money") > concost)
        {
            StartCoroutine(respawn());
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - concost);
            conAnime.SetBool("fadedown", true);
            numTry += 3;
            //jumlahduit = 0;
        }
        else          
            Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
            
    }
    public void continueAds()
    {
        showRads();
        //holupp = true;
    }
    public void mehcon()
    {
        conAnime.SetBool("fadedown", true);
        FailUi.SetActive(true);
        if (adsAlreadyShown == false)
        {     
            int adsvar2 = PlayerPrefs.GetInt("adsvar2");
            if(adsvar2 < 4)
            {
                adsvar2 += 1;
                PlayerPrefs.SetInt("adsvar2", adsvar2);
            }
            if(adsvar2 == 4)
            {
                Invoke("showIads", 0.35f);
                adsvar2 = 0;
                PlayerPrefs.SetInt("adsvar2", adsvar2);
            }
            adsAlreadyShown = true;
        }
    }
    private void showIads()
    {
        if(PlayerPrefs.GetInt("adsremoved") == 0)
        {
            AdsManager.IadsShow = true;
        }       
    }
    private void showRads()
    {
        AdsManager.RadsShow = true;
    }
    private void BoostTime()
	{
		nextBoost = Time.unscaledTime + timeToBoost;
		Time.timeScale += 0.20f;
        boostbar += 0.20f;
	}
	public void RestartGame()
	{
		SceneManager.LoadScene ("GamePlay");
	}
    public void GamePaused()
    {
        Time.timeScale = 0;
        //gameStopped = true;
        //GameUI.SetActive(false);
        PauseUi.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = currenttime;
        gameStopped = false;
        GameUI.SetActive(true);
        PauseUi.SetActive(false);
        animator.SetBool("sleded", false);
        anim2.SetBool("sleded", false);
        ninjaanim.SetBool("sleded", false);
    }
    private void respawned()
    {
        StartCoroutine(respawn());
        DinoControl.nobutton = false;
    }
    IEnumerator introAwal()
    {
        yield return new WaitForSeconds(3.5f);
        introAnime.SetTrigger("outtt");
    }
    IEnumerator respawn()
    {
        faded.SetTrigger("faded");        
        yield return new WaitForSeconds(0.7f);
        audioSpawn.Play();
        stopcode = 2; // biar ga langsung ilang obstacle yang ditubruk
        FailUi.SetActive(false);
        GameUI.SetActive(true);
        continueUI.SetActive(false);
        yourScoreText.text = " " + yourScore;
        gameStopped = false;
        yield return new WaitForSeconds(0.1f);
        stopcode = 0; // game kembali berjalan
        faded.SetTrigger("continue");
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = currenttime;
        if(nyawaValue > 0) // supaya pas mati bayar ga mines
        {
            nyawaValue -= 1;
            Instantiate(plusHeart, plustarget.position, Quaternion.identity);
        }        
    }
    public void plusCoin()
    {
        Instantiate(iapPanel, iapTarget.position, Quaternion.identity);
    }
}

