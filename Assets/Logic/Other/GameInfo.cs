using Assets.Audio.Scripts;
using Assets.Logic.Other;
using Assets.UI.Scripts.Menu;
using UnityEngine;

public static class GameInfo {

    #region Data

    private static GameObject p_player;
    public static GameObject Player {
        get {
            if (p_player == null) {
                p_player = GameObject.FindGameObjectWithTag("Player");
            }
            return p_player;
        }
    }

    private static GameObject p_cameraTarget;
    public static GameObject CameraTarget {
        get {
            if (p_cameraTarget == null) {
                p_cameraTarget = GameObject.FindGameObjectWithTag("CameraTarget");
            }
            return p_cameraTarget;
        }
    }

    private static GameObject p_pauseMenu;
    public static GameObject PauseMenu {
        get {
            if (p_pauseMenu == null)
                p_pauseMenu = GameObject.FindObjectOfType<PauseMenu>(true).gameObject;
            return p_pauseMenu;
        }
    }

    private static GameObject p_gameUI;
    public static GameObject GameUI {
        get {
            if (p_gameUI == null)
                p_gameUI = GameObject.FindObjectOfType<GameUI>(true).gameObject;
            return p_gameUI;
        }
    }

    private static EGameMode p_playingMode;
    public static EGameMode PlayingMode {
        get {
            return p_playingMode;
        }
    }

    private static bool p_isPlaying = true;
    public static bool IsPlaying {
        get {
            return p_playingMode is EGameMode.Playing && p_isPlaying;
        }
        set {
            p_isPlaying = value;
        }
    }

    public static bool IsViewMode {
        get {
            return p_playingMode is EGameMode.View;
        }
    }

    private static int p_score;
    public static int Score {
        get {
            return p_score;
        }
    }

    private static AudioManager p_audioManager;
    public static AudioManager AudioManager {
        get {
            if (p_audioManager is null)
                p_audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
            ;
            return p_audioManager;
        }
    }

    #endregion

    public static void SwitchVPMode() {
        p_playingMode = p_playingMode is EGameMode.View ? EGameMode.Playing : EGameMode.View;
    }


    public static void SetMode(EGameMode mode) {
        p_playingMode = mode;
    }

    public static void AddScore(int score) {
        p_score += score;
    }

    public static void SetScore(int score) {
        p_score = score;
    }

    public static void ClearScore() {
        p_score = 0;
    }
}
