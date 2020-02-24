using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject boy;
    public GameObject gal;

    [SerializeField] public HashSet<GameObject> selected;

    public Camera cam;

    public GameObject znacznikPrefab;
    GameObject znacznikInstance;

    // Start is called before the first frame update
    void Start()
    {
        selected = new HashSet<GameObject>();

        selected.Add(boy);
        selected.Add(gal);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        { 
            if (znacznikInstance!=null)
            {
                Destroy(znacznikInstance, 0f);
            }

            znacznikInstance = Instantiate(znacznikPrefab, (Vector2)cam.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

            foreach(GameObject x in selected)
            {
                x.GetComponent<CharacterPathfinding>().SetTarget(znacznikInstance.transform);
            }
        }

        /*/ trzeba to zaimplementowac ciutke inaczej
        if (Input.GetKeyDown(KeyCode.Space))
        {
            char_unit.Attack();
        }
        /*/
    }
}


