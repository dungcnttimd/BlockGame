using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPause : MonoBehaviour
{
    [SerializeField] private GameObject PlayButton;
    [SerializeField] private List<Sprite> PlayImage;
    [SerializeField] private PlayerStatus PlayerState;
    [SerializeField] private GameObject DarkMaskPlay;
    // Start is called before the first frame update
    void Awake(){
        DarkMaskPlay.SetActive(true);
        Image m_Image = PlayButton.GetComponent<Image>();
        m_Image.sprite = PlayImage[0];
    }
    public void onClickPlayButton(){
        PlayerState.b_Play_Pause = !PlayerState.b_Play_Pause;
        Image m_Image = PlayButton.GetComponent<Image>();
        if(PlayerState.b_Play_Pause){
            m_Image.sprite = PlayImage[1];
            DarkMaskPlay.SetActive(false);
        }else{
            m_Image.sprite = PlayImage[0];
            DarkMaskPlay.SetActive(true);
        }
    }
}