using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerSymbol playerSymbol;
    GameGrid gameGrid;
    bool gameRestarting = false;
    float restartTimer = 5f;
    [SerializeField]
    Text winnerText;

    void Start()
    {
        playerSymbol = PlayerSymbol.X;
        gameGrid = FindObjectOfType<GameGrid>();
    }

    private void Update()
    {
        RestartTimerCounter();
    }

    public PlayerSymbol GetPlayerSymbol()
    {
        return playerSymbol;
    }

    void PlayerSymbolFlip()
    {
        if (playerSymbol == PlayerSymbol.X)
        {
            playerSymbol = PlayerSymbol.O;
        }
        else
        {
            playerSymbol = PlayerSymbol.X;
        }
    }

    void CheckGameWinner()
    {
        PlayerSymbol winner = gameGrid.CheckGameWinner();


        if (winner != PlayerSymbol.Void)
        {
            Win(winner);
        }
    }

    void Win(PlayerSymbol playerSymbol)
    {
        winnerText.text = (playerSymbol + " is a Winner!");
        RestartGame();
    }

    void RestartTimerCounter()
    {
        if (gameRestarting)
        {
            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0)
            {
                gameRestarting = false;
                gameGrid.FillGrid();
                restartTimer = 5f;
                winnerText.text = "";
            }
        }
    }

    void RestartGame()
    {
        gameRestarting = true;
    }

    public void Turn()
    {
        PlayerSymbolFlip();
        CheckGameWinner();
    }

    public bool IsGameRestarting()
    {
        return gameRestarting;
    }
}
