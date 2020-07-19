using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnClick : MonoBehaviour
{

    static int numberPacMan = 1;
    static int numberPacMan2 = 1;
    static int numberGhost = 1;

    public void Start()
    {
        Screen.SetResolution(1024, 768, false);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        try
        {
            OnePlayerSwitchPacMan();

            if (!GameMenu.isOnePlayerGame)
            {
                TwoPlayerSwitchPacMan();
            }

            SwitchGhost();
        }
        catch
        {

        }

    }

    void OnePlayerSwitchPacMan()
    {
        try
        {
            if (numberPacMan == 1)
            {

                OutFit.onePlayerIdleSprite = Resources.Load("OutFit/PacMan/Classic/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.onePlayerDeathAnimation = Resources.Load("OutFit/PacMan/Classic/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.onePlayerChompAnimation = Resources.Load("OutFit/PacMan/Classic/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("PacMan").GetComponent<Image>().sprite = OutFit.onePlayerIdleSprite;
            }
            else if (numberPacMan == 2)
            {
                OutFit.onePlayerIdleSprite = Resources.Load("OutFit/PacMan/Neon/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.onePlayerDeathAnimation = Resources.Load("OutFit/PacMan/Neon/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.onePlayerChompAnimation = Resources.Load("OutFit/PacMan/Neon/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("PacMan").GetComponent<Image>().sprite = OutFit.onePlayerIdleSprite;
            }
            else if (numberPacMan == 3)
            {
                OutFit.onePlayerIdleSprite = Resources.Load("OutFit/PacMan/Blue/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.onePlayerDeathAnimation = Resources.Load("OutFit/PacMan/Blue/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.onePlayerChompAnimation = Resources.Load("OutFit/PacMan/Blue/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("PacMan").GetComponent<Image>().sprite = OutFit.onePlayerIdleSprite;
            }
            else if (numberPacMan == 4)
            {
                OutFit.onePlayerIdleSprite = Resources.Load("OutFit/PacMan/Green/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.onePlayerDeathAnimation = Resources.Load("OutFit/PacMan/Green/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.onePlayerChompAnimation = Resources.Load("OutFit/PacMan/Green/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("PacMan").GetComponent<Image>().sprite = OutFit.onePlayerIdleSprite;
            }
            else if (numberPacMan == 5)
            {
                OutFit.onePlayerIdleSprite = Resources.Load("OutFit/PacMan/Red/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.onePlayerDeathAnimation = Resources.Load("OutFit/PacMan/Red/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.onePlayerChompAnimation = Resources.Load("OutFit/PacMan/Red/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("PacMan").GetComponent<Image>().sprite = OutFit.onePlayerIdleSprite;
            }
        }
        catch
        {

        }
    }

    void TwoPlayerSwitchPacMan()
    {
        try
        {
            if (numberPacMan2 == 1)
            {

                OutFit.twoPlayerIdleSprite = Resources.Load("OutFit/PacMan/Classic/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.twoPlayerDeathAnimation = Resources.Load("OutFit/PacMan/Classic/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.twoPlayerChompAnimation = Resources.Load("OutFit/PacMan/Classic/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
       
                GameObject.Find("TwoPacMan").GetComponent<Image>().sprite = OutFit.twoPlayerIdleSprite;
            }
            else if (numberPacMan2 == 2)
            {
                OutFit.twoPlayerIdleSprite = Resources.Load("OutFit/PacMan/Neon/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.twoPlayerDeathAnimation = Resources.Load("OutFit/PacMan/Neon/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.twoPlayerChompAnimation = Resources.Load("OutFit/PacMan/Neon/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("TwoPacMan").GetComponent<Image>().sprite = OutFit.twoPlayerIdleSprite;
            }
            else if (numberPacMan2 == 3)
            {
                OutFit.twoPlayerIdleSprite = Resources.Load("OutFit/PacMan/Blue/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.twoPlayerDeathAnimation = Resources.Load("OutFit/PacMan/Blue/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.twoPlayerChompAnimation = Resources.Load("OutFit/PacMan/Blue/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("TwoPacMan").GetComponent<Image>().sprite = OutFit.twoPlayerIdleSprite;
            }
            else if (numberPacMan2 == 4)
            {
                OutFit.twoPlayerIdleSprite = Resources.Load("OutFit/PacMan/Green/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.twoPlayerDeathAnimation = Resources.Load("OutFit/PacMan/Green/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.twoPlayerChompAnimation = Resources.Load("OutFit/PacMan/Green/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("TwoPacMan").GetComponent<Image>().sprite = OutFit.twoPlayerIdleSprite;
            }
            else if (numberPacMan2 == 5)
            {
                OutFit.twoPlayerIdleSprite = Resources.Load("OutFit/PacMan/Red/pacman_chomp_2", typeof(Sprite)) as Sprite;
                OutFit.twoPlayerDeathAnimation = Resources.Load("OutFit/PacMan/Red/AnimDeath/pacman_death_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                OutFit.twoPlayerChompAnimation = Resources.Load("OutFit/PacMan/Red/AnimChomp/pacman_chomp_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;

                GameObject.Find("TwoPacMan").GetComponent<Image>().sprite = OutFit.twoPlayerIdleSprite;
            }
        }
        catch
        {

        }
    }

    void SwitchGhost()
    {
        try
        {
            switch (numberGhost)
            {

                case 1:

                    OutFit.BlinkyUp = Resources.Load("OutFit/Ghosts/Classic/Blinky/Anim/blinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyDown = Resources.Load("OutFit/Ghosts/Classic/Blinky/Anim/blinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyLeft = Resources.Load("OutFit/Ghosts/Classic/Blinky/Anim/blinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyRight = Resources.Load("OutFit/Ghosts/Classic/Blinky/Anim/blinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkySprite = Resources.Load("OutFit/Ghosts/Classic/Blinky/blinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.PinkyUp = Resources.Load("OutFit/Ghosts/Classic/Pinky/Anim/pinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyDown = Resources.Load("OutFit/Ghosts/Classic/Pinky/Anim/pinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyLeft = Resources.Load("OutFit/Ghosts/Classic/Pinky/Anim/pinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyRight = Resources.Load("OutFit/Ghosts/Classic/Pinky/Anim/pinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkySprite = Resources.Load("OutFit/Ghosts/Classic/Pinky/pinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.InkyUp = Resources.Load("OutFit/Ghosts/Classic/Inky/Anim/inky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyDown = Resources.Load("OutFit/Ghosts/Classic/Inky/Anim/inky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyLeft = Resources.Load("OutFit/Ghosts/Classic/Inky/Anim/inky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyRight = Resources.Load("OutFit/Ghosts/Classic/Inky/Anim/inky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkySprite = Resources.Load("OutFit/Ghosts/Classic/Inky/inky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.ClydeUp = Resources.Load("OutFit/Ghosts/Classic/Clyde/Anim/clyde_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeDown = Resources.Load("OutFit/Ghosts/Classic/Clyde/Anim/clyde_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeLeft = Resources.Load("OutFit/Ghosts/Classic/Clyde/Anim/clyde_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeRight = Resources.Load("OutFit/Ghosts/Classic/Clyde/Anim/clyde_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeSprite = Resources.Load("OutFit/Ghosts/Classic/Clyde/clyde_left_1", typeof(Sprite)) as Sprite;

                    GameObject.Find("Blinky").GetComponent<Image>().sprite = OutFit.BlinkySprite;
                    GameObject.Find("Pinky").GetComponent<Image>().sprite = OutFit.PinkySprite;
                    GameObject.Find("Inky").GetComponent<Image>().sprite = OutFit.InkySprite;
                    GameObject.Find("Clyde").GetComponent<Image>().sprite = OutFit.ClydeSprite;

                    break;

                case 2:

                    OutFit.BlinkyUp = Resources.Load("OutFit/Ghosts/Band/Blinky/Anim/blinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyDown = Resources.Load("OutFit/Ghosts/Band/Blinky/Anim/blinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyLeft = Resources.Load("OutFit/Ghosts/Band/Blinky/Anim/blinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyRight = Resources.Load("OutFit/Ghosts/Band/Blinky/Anim/blinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkySprite = Resources.Load("OutFit/Ghosts/Band/Blinky/blinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.PinkyUp = Resources.Load("OutFit/Ghosts/Band/Pinky/Anim/pinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyDown = Resources.Load("OutFit/Ghosts/Band/Pinky/Anim/pinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyLeft = Resources.Load("OutFit/Ghosts/Band/Pinky/Anim/pinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyRight = Resources.Load("OutFit/Ghosts/Band/Pinky/Anim/pinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkySprite = Resources.Load("OutFit/Ghosts/Band/Pinky/pinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.InkyUp = Resources.Load("OutFit/Ghosts/Band/Inky/Anim/inky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyDown = Resources.Load("OutFit/Ghosts/Band/Inky/Anim/inky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyLeft = Resources.Load("OutFit/Ghosts/Band/Inky/Anim/inky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyRight = Resources.Load("OutFit/Ghosts/Band/Inky/Anim/inky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkySprite = Resources.Load("OutFit/Ghosts/Band/Inky/inky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.ClydeUp = Resources.Load("OutFit/Ghosts/Band/Clyde/Anim/clyde_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeDown = Resources.Load("OutFit/Ghosts/Band/Clyde/Anim/clyde_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeLeft = Resources.Load("OutFit/Ghosts/Band/Clyde/Anim/clyde_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeRight = Resources.Load("OutFit/Ghosts/Band/Clyde/Anim/clyde_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeSprite = Resources.Load("OutFit/Ghosts/Band/Clyde/clyde_left_1", typeof(Sprite)) as Sprite;

                    GameObject.Find("Blinky").GetComponent<Image>().sprite = OutFit.BlinkySprite;
                    GameObject.Find("Pinky").GetComponent<Image>().sprite = OutFit.PinkySprite;
                    GameObject.Find("Inky").GetComponent<Image>().sprite = OutFit.InkySprite;
                    GameObject.Find("Clyde").GetComponent<Image>().sprite = OutFit.ClydeSprite;

                    break;

                case 3:

                    OutFit.BlinkyUp = Resources.Load("OutFit/Ghosts/Beard/Blinky/Anim/blinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyDown = Resources.Load("OutFit/Ghosts/Beard/Blinky/Anim/blinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyLeft = Resources.Load("OutFit/Ghosts/Beard/Blinky/Anim/blinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyRight = Resources.Load("OutFit/Ghosts/Beard/Blinky/Anim/blinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkySprite = Resources.Load("OutFit/Ghosts/Beard/Blinky/blinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.PinkyUp = Resources.Load("OutFit/Ghosts/Beard/Pinky/Anim/pinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyDown = Resources.Load("OutFit/Ghosts/Beard/Pinky/Anim/pinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyLeft = Resources.Load("OutFit/Ghosts/Beard/Pinky/Anim/pinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyRight = Resources.Load("OutFit/Ghosts/Beard/Pinky/Anim/pinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkySprite = Resources.Load("OutFit/Ghosts/Beard/Pinky/pinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.InkyUp = Resources.Load("OutFit/Ghosts/Beard/Inky/Anim/inky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyDown = Resources.Load("OutFit/Ghosts/Beard/Inky/Anim/inky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyLeft = Resources.Load("OutFit/Ghosts/Beard/Inky/Anim/inky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyRight = Resources.Load("OutFit/Ghosts/Beard/Inky/Anim/inky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkySprite = Resources.Load("OutFit/Ghosts/Beard/Inky/inky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.ClydeUp = Resources.Load("OutFit/Ghosts/Beard/Clyde/Anim/clyde_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeDown = Resources.Load("OutFit/Ghosts/Beard/Clyde/Anim/clyde_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeLeft = Resources.Load("OutFit/Ghosts/Beard/Clyde/Anim/clyde_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeRight = Resources.Load("OutFit/Ghosts/Beard/Clyde/Anim/clyde_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeSprite = Resources.Load("OutFit/Ghosts/Beard/Clyde/clyde_left_1", typeof(Sprite)) as Sprite;

                    GameObject.Find("Blinky").GetComponent<Image>().sprite = OutFit.BlinkySprite;
                    GameObject.Find("Pinky").GetComponent<Image>().sprite = OutFit.PinkySprite;
                    GameObject.Find("Inky").GetComponent<Image>().sprite = OutFit.InkySprite;
                    GameObject.Find("Clyde").GetComponent<Image>().sprite = OutFit.ClydeSprite;

                    break;

                case 4:

                    OutFit.BlinkyUp = Resources.Load("OutFit/Ghosts/Kopat/Blinky/Anim/blinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyDown = Resources.Load("OutFit/Ghosts/Kopat/Blinky/Anim/blinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyLeft = Resources.Load("OutFit/Ghosts/Kopat/Blinky/Anim/blinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyRight = Resources.Load("OutFit/Ghosts/Kopat/Blinky/Anim/blinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkySprite = Resources.Load("OutFit/Ghosts/Kopat/Blinky/blinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.PinkyUp = Resources.Load("OutFit/Ghosts/Kopat/Pinky/Anim/pinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyDown = Resources.Load("OutFit/Ghosts/Kopat/Pinky/Anim/pinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyLeft = Resources.Load("OutFit/Ghosts/Kopat/Pinky/Anim/pinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyRight = Resources.Load("OutFit/Ghosts/Kopat/Pinky/Anim/pinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkySprite = Resources.Load("OutFit/Ghosts/Kopat/Pinky/pinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.InkyUp = Resources.Load("OutFit/Ghosts/Kopat/Inky/Anim/inky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyDown = Resources.Load("OutFit/Ghosts/Kopat/Inky/Anim/inky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyLeft = Resources.Load("OutFit/Ghosts/Kopat/Inky/Anim/inky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyRight = Resources.Load("OutFit/Ghosts/Kopat/Inky/Anim/inky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkySprite = Resources.Load("OutFit/Ghosts/Kopat/Inky/inky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.ClydeUp = Resources.Load("OutFit/Ghosts/Kopat/Clyde/Anim/clyde_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeDown = Resources.Load("OutFit/Ghosts/Kopat/Clyde/Anim/clyde_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeLeft = Resources.Load("OutFit/Ghosts/Kopat/Clyde/Anim/clyde_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeRight = Resources.Load("OutFit/Ghosts/Kopat/Clyde/Anim/clyde_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeSprite = Resources.Load("OutFit/Ghosts/Kopat/Clyde/clyde_left_1", typeof(Sprite)) as Sprite;

                    GameObject.Find("Blinky").GetComponent<Image>().sprite = OutFit.BlinkySprite;
                    GameObject.Find("Pinky").GetComponent<Image>().sprite = OutFit.PinkySprite;
                    GameObject.Find("Inky").GetComponent<Image>().sprite = OutFit.InkySprite;
                    GameObject.Find("Clyde").GetComponent<Image>().sprite = OutFit.ClydeSprite;

                    break;

                case 5:

                    OutFit.BlinkyUp = Resources.Load("OutFit/Ghosts/Mafia/Blinky/Anim/blinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyDown = Resources.Load("OutFit/Ghosts/Mafia/Blinky/Anim/blinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyLeft = Resources.Load("OutFit/Ghosts/Mafia/Blinky/Anim/blinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkyRight = Resources.Load("OutFit/Ghosts/Mafia/Blinky/Anim/blinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.BlinkySprite = Resources.Load("OutFit/Ghosts/Mafia/Blinky/blinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.PinkyUp = Resources.Load("OutFit/Ghosts/Mafia/Pinky/Anim/pinky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyDown = Resources.Load("OutFit/Ghosts/Mafia/Pinky/Anim/pinky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyLeft = Resources.Load("OutFit/Ghosts/Mafia/Pinky/Anim/pinky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkyRight = Resources.Load("OutFit/Ghosts/Mafia/Pinky/Anim/pinky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.PinkySprite = Resources.Load("OutFit/Ghosts/Mafia/Pinky/pinky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.InkyUp = Resources.Load("OutFit/Ghosts/Mafia/Inky/Anim/inky_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyDown = Resources.Load("OutFit/Ghosts/Mafia/Inky/Anim/inky_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyLeft = Resources.Load("OutFit/Ghosts/Mafia/Inky/Anim/inky_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkyRight = Resources.Load("OutFit/Ghosts/Mafia/Inky/Anim/inky_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.InkySprite = Resources.Load("OutFit/Ghosts/Mafia/Inky/inky_left_1", typeof(Sprite)) as Sprite;

                    OutFit.ClydeUp = Resources.Load("OutFit/Ghosts/Mafia/Clyde/Anim/clyde_up_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeDown = Resources.Load("OutFit/Ghosts/Mafia/Clyde/Anim/clyde_down_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeLeft = Resources.Load("OutFit/Ghosts/Mafia/Clyde/Anim/clyde_left_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeRight = Resources.Load("OutFit/Ghosts/Mafia/Clyde/Anim/clyde_right_1", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
                    OutFit.ClydeSprite = Resources.Load("OutFit/Ghosts/Mafia/Clyde/clyde_left_1", typeof(Sprite)) as Sprite;

                    GameObject.Find("Blinky").GetComponent<Image>().sprite = OutFit.BlinkySprite;
                    GameObject.Find("Pinky").GetComponent<Image>().sprite = OutFit.PinkySprite;
                    GameObject.Find("Inky").GetComponent<Image>().sprite = OutFit.InkySprite;
                    GameObject.Find("Clyde").GetComponent<Image>().sprite = OutFit.ClydeSprite;

                    break;

            }
        }
        catch
        {

        }
    }

    public void SwitchPacManLeft()
    {

        if(numberPacMan == 1)
        {
            numberPacMan = 5;
        }
        else
        {
            numberPacMan--;
        }

    }

    public void SwitchPacManRight()
    {

        if (numberPacMan == 5)
        {
            numberPacMan = 1;
        }
        else
        {
            numberPacMan++;
        }
    }

    public void SwitchPacManTwoLeft()
    {

        if (numberPacMan2 == 1)
        {
            numberPacMan2 = 5;
        }
        else
        {
            numberPacMan2--;
        }

    }

    public void SwitchPacManTwoRight()
    {

        if (numberPacMan2 == 5)
        {
            numberPacMan2 = 1;
        }
        else
        {
            numberPacMan2++;
        }
    }

    public void SwitchGhostLeft()
    {
        if(numberGhost == 1)
        {
            numberGhost = 5;
        }
        else
        {
            numberGhost--;
        }
    }

    public void SwitchGhostRight()
    {
        if (numberGhost == 5)
        {
            numberGhost = 1;
        }
        else
        {
            numberGhost++;
        }
    }

    public void Exit()
    {
        GameMenu.isOnePlayerGame = true;
        SceneManager.LoadScene("Menu");

    }

    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }
}
