using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemIndex : MonoBehaviour
{
    [SerializeField] private PlayerStatus PlayerState;
    // [SerializeField] private List<GameObject> Gem;

    public int i_GemIndex = -1;
    public int i_GemValue = -1;
    public int i_index = -1;

    void Awake(){
        int val = (int)Random.Range(minInclusive: 1f, 7f);
        if(val == 8){
            val -= 1;
        }
        i_GemValue = val;
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void setIndex(int iIndex){
        i_GemIndex = iIndex;
    }
    public void setValue(int iVal){
        i_GemValue = iVal;
    }
    public int getIndex(){
        return i_GemIndex;
    }
    public int getValue(){
        return i_GemValue;
    }
    public void setID(int id){
        i_index = id;
    }
    public void OnSelectClick(){
        // Debug.Log(message: i_GemIndex);
        // Debug.Log(message: i_GemValue);
        // Debug.Log(message: i_index);

        for(int i = 0; i < PlayerState.i_SizeTotal; i += 1){
            PlayerState.Set_ID_All(i_GemIndex);
        }
        PlayerState.b_GemSelected = true;
    } 
}
