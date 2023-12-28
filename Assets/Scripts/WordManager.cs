using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public List<string> dictionary = new List<string>();
    public List<string> answer_list = new List<string>();
    
    private List<string> answer_randomized = new List<string>();
    private string answer;

    public Text text_answer_randomized;

    public void GenerateDictionary()
    {
        dictionary.Add("B,A,N,A,N,A");
        dictionary.Add("A,P,P,L,E");
        dictionary.Add("M,A,N,G,O");
        dictionary.Add("A,I,R,P,L,A,N,E");
        dictionary.Add("R,O,C,K,E,T");
        dictionary.Add("S,U,B,W,A,Y");
        dictionary.Add("M,O,N,K,E,Y");
        dictionary.Add("G,O,A,T");
        dictionary.Add("E,L,E,G,A,T,O,R");
        dictionary.Add("D,O,O,R");
        dictionary.Add("C,L,O,C,K");
        dictionary.Add("C,O,M,P,U,T,E,R");
    }

    public void GenerateWord()
    {
        answer = dictionary[Random.Range(0, dictionary.Count)];
        dictionary.Remove(answer);
        answer_list = answer.Split(',').ToList();
        Randomize();
    }

    private void Randomize()
    {
        answer_randomized = answer_list.ToList();
        for (int i = 0; i < answer_list.Count; i++)
        {
            answer_randomized = Swap(answer_randomized, Random.Range(0, answer_list.Count), Random.Range(0, answer_list.Count));
        }
    }

    private List<string> Swap(List<string> list, int i, int j)
    {
        string temp = list[i];
        list[i] = list[j];
        list[j] = temp;

        return list;
    }

    public void PrintWord()
    { 
        text_answer_randomized.text = string.Join(" ", answer_randomized);
    }
}
