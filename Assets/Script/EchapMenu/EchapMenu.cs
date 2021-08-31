using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EchapMenu : MonoBehaviour
{
    public void RestoreGame()
    {
        Scene restore = SceneManager.GetActiveScene();
        SceneManager.LoadScene(restore.name);   // On lance le 1er niveau
    }
    public void LoadAGame1()
    {
        // Gere le chargement de la partie
    }

    public void QuitTheGame1()
    {
        Application.Quit(); // On quitte le jeu
    }
}
