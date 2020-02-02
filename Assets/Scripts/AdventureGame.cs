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
        gameOver = state.GetGameOver();

        if (gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            ResetGame();
        }
        
        if ((Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) && !gameOver)
        {
            state = nextStates[0];
            UpdateState();
        }
        else if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && nextStates[1] && !gameOver)
        {
            state = nextStates[1];
            UpdateState();
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
