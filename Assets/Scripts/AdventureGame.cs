using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] bool gameOver = false;

    State state;
    State[] nextStates;
    
    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        nextStates = state.GetNextStates();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        gameOver = state.GetGameOver();
        for (int index = 0; index < nextStates.Length; index++)
        {
            if ((Input.GetKeyDown(KeyCode.Keypad1 + index) || Input.GetKeyDown(KeyCode.Alpha1 + index)) && !gameOver)
            {
                state = nextStates[index];
                UpdateState();
            }
        }
        
        if (gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            ResetGame();
        }
    }

    private void UpdateState()
    {
        textComponent.text = state.GetStateStory();
        nextStates = state.GetNextStates();
    }

    private void ResetGame()
    {
        state = startingState;
        UpdateState();
    }
}
