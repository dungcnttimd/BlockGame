using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemIndex : MonoBehaviour
{
    // [SerializeField] private PlayerStatus PlayerState;
    // [SerializeField] private List<GameObject> Gem;

    public int i_GemIndex = -1;
    public int i_GemValue = -1;
    public int i_index = -1;

    void Awake(){
        i_GemIndex = -1;
        i_GemValue = -1;
        i_index = -1;
    }
    // Start is called before the first frame update
    void Start()
    {
        int val = (int)Random.Range(minInclusive: 1f, 10f);
        if(val == 10){
            val -= 1;
        }
        i_GemValue = val;
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
    public void OnSelectClick(){
        Debug.Log(message: i_GemIndex);
        Debug.Log(message: i_GemValue);
        Debug.Log(message: i_index);
    } 
}
