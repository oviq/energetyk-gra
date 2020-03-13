﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// pozwala kontrolowac jednostki gracza, wydawac im polecenia itd
public class PlayerController : MonoBehaviour
{
    public GameObject boy;
    public GameObject gal;

    private HashSet<GameObject> selected;

    public Camera cam;

    public GameObject znacznikPrefab;
    public GameObject znacznikPostac;
    public GameObject znacznikPrzeciwnik;
    List<GameObject> znacznikInstances = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        selected = new HashSet<GameObject>();

        //selected.Add(boy);
        //selected.Add(gal);
    }

    // Update is called once per frame
    void Update()
    {
        // akcja przy kliknieciu prawym przyciskiem
        if (Input.GetMouseButtonDown(1))
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

        // akcja przy kliknieciu lewym przyciskiem
        // !UWAGA! kod-spaghetti
        if (Input.GetMouseButtonDown(0))
        {
            GameObject target = HelperFunctions.GetWorldObject(Input.mousePosition);
            if (target != null)
            {
                // jezeli target jest jednostka
                if (target.GetComponent<Unit>() != null)
                {
                    // jezeli target nalezy do gracza
                    if (target.GetComponent<Unit>().canBeControlledByPlayer)
                    {
                        // jezeli target jest juz zaznaczony
                        if (selected.Contains(target))
                        {
                            RemoveFromSelected(target);
                        }
                        // jezeli target nie jest zaznaczony
                        else
                        {
                            AddToSelected(target);
                        }
                    } 
                    // jezeli nie nalezy do gracza
                    else
                    {

                    }
                }

            }
        }
    }


    // funkcje do zaznaczania i odznaczania postaci
    void AddToSelected(GameObject target)
    {
        selected.Add(target);

        Transform targetZnacznikPosition = target.transform.Find("znacznikPosition").transform;
        Instantiate(znacznikPostac, targetZnacznikPosition);
    }

    void RemoveFromSelected(GameObject target)
    {
        selected.Remove(target);

        GameObject znacznik = target.transform.Find("znacznikPosition").transform.Find("zaznaczona postac(Clone)").transform.gameObject;
        Destroy(znacznik);
    }
}


