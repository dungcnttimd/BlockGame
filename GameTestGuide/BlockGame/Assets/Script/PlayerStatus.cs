using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Windows;

//---------- THIS'S MAIN CODE ----------
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
    [SerializeField] private List<GameObject> GemPrefabs;
    private int i_NumOfGemPrefabs = 0;

    public bool b_GemSelected = false;
    public bool b_GemSelecting = false;

    /*
        b_GemSelected   -   false       b_GemSelected   -   true        b_GemSelected   -   true        b_GemSelected   -   false
        b_GemSelecting  -   false       b_GemSelecting  -   false       b_GemSelecting  -   true        b_GemSelecting  -   true
        _________________________       __________________________      __________________________      _________________________
        default status                  selecting status .............> selected block to swap          swaped - to default
    */

    // Animator animator;
    Animator[] gemZoom = new Animator[64];
    Animator[] gemBackgourndGradient = new Animator[64];
    float thistime;
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
        i_NumOfGemPrefabs = GemPrefabs.Count;
        // Debug.Log(i_NumOfGemPrefabs);

        foreach(GameObject gameObject in gameobject_Gem){
            gameObject.GetComponent<Image>().color = new Color32(255,255,255,0);
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(null);
        }
        
    }
    void initAnimationTrigger(){
        for(int i = 0; i < i_SizeTotal; i += 1){
            gemZoom[i].SetBool("Init", true);
        }
    }
    void initAnimationReturn(){
        for(int i = 0; i < i_SizeTotal; i += 1){
            gemZoom[i].SetBool("Init", false);
        }
    }
    void initAnimation(float currenttime){                              //funciton active when u set <currenttime> and u mustn't set <currenttime> again
        if(Time.time - currenttime > 1.5f){
            return;
        }
        if(Time.time - currenttime < 1f){
            initAnimationTrigger();
        }
        if(Time.time - currenttime >= 1f && Time.time - currenttime < 1.5f){
            initAnimationReturn();
        }
    }
    int randomValue(){
        int val = (int)Random.Range(minInclusive: 1f, 10f);
        if(val == 10){
            val -= 1;
        }
        return val;
    }
    // Start is called before the first frame update
    void Start(){
        thistime = Time.time;
        for(int i = 0; i < i_SizeTotal; i += 1){
            gemZoom[i] = gameobject_Gem[i].GetComponent<Animator>();
            gemBackgourndGradient[i] = gameobject_BackgroundGem[i].GetComponent<Animator>();
        }
        // Debug.Log("Load sprite");
        foreach(GameObject gameObject in gameobject_Gem){
            gameObject.GetComponent<Image>().color = new Color32(255,255,255,255);
            string pathResources = "Art/PicSelected/".ToString();
            pathResources += gameObject.GetComponent<GemIndex>().i_GemValue.ToString();
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(pathResources);
        }
    }

    public void Set_ID_All(int id){
        for(int i = 0; i < i_SizeTotal; i += 1){
            gameobject_Gem[i].GetComponent<GemIndex>().i_index = id;
        }
    }
    void SwapBlock(int i_IndexGemSelected, int i_IndexGem2Swap){
        gameobject_Gem[i_IndexGemSelected].GetComponent<GemIndex>().i_GemValue += gameobject_Gem[i_IndexGem2Swap].GetComponent<GemIndex>().i_GemValue;
        gameobject_Gem[i_IndexGem2Swap].GetComponent<GemIndex>().i_GemValue =   gameobject_Gem[i_IndexGemSelected].GetComponent<GemIndex>().i_GemValue - 
                                                                                        gameobject_Gem[i_IndexGem2Swap].GetComponent<GemIndex>().i_GemValue;
        gameobject_Gem[i_IndexGemSelected].GetComponent<GemIndex>().i_GemValue -= gameobject_Gem[i_IndexGem2Swap].GetComponent<GemIndex>().i_GemValue;
    }
    void arrayadd(List<int> lis, int val, int dir){
        lis.Add(val);
        lis.Add(dir);
    }
    List<int> CheckGemInit(){
        List<int> resolve = new List<int>();
        for(int x = 0; x < i_SizeTotal; x += 1){
            if(x % i_SizeW !=  i_SizeW - 1 && x % i_SizeW != i_SizeW - 2){
                if(gameobject_Gem[x].GetComponent<GemIndex>().i_GemValue == gameobject_Gem[x+1].GetComponent<GemIndex>().i_GemValue && gameobject_Gem[x].GetComponent<GemIndex>().i_GemValue == gameobject_Gem[x+2].GetComponent<GemIndex>().i_GemValue){
                    arrayadd(resolve, x, 1);        //Horizontal    - ngang
                }
            }
            if(x <= i_SizeTotal - i_SizeW - i_SizeW){
                if(gameobject_Gem[x].GetComponent<GemIndex>().i_GemValue == gameobject_Gem[x+i_SizeW].GetComponent<GemIndex>().i_GemValue && gameobject_Gem[x].GetComponent<GemIndex>().i_GemValue == gameobject_Gem[x+i_SizeW+i_SizeW].GetComponent<GemIndex>().i_GemValue){
                    arrayadd(resolve, x, 2);        //Veritical     - dọc
                }
            }
        }
        return resolve;
    }
    void afterBOOM(int indexforbom){
        for(; 0 <= indexforbom/i_SizeW;){
                // Debug.Log("Loop : " + indexforbom/i_SizeW);
                gameobject_Gem[indexforbom].GetComponent<Image>().color = new Color32(255,255,255,255);
                string pathResources = "Art/PicSelected/".ToString();
                if(indexforbom <= i_SizeW){
                    Debug.Log("-Random value-");
                    int val = (int)Random.Range(minInclusive: 1f, 10f);
                    if(val == 10){
                        val -= 1;
                    }
                    gameobject_Gem[indexforbom].GetComponent<GemIndex>().i_GemValue = val;
                    pathResources += gameobject_Gem[indexforbom].GetComponent<GemIndex>().i_GemValue.ToString();
                    gameobject_Gem[indexforbom].GetComponent<Image>().sprite = Resources.Load<Sprite>(pathResources);
                    // Debug.Log("Next value : " + gameobject_Gem[a].GetComponent<GemIndex>().i_GemValue);
                    break;
                }else{
                    gameobject_Gem[indexforbom].GetComponent<GemIndex>().i_GemValue = gameobject_Gem[indexforbom - i_SizeW].GetComponent<GemIndex>().i_GemValue;
                    pathResources += gameobject_Gem[indexforbom].GetComponent<GemIndex>().i_GemValue.ToString();
                    gameobject_Gem[indexforbom].GetComponent<Image>().sprite = Resources.Load<Sprite>(pathResources);
                    // Debug.Log("Next value : " + gameobject_Gem[a].GetComponent<GemIndex>().i_GemValue);
                }
                indexforbom -= i_SizeW;
            }
    }
    private void process(){
        foreach(Animator gameObject in gemZoom){
            gameObject.SetBool("Selected", false);
        }
        foreach(Animator gameObject in gemBackgourndGradient){
            gameObject.SetBool("Active", false);
        }
        
        int x = iIndexSelected % i_SizeW + 1;
        int y = iIndexSelected / i_SizeH + 1;
        if(b_GemSelected == true && b_GemSelecting == false){
            gemZoom[iIndexSelected].SetBool("Selected", true);
            if(y == 1){
                gemBackgourndGradient[iIndexSelected+i_SizeW].SetBool("Active", true);
            }
            if(y == i_SizeH){
                gemBackgourndGradient[iIndexSelected-i_SizeW].SetBool("Active", true);
            }
            if(y != 1 && y != i_SizeH){
                gemBackgourndGradient[iIndexSelected+i_SizeW].SetBool("Active", true);
                gemBackgourndGradient[iIndexSelected-i_SizeW].SetBool("Active", true);
            }
            if(x == 1){
                gemBackgourndGradient[iIndexSelected+1].SetBool("Active", true);
            }
            if(x == i_SizeW){
                gemBackgourndGradient[iIndexSelected-1].SetBool("Active", true);
            }
            if(x != 1 && x != i_SizeW){
                gemBackgourndGradient[iIndexSelected+1].SetBool("Active", true);
                gemBackgourndGradient[iIndexSelected-1].SetBool("Active", true);
            }
        }
        gameobject_Gem[iIndexSelected].SetActive(false);
    }
    // Update is called once per frame
    
    void Update(){
        initAnimation(thistime);
        List<int> a = CheckGemInit(); 
        for(int i = 0; i < a.Count; i+= 2){
            Debug.Log(a[i] + " - " + a[i+1]);
            if(a[i+1] == 1){
                for(int j = 0; j < 3; j += 1){
                    afterBOOM(a[i]+j);
                }
            }else{
                for(int j = 0; j < 3; j += 1){
                    afterBOOM(a[i]+j*i_SizeW);
                }
            }
            a.Clear();
        }


        if(b_GemSelected == true){
            int val = -1;
            for(int i = 0; i < i_SizeTotal; i += 1){    
                if(val < gameobject_Gem[i].GetComponent<GemIndex>().i_index){
                    val = gameobject_Gem[i].GetComponent<GemIndex>().i_index;
                }
            }
            iIndexSelected = val;
            b_GemSelecting = false;
            process();
            b_GemSelected = false;
        }
        // if((int)Time.time % 5 == 0){                                                                //done get selected index   
        //     for(int i = 0; i < i_SizeTotal; i += 1){                                                //gameobject_Gem[i].GetComponent<GemIndex>().i_index
        //         Debug.Log(gameobject_Gem[i].GetComponent<GemIndex>().i_index);      //b_GemSelected == true 
        //     }                                                                                       // =>> selected <INDEX> 
        // }
    }
}