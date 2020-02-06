using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour
{
    public bool isActive = false;
    public BattleManager battleManager;
    public Unit unit;
    public Unit target;
    public TurnState state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        { 
            if (state == TurnState.CHOOSE_ACTION)
            {

            }

            if (state == TurnState.ANIMATION)
            {

            }

            // skip turn or end, idk
            if (Input.GetKeyDown(KeyCode.Space) || state == TurnState.END)
            {
                target.TakeDamage(20);

                // end turn
                isActive = false;
                battleManager.NextState();
            }
        }
    }

    public void NextState()
    {
        state++;
    }
}
