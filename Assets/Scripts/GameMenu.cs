using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public static bool isOnePlayerGame = true;

    public static int livesPlayerOne;
    public static int livesPlayerTwo;

    public static int playerOnePelletsConsumed = 0;
    public static int playerTwoPelletsConsumed = 0;

    public Text playerTextOne;
    public Text playerTextTwo;
    public Text playerSelected;
    public Text outfit;

    public static bool ok = true;

    OutFit o = new OutFit();

    private void Start()
    {
        if (ok)
        {
            ok = false;
            StartMenu();
        }

        Screen.SetResolution(1024, 768, false);
    }

    public void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitButton();
        }
    }

    public void OnePlayerGame()
    {
        AudioListener.pause = false;

        isOnePlayerGame = true;

        playerOnePelletsConsumed = 0;
        playerTwoPelletsConsumed = 0;

        GameBoard.playerOneScore = 0;
        GameBoard.playerTwoScore = 0;

        livesPlayerOne = 3;
        livesPlayerTwo = 0;

        SceneManager.LoadScene("Level1");
    }

    public void TwoPlayerGame()
    {
        AudioListener.pause = false;

        isOnePlayerGame = false;

        playerOnePelletsConsumed = 0;
        playerTwoPelletsConsumed = 0;

        GameBoard.playerOneScore = 0;
        GameBoard.playerTwoScore = 0;

        livesPlayerOne = 3;
        livesPlayerTwo = 3;

        SceneManager.LoadScene("OutFitForTwo");
    }

    public void OutfitButton()
    {

        SceneManager.LoadScene("OutFit");

    }

    public void StartMenu()
    {
        FileStream stream = new FileStream("Save.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        StreamReader reader = new StreamReader(stream);
        try
        {
            string mes = reader.ReadToEnd();
            GameBoard.highScore = int.Parse(mes);
            reader.Close();
            stream.Close();
        }
        catch
        {
            reader.Close();
            stream.Close();
        }
    }

    public void ExitButton()
    {

        FileStream stream = new FileStream("Save.txt", FileMode.Create, FileAccess.ReadWrite);
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(GameBoard.highScore.ToString().ToCharArray(), 0, GameBoard.highScore.ToString().Length);
        writer.Close();
        stream.Close();

        Application.Quit();
    }
}
