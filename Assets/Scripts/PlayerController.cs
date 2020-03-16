using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !STEROWANIE!
// LPM - zaznaczenie
// PPM - chodzenie
// spacja - pauza
// d - detarget
// a - atak

// pozwala kontrolowac jednostki gracza, wydawac im polecenia itd
public class PlayerController : MonoBehaviour
{
    public GameObject boy;
    public GameObject gal;

    private HashSet<GameObject> selected;

    public GameObject znacznikPrefab;
    public GameObject znacznikPostac;
    public GameObject znacznikPrzeciwnik;
    List<GameObject> znacznikInstances = new List<GameObject>();
    List<GameObject> znacznikiNaPrzeciwnikach = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        selected = new HashSet<GameObject>();
        znacznikInstances = new List<GameObject>();
        znacznikiNaPrzeciwnikach = new List<GameObject>();

        InvokeRepeating("UpdateTargetsZnaczniki", 0f, 0.2f);

        isPaused = false;
    }

    void Update()
    {
        // SYSTEM ZNACZNIKOW MA BUGA, ZNACZNIKI MOGA BYC
        // USUWANE DOPIERO KIEDY POSTAC DOJDZIE DO CELU

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
                Vector2 znacznikPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector2((2-i)-1.5f, 0);

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
                            UpdateTargetsZnaczniki();
                        }
                        // jezeli target nie jest zaznaczony
                        else
                        {
                            AddToSelected(target);
                            UpdateTargetsZnaczniki();
                        }
                    } 
                    // jezeli nie nalezy do gracza
                    else
                    {
                        foreach (GameObject x in selected)
                        { 
                            x.GetComponent<Unit>().currentTarget = target.GetComponent<Unit>();
                            UpdateTargetsZnaczniki();
                        }
                    }
                }

            }
        }

        //atak wszystkich zaznaczonych jednostek jest na spacji
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (GameObject x in selected)
            {
                x.GetComponent<Unit>().Attack();
            }
        }

        // pauza
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }

        // detargetowanie
        if (Input.GetKeyDown(KeyCode.D))
        {
            DetargetSelected();
        }
    }


    // funkcje do zaznaczania i odznaczania postaci
    void AddToSelected(GameObject target)
    {
        selected.Add(target);

        target.GetComponent<ZnacznikController>().AddZnacznik();
    }

    void RemoveFromSelected(GameObject target)
    {
        selected.Remove(target);

        target.GetComponent<ZnacznikController>().DestroyZnacznik();
    }

    // aktualizuje znaczniki przeciwnikow
    void UpdateTargetsZnaczniki()
    {
        // usuwa dodane znaczniki na przeciwnikach
        foreach (GameObject x in znacznikiNaPrzeciwnikach)
        {
            Destroy(x, 0f);
        }
        znacznikiNaPrzeciwnikach.Clear();

        // dodaje znaczniki
        foreach (GameObject x in selected)
        {
            if (x.GetComponent<Unit>().currentTarget!=null)
            {
                znacznikiNaPrzeciwnikach.Add(x.GetComponent<Unit>().currentTarget.GetComponent<ZnacznikController>().AddZnacznik());
            }
        }
    }
    
    // detargetuje zaznaczone jednostki
    void DetargetSelected()
    {
        foreach (GameObject x in selected)
        {
            x.GetComponent<Unit>().currentTarget.GetComponent<ZnacznikController>().DestroyZnacznik();
            x.GetComponent<Unit>().currentTarget = null;
        }

        UpdateTargetsZnaczniki();
    }

    // Rzeczy dotyczace pauzowania

    bool isPaused;
    GameObject pauseText;
    public GameObject pauseTextPrefab;

    void Pause()
    {
        Time.timeScale = 0f;

        pauseText = Instantiate(pauseTextPrefab);

        isPaused = true;
    }
    

    void Unpause()
    {
        Time.timeScale = 1f;

        Destroy(pauseText);

        isPaused = false;
    }
}
