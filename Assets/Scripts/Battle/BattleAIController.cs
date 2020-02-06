using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAIController : MonoBehaviour
{
    public bool isActive = false;
    public BattleManager battleManager;
    public Unit unit;
    public Unit target; //messy fuckin code ewwwww
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
            // skip turn
                isActive = false;

                target.TakeDamage(20);

                battleManager.NextState();
        }
    }
}
