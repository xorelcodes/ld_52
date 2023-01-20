using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.COMMANDMODE;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState){
            case GameState.COMMANDMODE:
            CommandControls();
            break;
            
            case GameState.CONSTRUCTMODE:
            ConstructionControls();

            break;
            
            case GameState.SELLMODE:
            SellingControls();
            break;
            
        }
    }

    private void CommandControls(){

    }

    private void ConstructionControls(){

    }

    private void SellingControls(){

    }
}
