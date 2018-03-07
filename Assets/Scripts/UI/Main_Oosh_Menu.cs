using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Oosh_Menu : MonoBehaviour {

	public void Woosh() //Wooshes to next scene in the Game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Toosh() //Tooshes the Game away
    {
        Application.Quit();
    }
}
