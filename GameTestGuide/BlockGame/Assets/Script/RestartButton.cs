using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private GameObject bt_Restart;     //Global Object     //Global Object
    [SerializeField] private PlayerStatus PlayerState;
    void Awake(){
        PlayerState.b_Reset = false;
    }
    public void onClickResetButton(){
        PlayerState.b_Reset = !PlayerState.b_Reset;
        if(PlayerState.b_Reset){
            onResetState();
        }
    }
    private void onResetState(){

    }
}
