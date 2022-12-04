using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private GameObject bt_Restart;     //Global Object     //Global Object
    [SerializeField] private PlayerStatus PlayerState;
    [SerializeField] private GameObject DarkMaskForResetButton;

    void Awake(){
        PlayerState.b_Reset = false;
        DarkMaskForResetButton.SetActive(false);
        bt_Restart.SetActive(false);
    }
    void update(){
        // if(PlayerState.b_Reset == true){
        //     Debug.Log("Reset button showed");
        //     bt_Restart.SetActive(true);
        //     DarkMaskForResetButton.SetActive(true);
        // }
    }
    public void onClickResetButton(){
        if(PlayerState.b_Reset){
            onResetState();
            PlayerState.b_Reset = false;
        }
    }
    private void onResetState(){

    }

}
