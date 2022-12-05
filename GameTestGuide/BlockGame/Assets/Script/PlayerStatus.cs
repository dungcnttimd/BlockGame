using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public bool b_Play_Pause = false;                     //true - game is playing       false - game is pausing
    public bool b_Mute = false;                           //true - game is muting        false - game have music
    public bool b_Reset = false;                          //true -  -->onResetClick() -> b_Reset = false    false - nothing, general play
    
    [SerializeField] private int i_SizeH = 8;
    [SerializeField] private int i_SizeW = 8;
    public int i_SizeTotal = 0;

    public int iIndexSelected = -1;
    public int iNumValue = 9;
    public List<GameObject> gameobject_Gem;
    public List<GameObject> gameobject_BackgroundGem;

    public bool b_GemSelected = false;
    // Animator animator;
/*
    If player click <Pause button>  -> b_Play_Pause = true
    If player click <Mute button>  -> b_Mute = true
    If this game has finnish u must set -> b_Reset = true  -> player wil be click <Reset button> to continue






*/
    void Awake(){
        b_GemSelected = false;
        i_SizeTotal = i_SizeH * i_SizeW;

        for(int i = 0; i < i_SizeTotal; i += 1){
            gameobject_Gem[i].GetComponent<GemIndex>().i_GemIndex = i;
        }
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    public void Set_ID_All(int id){
        for(int i = 0; i < i_SizeTotal; i += 1){
            gameobject_Gem[i].GetComponent<GemIndex>().i_index = id;
        }
    }
    // Update is called once per frame
    void Update(){
        if(b_GemSelected == true){
            int val = -1;
            for(int i = 0; i < i_SizeTotal; i += 1){    
                if(val < gameobject_Gem[i].GetComponent<GemIndex>().i_index){
                    val = gameobject_Gem[i].GetComponent<GemIndex>().i_index;
                }
            }
            iIndexSelected = val;
            b_GemSelected = false;
            // Debug.Log(val);
            Debug.Log((val%8 + 1) + " - " +  (val/8 + 1) + " is inde");
        }
        // if((int)Time.time % 5 == 0){                                                                //done get selected index   
        //     for(int i = 0; i < i_SizeTotal; i += 1){                                                //gameobject_Gem[i].GetComponent<GemIndex>().i_index
        //         Debug.Log(gameobject_Gem[i].GetComponent<GemIndex>().i_index);      //b_GemSelected == true 
        //     }                                                                                       // =>> selected <INDEX> 
        // }
        
    }
}