using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private GameObject bt_MuteButton;     //Global Object     //Global Object
    [SerializeField] private List<Sprite> MuteImage;
    [SerializeField] private PlayerStatus PlayerState;

    // Start is called before the first frame update
    void Awake(){
        Image m_Image = bt_MuteButton.GetComponent<Image>();
        m_Image.sprite = MuteImage[1];
    }
    public void onClickMuteButton(){
        PlayerState.b_Mute = !PlayerState.b_Mute;
        
        Image m_Image = bt_MuteButton.GetComponent<Image>();
        if(PlayerState.b_Mute){
            m_Image.sprite = MuteImage[0];
            onMute();
        }else{
            m_Image.sprite = MuteImage[1];
            onNoMute();
        }
    }
    private void onMute(){

    }
    private void onNoMute(){

    }
}
