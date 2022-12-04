using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public bool b_Play_Pause = false;                     //true - game is playing       false - game is pausing
    public bool b_Mute = false;                           //true - game is muting        false - game have music
    public bool b_Reset = false;                          //true -  -->onResetClick() -> b_Reset = false    false - nothing, general play
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        // Debug.Log((int)Time.time);
        // if(((int)Time.time+1) % 5 == 0){
        //     Debug.Log("-------------------------");
        //     Debug.Log(((int)Time.time+1));
        //     b_Reset = true;
        // }
    }
}