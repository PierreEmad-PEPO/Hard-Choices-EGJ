using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> characters;
    [SerializeField]
    List<GameObject> specialLowMony;
    [SerializeField]
    GameObject specialLowPopulation;

    bool IsSpecialLowMony = true;

    static float elapsedTime = 0f;
    static float duration = 3f;
    static bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateCharacter();
    }

    // Update is called once per frame
    void Update()
    {

        elapsedTime += Time.deltaTime;

        if (isStart && elapsedTime >= duration)
        {
            InstantiateCharacter();
            isStart = false;
            elapsedTime = 0f;
        }

        if (characters.Count < 1 && isStart)
        {
            if (ResourcesManager.Money < 10 || ResourcesManager.Population < 10 || ResourcesManager.Happiness < 10)
                SceneManager.LoadScene("LoseOutro");
            else
                SceneManager.LoadScene("WinOutro");
        }
    }

    void InstantiateCharacter()
    {
        if (characters.Count > 0)
        {
            int random = Random.Range(0,2);
            int random2 = Random.Range(0,10);
            if (ResourcesManager.Money < 10 && IsSpecialLowMony)
            {
                if (random == 0) 
                {
                    RoyalAdvisor.isSpecialLowMony = true;
                    Instantiate(specialLowMony[0]);
                }
                else
                {
                    RoyalGuard.isSpecialLowMony = true;
                    Instantiate(specialLowMony[1]);
                }
                IsSpecialLowMony = false;
            }
            else if (ResourcesManager.Population > 150 && specialLowPopulation != null)
            {
                RoyalAdvisor.isSpecialLowPopulation = true;
                Instantiate(specialLowPopulation);
                specialLowPopulation = null;
            }
            else
            {
                Instantiate(characters[0]);
                characters.RemoveAt(0);
            }
        }

    }


    public static void SpwanNewCharacter()
    {
        elapsedTime = 0;
        isStart = true;
    }
    
}
