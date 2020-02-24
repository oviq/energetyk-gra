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
    List<GameObject> znacznikInstances = new List<GameObject>();

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
            // usuwa poprzednie znaczniki jesli takie sa
            if (znacznikInstances.Count!=0)
            {
                foreach(GameObject x in znacznikInstances)
                {
                    Destroy(x, 0f);
                }
                znacznikInstances.Clear();
            }

            // spawnuje i ustawia znaczniki jako cele skryptu wyszukujacego sciezki
            int i = 0;
            foreach(GameObject x in selected)
            {
                // tu powinna byc jakas dobrze napisana funkcja ale na razie musi wystarzyc
                Vector2 znacznikPosition = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition) + new Vector2((2-i)-1.5f, 0);

                // dodaje znaczniki
                znacznikInstances.Add(Instantiate(znacznikPrefab, znacznikPosition, Quaternion.identity));
                x.GetComponent<CharacterPathfinding>().SetTarget(znacznikInstances[i].transform);

                i++;
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


