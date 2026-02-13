using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(int difficultyIndex)
    {
        GameManager.Instance.SetDifficulty(difficultyIndex);
        SceneManager.LoadScene("Game");
    }
}

