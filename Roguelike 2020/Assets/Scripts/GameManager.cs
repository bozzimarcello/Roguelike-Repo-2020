using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int startingLevel = 1;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = GetComponent<LevelManager>();
        levelManager.CreateLevel(startingLevel);
    }

}
