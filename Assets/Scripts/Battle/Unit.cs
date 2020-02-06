using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    NONE,
    PLAYER,
    ENEMY
}

public class Unit : MonoBehaviour
{
    public int hp;
    public int max_hp;
    public string id;
    public Side side;

    // Start is called before the first frame update
    void Start()
    {
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Side _side)
    {
        side = _side;

        if(side == Side.ENEMY)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
    }
}
