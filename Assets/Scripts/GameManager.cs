using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public Text round_text;
    public GameObject victoryUI;

    public WordManager wordManager;
    public InputManager inputManager;

    private int num_round = 1;

    private void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        wordManager.GenerateDictionary();
        Round(num_round);
    }

    void Round(int i)
    {
        round_text.text = i.ToString();

        wordManager.GenerateWord();
        wordManager.PrintWord();

        inputManager.GenerateUserInput(wordManager.answer_list);
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.UpdateUserInput();

        if (inputManager.isCorrect)
        {
            if (wordManager.dictionary.Count == 0)
            {
                Victory();
            }
            else
            {
                inputManager.isCorrect = false;
                Round(++num_round);
            }
        }
    }

    void Victory()
    {
        victoryUI.SetActive(true);
    }
}
