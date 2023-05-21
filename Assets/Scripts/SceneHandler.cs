using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Used to handle the load of new Scenes in the game and to configure the static default values.
/// </summary>
public static class SceneHandler
{
    public static void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public static void LoadLevelSelectScene(bool isFreeWorldMode)
    {
        LevelData.IsFreeWorldMode = isFreeWorldMode;
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    public static void LoadArcadeGameScene()
    {
        GUIHandler.IsEndGame = false;
        PauseControl.GameIsPaused = false;
        LevelData.IsFreeWorldMode = false;
        LevelData.IsArcadeMode = true;
        LevelData.Starts = new();
        LevelData.Ends = new();
        LevelData.defaultStart = null;
        LevelData.defaultEnd = null;
        LevelData.GamePieces = null;
        LevelData.BoardSize = 10;
        LevelData.TimeLimit = 30;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public static void LoadLevel(int levelNumber)
    {
        GUIHandler.IsEndGame = false;
        PauseControl.GameIsPaused = false;
        LevelData.IsArcadeMode = false;
        LevelData.LevelNumber = levelNumber;
        LevelData.Starts = new();
        LevelData.Ends = new();
        LevelData.defaultStart = null;
        LevelData.defaultEnd = null;
        LevelData.GamePieces = null;

        if (LevelData.IsFreeWorldMode)
            LevelData.lvlData = Resources.Load<TextAsset>("FreeWorldLevels/Level" + levelNumber.ToString())
                .text.Split(Environment.NewLine);
        else
            LevelData.lvlData = Resources.Load<TextAsset>("LevelSelectLevels/Level" + levelNumber.ToString())
                .text.Split(Environment.NewLine);

        LevelData.BoardSize = int.Parse(LevelData.lvlData[0]);
        LevelData.TimeLimit = int.Parse(LevelData.lvlData[1]);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
