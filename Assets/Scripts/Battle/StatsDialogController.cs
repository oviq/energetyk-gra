using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDialogController : MonoBehaviour
{
    public Text id;
    public Text hp_text;
    public int max_hp;
    public int hp;

    public GameObject unit;

    public BattleManager battleManager;

    // setup that makes hp equal to max_hp
    public void Setup(string _name, int _max_hp)
    {
        gameObject.name = "Dialog_" + _name;
        id.text = _name;
        max_hp = _max_hp;
        hp = _max_hp;
    }
    
    // way better setup
    public void Setup(string _name, int _max_hp, int _hp)
    {
        gameObject.name = "Dialog_" + _name;
        id.text = _name;
        max_hp = _max_hp;
        hp = _hp;
    }

    void Update()
    {
        hp_text.text = "HP: " + hp + "/" + max_hp;

        hp = unit.GetComponent<Unit>().hp;

    }

}
