using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Bibliotheque unity qui gere les scenes

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("FirstStage");   // On lance le 1er niveau
    }
    public void LoadGame()
    {
        // Gere le chargement de la partie
    }
    public void GameOptions()
    {
        // Gere les options du jeu
    }
    public void QuitGame()
    {
        Application.Quit(); // On quitte le jeu
    }
}