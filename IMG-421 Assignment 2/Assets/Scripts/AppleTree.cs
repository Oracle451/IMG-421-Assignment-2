using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{   
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject RottenApplePrefab;
    
    // Speed at which the AppleTree moves
    public float speed = 1f;
    public float dropTime = 2f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    void Start()
    {
        // Start dropping apples
        InvokeRepeating("DropApple", 2f, dropTime);

        switch (GameManager.Instance.currentDifficulty)
        {
            case GameManager.Difficulty.Easy:
                speed = 0f;
                break;

            case GameManager.Difficulty.Medium:
                speed = 5f;
                break;

            case GameManager.Difficulty.Hard:
                speed = 10f;
                break;
            
        }
    }

    void DropApple()
    {
        if (GameManager.Instance.currentDifficulty == GameManager.Difficulty.Hard)
        {
            SpawnApple();
            if (GameManager.Instance.currentDifficulty == GameManager.Difficulty.Hard)
            {
                Invoke(nameof(SpawnApple), 0.4f); // delay second apple
            }
        }
        else
        {
            SpawnApple();
        }
    }

    void SpawnApple()
    {
        GameObject prefabToSpawn = applePrefab;

        if (GameManager.Instance.currentDifficulty == GameManager.Difficulty.Medium || GameManager.Instance.currentDifficulty == GameManager.Difficulty.Hard)
        {
            // 30% chance for rotten apple
            if (Random.value < 0.3f)
                prefabToSpawn = RottenApplePrefab;
        }

        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs (speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs (speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
