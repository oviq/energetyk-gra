using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// klasa-menedżer znacznikow pod postaciami
// !UWAGA!
// obiekt musi posiadac obiekt o nazwie 'znacznikPosition'
public class ZnacznikController : MonoBehaviour
{
    public GameObject defaultZnacznikPrefab;

    private Transform znacznikPosition;
    private GameObject znacznik;

    void Start()
    {
        znacznikPosition = gameObject.transform.Find("znacznikPosition");
    }

    // spawn domyslnego znacznika
    public GameObject AddZnacznik()
    {
        znacznik = Instantiate(defaultZnacznikPrefab, znacznikPosition);
        return znacznik;
    }

    // spawn customowego znacznika
    public GameObject AddZnacznik(GameObject _znacznik)
    {
        znacznik = Instantiate(_znacznik, znacznikPosition);
        return znacznik;
    }

    // usuwanie znacznika
    public void DestroyZnacznik()
    {
        Destroy(znacznik);
    }
}
