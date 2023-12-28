using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private List<string> answer_list = new List<string>();
    private List<string> user_input = new List<string>();

    public Text text_user_input;

    int cur_length = 0;
    
    public bool isCorrect = false;

    public void GenerateUserInput(List<string> list)
    {
        answer_list = list;
        user_input.Clear();
        cur_length = 0;
        foreach (string item in list)
        {
            user_input.Add("_");
        }
    }

    public void UpdateUserInput()
    {
        text_user_input.text = string.Join(" ", user_input);

        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (cur_length != 0)
                {
                    user_input.RemoveAt(cur_length - 1);
                    user_input.Add("_");
                    cur_length--;
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
                if (cur_length == answer_list.Count)
                {
                    CheckAnswer();
                }
                GenerateUserInput(answer_list);
            }
            else
            {
                if (cur_length != answer_list.Count)
                {
                    user_input[cur_length] = c.ToString().ToUpper();
                    cur_length++;
                }
            }
        }
    }

    public void CheckAnswer()
    {
        if(string.Join(" ", answer_list) == string.Join(" ", user_input))
        {
            isCorrect = true;
        } 
        else
        {
            GenerateUserInput(answer_list);    
        }
    }
}
