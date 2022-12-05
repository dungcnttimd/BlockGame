using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private PlayerStatus PlayerState;
    [SerializeField] private GameObject bt_Restart;     //Global Object     //Global Object
    [SerializeField] private GameObject DarkMaskForResetButton;

    void Awake(){
        PlayerState.b_Reset = false;
        DarkMaskForResetButton.SetActive(false);
    }
    void Update(){
        if(PlayerState.b_Reset == true){
            Debug.Log("-------------------------");
            Debug.Log(PlayerState.b_Reset);
            DarkMaskForResetButton.SetActive(true);
        }
    }
    public void onClickResetButton(){
        onResetState();
        PlayerState.b_Reset = false;
    }
    private void onResetState(){
        //Do somthing
        DarkMaskForResetButton.SetActive(false);
    }

}
