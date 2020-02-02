using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10,14)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] bool gameOver;

    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
}
