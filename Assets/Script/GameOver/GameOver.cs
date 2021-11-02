using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);   // On lance le 1er niveau
    }
    public void LoadAGame()
    {
        // Gere le chargement de la partie
    }

    public void QuitTheGame()
    {
        Application.Quit(); // On quitte le jeu
    }

}
