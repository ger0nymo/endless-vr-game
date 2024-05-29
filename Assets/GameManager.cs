using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float initialSpawnInterval = 2f;
    public float minSpawnInterval = 0.5f;
    public float difficultyIncreaseInterval = 10f;
    public float spawnMinY = 1.8f;
    public float spawnMaxY = 2.97f;
    public float spawnMinZ = -28.43f;
    public float spawnMaxZ = -27f;
    public float constantX = 14.55f;

    private float spawnTimer;
    private float difficultyTimer;
    private float currentSpawnInterval;
    
    public TMPro.TMP_Dropdown dropdown;

    private bool started = false;

    public int score = 0;
    
    public int difficulty = 0;
    
    public TMPro.TMP_Text scoreText;

    public GameObject startModal;
    public GameObject endText;
    
    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        spawnTimer = currentSpawnInterval;
        difficultyTimer = difficultyIncreaseInterval;
        
        dropdown.onValueChanged.AddListener(delegate
        {
            SetDifficulty(dropdown.value);
        });
    }

    private void Update()
    {
        if (started)
        {
            spawnTimer -= Time.deltaTime;
            difficultyTimer -= Time.deltaTime;

            if (spawnTimer <= 0f)
            {
                SpawnObstacle();
                score += Convert.ToInt32(Mathf.Pow(2, difficulty));
                scoreText.text = "Score: " + score;
                spawnTimer = currentSpawnInterval;
            }

            if (difficultyTimer <= 0f)
            {
                IncreaseDifficulty();
                difficultyTimer = difficultyIncreaseInterval;
            }
        }
    }

    private void SpawnObstacle()
    {
        float randomY = Random.Range(spawnMinY, spawnMaxY);
        float randomZ = Random.Range(spawnMinZ, spawnMaxZ);

        Vector3 spawnPosition = new Vector3(constantX, randomY, randomZ);

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

    private void IncreaseDifficulty()
    {
        currentSpawnInterval = Mathf.Max(currentSpawnInterval * 0.9f, minSpawnInterval);
    }
    
    public void StartGame()
    {
        started = true;
        score = 0;
        scoreText.text = "Score: " + score;
        startModal.SetActive(false);
        endText.SetActive(false);
        SetDifficulty(difficulty);
        currentSpawnInterval = initialSpawnInterval;
    }
    
    public void EndGame()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject block in blocks)
        {
            Destroy(block);
        }
        started = false;
        endText.SetActive(true);
        startModal.SetActive(true);
    }
    
    private void SetDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;
        Debug.Log("Difficulty set to " + newDifficulty);
        switch (newDifficulty)
        {
            case 0:
                initialSpawnInterval = 2f;
                minSpawnInterval = 1.4f;
                difficultyIncreaseInterval = 10f;
                break;
            case 1:
                initialSpawnInterval = 1.5f;
                minSpawnInterval = 0.4f;
                difficultyIncreaseInterval = 6f;
                break;
            case 2:
                initialSpawnInterval = 1f;
                minSpawnInterval = 0.1f;
                difficultyIncreaseInterval = 3f;
                break;
        }
    }
}