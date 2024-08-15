using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class TextFollowTalkBalloon : MonoBehaviour
{
    public Transform target;
    public Text uiText;
    public Vector3 offset;
    public bool isText = false;
    public int TextStory = 0;
    private string DisplayToText;
    private GameObject Player;
    private new GameObject camera;
    private GameObject NPC;
    void Start(){
        Player = GameObject.Find("Player_idel-Sheet_0");
        camera = GameObject.Find("Main Camera");
        NPC = GameObject.Find("TalkBalloon");
    }
    void Update()
    {
        if (target != null && uiText != null)
        {
            if(!isText){
                DisplayToText = "";
                uiText.DOText(DisplayToText, 0.01f);
                if(TextStory == 0){
                    DisplayToText = "오 용사여!\n이곳에 온걸\n환영하네!";
                    uiText.DOText(DisplayToText, 1.2f).SetEase(Ease.Linear);
                }
                if(TextStory == 1){
                    DisplayToText = "자네\n공주를 구하러\n가는 길이지?";
                    uiText.DOText(DisplayToText, 1.2f).SetEase(Ease.Linear);
                }
                if(TextStory == 2){
                    DisplayToText = "이 앞에는\n몬스터가 많이\n있다네.";
                    uiText.DOText(DisplayToText, 1.2f).SetEase(Ease.Linear);
                }
                if(TextStory == 3){
                    DisplayToText = "꼭 몬스터를\n전부 잡고\n움직이게나.";
                    uiText.DOText(DisplayToText, 1.2f).SetEase(Ease.Linear);
                }
                if(TextStory == 4){
                    DisplayToText = "반드시 공주를\n구해오게!";
                    uiText.DOText(DisplayToText, 1.2f).SetEase(Ease.Linear);
                }
                isText = true;
            }
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
            uiText.transform.position = screenPos;
        }
        else{

        }
        if(Input.GetKeyDown(KeyCode.F)){
            TextStory++;
            isText = false;
        }
        if(TextStory > 4){
            uiText.text = "";
            uiText.DOText("", 0.1f);
            End();
        }
    }
    void End(){
        uiText.text = "";
        uiText.DOText("", 0.1f);
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<AttackKey>().enabled = true;
        camera.GetComponent<CameraToObject>().CameraReturn();
        NPC.GetComponent<Animator>().SetBool("idle", false);
        Destroy(uiText.gameObject, 0.5f);
        Destroy(NPC, 0.5f);
    }
}
