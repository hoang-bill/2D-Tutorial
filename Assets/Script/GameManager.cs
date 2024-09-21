using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score = 0;
    bool isGameOver = false;
    public int lives = 1;
    
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject boltGoldPrefab;
    [SerializeField] GameObject redPillPrefab;
    [SerializeField] GameObject Player;

    // update player lives left
    [SerializeField] GameObject lifeIconPrefab; 
    [SerializeField] Transform livesContainer; 

    float spawnY;
    float xMin;
    float xMax;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f,0,0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.9f,0,0)).x;
        spawnY = Player.transform.position.y;

        // initialize live display
        // UpdateLivesDisplay(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit") && isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();

        if (score % 30 == 0)
        {
            SpawnBoltGold();
        }
        if (score % 10 == 0)
        {
            SpawnRedPill();
        }
    }

    public void ManageLives(int amount)
    {
        lives += amount; // Increase or decrease the number of lives based on the amount
        livesText.text = "Lives: " + lives.ToString();
        // UpdateLivesDisplay(); // Update the lives display
    }

    // void UpdateLivesDisplay() // Added this method to update the lives display
    // {
    //     // Clear the existing life icons
    //     foreach (Transform child in livesContainer)
    //     {
    //         Destroy(child.gameObject);
    //     }

    //     // Create new life icons based on the current number of lives
    //     for (int i = 0; i < lives; i++)
    //     {
    //         Debug.Log("show icon");
    //         Instantiate(lifeIconPrefab, livesContainer);
    //     }
    // }

    public void SpawnBoltGold()
    {
        float randomX = Random.Range(xMin,xMax);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(boltGoldPrefab, spawnPosition, Quaternion.identity);
    }

    public void SpawnRedPill()
    {
        float randomX = Random.Range(xMin, xMax);
        float spawnPosY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.1f, 0)).y; // Spawn above the top of the screen
        Vector3 spawnPosition = new Vector3(randomX, spawnPosY, 0f);
        Instantiate(redPillPrefab, spawnPosition, Quaternion.identity);
    }

    public void InitiateGameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
}
