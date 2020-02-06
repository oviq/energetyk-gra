using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for controllers
public enum TurnState
{
    CHOOSE_ACTION,
    ANIMATION,
    END
}

// for battle manager (mainly)
public enum BattleState
{
    INIT,
    PLAYER_TURN,
    ENEMY_TURN,
    END
}

public class BattleManager : MonoBehaviour
{
    // to access ui
    public Canvas canvas;
    public GameObject pfDialog;
    private GameObject playerDialog;
    private GameObject enemyDialog;

    // to access units
    public Transform playerPlatform;
    public Transform enemyPlatform;
    public GameObject pfPlayer; 
    public GameObject pfEnemy;
    private GameObject player;
    private GameObject enemy;

    // to acces controllers
    public BattlePlayerController playerController;
    public BattleAIController aiController;

    // to convert game world positions to ui positions
    public Camera cam;

    // State
    public BattleState state;

    void Start()
    {
        // Set state to init
        state = BattleState.INIT;

        // Instantiate units and their dialogs
        player = Instantiate(pfPlayer, playerPlatform);
        player.GetComponent<Unit>().Setup(Side.PLAYER);
        playerDialog = Instantiate(pfDialog, cam.WorldToScreenPoint(playerPlatform.position) + new Vector3(0, 280, 0), Quaternion.identity, canvas.GetComponent<Transform>());
        playerDialog.GetComponent<StatsDialogController>().Setup("PLAYER", 100);
        playerDialog.GetComponent<StatsDialogController>().battleManager = this;
        playerDialog.GetComponent<StatsDialogController>().unit = player;
       
        enemy = Instantiate(pfEnemy, enemyPlatform);
        enemy.GetComponent<Unit>().Setup(Side.ENEMY);
        enemyDialog = Instantiate(pfDialog, cam.WorldToScreenPoint(enemyPlatform.position) + new Vector3(0, 280, 0), Quaternion.identity, canvas.GetComponent<Transform>());
        enemyDialog.GetComponent<StatsDialogController>().Setup("ENEMY", 100);
        enemyDialog.GetComponent<StatsDialogController>().battleManager = this;
        enemyDialog.GetComponent<StatsDialogController>().unit = enemy;

        // Set state to the next one
        NextState();

    }

    void Update()
    {
        
    }

    public void NextState()
    {
        // switch state
        switch (state)
        {
            case BattleState.INIT:
                state = BattleState.PLAYER_TURN;
                break;
            case BattleState.PLAYER_TURN:
                state = BattleState.ENEMY_TURN;
                break;
            case BattleState.ENEMY_TURN:
                state = BattleState.PLAYER_TURN;
                break;
            case BattleState.END:
                break;
            default:
                break;
        }

        // init state
        switch (state)
        {
            case BattleState.INIT:
                break;
            case BattleState.PLAYER_TURN:
                playerController.isActive = true;
                playerController.unit = player.GetComponent<Unit>();
                playerController.target = enemy.GetComponent<Unit>();
                playerController.state = TurnState.CHOOSE_ACTION;
                break;
            case BattleState.ENEMY_TURN:
                aiController.isActive = true;
                aiController.unit = enemy.GetComponent<Unit>();
                aiController.target = player.GetComponent<Unit>();
                aiController.state = TurnState.CHOOSE_ACTION;
                break;
            case BattleState.END:
                break;
            default:
                break;
        }

    }
}
