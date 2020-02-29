using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; 		
//Tells Random to use the Unity Engine random number generator.
public class LevelManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject[] walls;
    [SerializeField]
    private GameObject[] floors;
    [SerializeField]
    private GameObject[] dirts;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private GameObject exit;
    [SerializeField]
    private GameObject food;
    [SerializeField]
    private GameObject soda;
    [SerializeField]
    private GameObject player;

    [Header("Random generation factors")]
    [SerializeField]
    private int dirtFactor = 4;
    [SerializeField]
    private int foodFactor = 8;
    [SerializeField]
    private int enemiesFactor = 8;


    private int levelWidth = 17;
    private int levelHeight = 9;
    private bool[,] takenCell;

    // Start is called before the first frame update
    public void CreateLevel(int level)
    {
        CreateWalls();
        CreateFloor();
        SpawnPlayer();
        SpawnExit();
        CreateDirt(level);
        SpawnItems(level);
        SpawnEnemies(level);
    }

    private void CreateWalls()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                if (x == 0 || y == 0 || x == levelWidth - 1 || y == levelHeight - 1)
                {
                    int randomWall = Random.Range(0, walls.Length);
                    Instantiate(walls[randomWall], new Vector2(x, y), Quaternion.identity);
                }
            }
        }
    }

    private void CreateFloor()
    {
        takenCell = new bool[levelWidth, levelHeight];

        for (int x = 1; x < levelWidth-1; x++)
        {
            for (int y = 1; y < levelHeight-1; y++)
            {
                int randomFloor = Random.Range(0, floors.Length);
                Instantiate(floors[randomFloor], new Vector2(x, y), Quaternion.identity);
                takenCell[x, y] = false;
            }
        }
    }

    private void SpawnPlayer()
    {
        int randomX = Random.Range(2, levelWidth - 2);
        int randomY = Random.Range(2, levelHeight - 2);
        Instantiate(player, new Vector2(randomX, randomY), Quaternion.identity);
        takenCell[randomX, randomY] = true;
    }

    private void SpawnExit()
    {
        int randomX = Random.Range(2, levelWidth - 2);
        int randomY = Random.Range(2, levelHeight - 2);
        Instantiate(exit, new Vector2(randomX, randomY), Quaternion.identity);
        takenCell[randomX, randomY] = true;
    }

    private void CreateDirt(int level)
    {
        int randomDirtNumber = Random.Range(0, level * dirtFactor);
        for(int d = 0; d < randomDirtNumber; d++)
        {
            int randomX = Random.Range(2, levelWidth - 2);
            int randomY = Random.Range(2, levelHeight - 2);
            if (takenCell[randomX, randomY]) continue;
            int randomDirt = Random.Range(0, dirts.Length);
            Instantiate(dirts[randomDirt], new Vector2(randomX, randomY), Quaternion.identity);
            takenCell[randomX, randomY] = true;
        }
    }

    private void SpawnItems(int level)
    {
        int randomDirtNumber = Random.Range(0, level * foodFactor);
        for (int d = 0; d < randomDirtNumber; d++)
        {
            int randomX = Random.Range(2, levelWidth - 2);
            int randomY = Random.Range(2, levelHeight - 2);
            if (takenCell[randomX, randomY]) continue;
            if (d%2 == 0)
            {
                Instantiate(food, new Vector2(randomX, randomY), Quaternion.identity);
            }
            else
            {
                Instantiate(soda, new Vector2(randomX, randomY), Quaternion.identity);
            }
            takenCell[randomX, randomY] = true;
        }
    }

    private void SpawnEnemies(int level)
    {
        int randomDirtNumber = Random.Range(0, level * enemiesFactor);
        for (int d = 0; d < randomDirtNumber; d++)
        {
            int randomX = Random.Range(2, levelWidth - 2);
            int randomY = Random.Range(2, levelHeight - 2);
            if (takenCell[randomX, randomY]) continue;
            if (d % 2 == 0)
            {
                Instantiate(enemies[0], new Vector2(randomX, randomY), Quaternion.identity);
            }
            else
            {
                Instantiate(enemies[1], new Vector2(randomX, randomY), Quaternion.identity);
            }
            takenCell[randomX, randomY] = true;
        }
    }
}
