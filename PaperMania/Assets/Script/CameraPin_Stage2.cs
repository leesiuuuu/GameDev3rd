using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

public class CameraPin_Stage2 : MonoBehaviour
{
    private bool Cameramove;
    public GameObject Ray;
    public GameObject Camera;
    public GameObject Enemy;
    public GameObject Hunter;
    public List<GameObject> EnemyList = new List<GameObject>();
    public List<GameObject> HunterList = new List<GameObject>();
    private float Addnum;
    private float Addnum2;
    private int Faze = 1;
    private bool isSpawn = false;
    private bool Faze1 = true;
    public bool isPinned = false;
    public bool isEnd = false;
    void Start()
    {
        gameObject.GetComponent<CamerWindowPin>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cameramove = Ray.GetComponent<Raycast>().Come;
        Camera camera = Camera.GetComponent<Camera>();
        if(Cameramove){
            Invoke("SpawnEnemy", 0.6f);
            DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, 13f, 0.8f);
            isPinned = true;
            Camera.GetComponent<SmoothCameraFollow>().enabled = false;
            gameObject.GetComponent<CamerWindowPin>().enabled = true;
            Camera.transform.DOMove(this.transform.position, 0.8f, false);
            for(int i = EnemyList.Count -1; i >= 0; i--){
                if(EnemyList[i] == null || !EnemyList[i].activeInHierarchy){
                    EnemyList.RemoveAt(i);
                }
            }
            for(int i = HunterList.Count -1; i >= 0; i--){
                if(HunterList[i] == null || !HunterList[i].activeInHierarchy){
                    HunterList.RemoveAt(i);
                }
            }
            if(EnemyList.Count == 0 && Faze == 1 && isSpawn){
                DelayMob();
            }
            else if(EnemyList.Count == 0 && Faze == 2){
                DelayMob();
            }
            else if(HunterList.Count == 2 && Faze == 3){
                DelayMob();
            }
            if(!Faze1 && Faze == 2){
                Addnum = 0;
                for(int i = 1; i <= 4; i++){
                    GameObject Clone = Instantiate(Enemy);
                    Clone.name = "Enemy" + i;
                    Clone.GetComponent<CameraWindowPin_Slime>().enabled = true;
                    Clone.GetComponent<EnemyMovement>().Range = 35;
                    Clone.GetComponent<EnemyMovement>().Speed = 3.5f;
                    if(i == 1 || i == 2){
                        Clone.transform.localScale = new Vector3(-1.58f, 1.58f, 1.58f);
                        Clone.transform.position = new Vector3(-62.1f + Addnum, -1.3f, 19f);
                        Addnum += 6;
                    }
                    else{
                        if(i == 3){
                            Addnum = 0;
                        }
                        Clone.transform.position = new Vector3(-36.4f + Addnum, -1.3f, 19f);
                        Addnum += 6;
                    }
                    EnemyList.Add(Clone);
                }
                Faze1 = true;
            }
            if(!Faze1 && Faze == 3){
                Addnum2 = 0;
                for(int i = 2; i < 4; i++){
                    GameObject Clone = Instantiate(Hunter);
                    Clone.GetComponent<CamerWindowPin_Hunter>().enabled = true;
                    Clone.name = "Hunter" + i;
                    Clone.GetComponent<Hunter>().HP = 30;
                    if(i == 2){
                        Clone.transform.localScale = new Vector3(-1.18f, 1.18f, 1.18f);
                    }
                    Clone.transform.position = new Vector3(-59.3f + Addnum2, -0.54f, 19f);
                    Addnum2 += 28;
                    HunterList.Add(Clone);
                }
                Faze1 = true;
            }
            if(!Faze1 && Faze == 4){
                Destroy(GameObject.Find("Ground_ForHunter"), 0.8f);
                Destroy(GameObject.Find("Ground_ForHunter (1)"), 0.8f);
                for(int i = 0; i < HunterList.Count; i++){
                    HunterList[i].GetComponent<CamerWindowPin_Hunter>().enabled = true;
                }
                Faze1 = true;
            }
            if(EnemyList.Count == 0 && HunterList.Count == 0 && isSpawn){
                Debug.Log("Enemy is None!");
                isEnd = true;
                Camera.GetComponent<SmoothCameraFollow>().enabled = true;
                GetComponent<CamerWindowPin>().enabled = false;
                GetComponent<CameraPin_Stage2>().enabled = false;
                Ray.GetComponent<Raycast>().Come = false;
                Destroy(GameObject.Find("Ray"));
                DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, 5.65f, 0.8f).SetDelay(0.7f);
            }
        }
    }
    void DelayMob(){
        Faze++;
        Faze1 = false;
        return;
    }
    void SpawnEnemy(){
        if(!isSpawn){
            for(int i = 1; i <= 4; i++){
                GameObject Clone = Instantiate(Enemy);
                Clone.name = "Enemy" + i;
                Clone.GetComponent<CameraWindowPin_Slime>().enabled = true;
                Clone.GetComponent<EnemyMovement>().Range = 25;
                Clone.GetComponent<EnemyMovement>().Speed = 2.5f;
                if(i == 1 || i == 2){
                    Clone.transform.localScale = new Vector3(-1.58f, 1.58f, 1.58f);
                    Clone.transform.position = new Vector3(-65.1f + Addnum, -1.3f, 19f);
                    Addnum += 5;
                }
                else{
                    if(i == 3){
                        Addnum = 0;
                    }
                    Clone.transform.position = new Vector3(-33.4f + Addnum, -1.3f, 19f);
                    Addnum += 5;
                }
                EnemyList.Add(Clone);
            }
            Addnum = 0;
            for(int i = 0; i < 2; i++){
                GameObject Clone = Instantiate(Hunter);
                Clone.name = "Hunter" + i;
                if(i == 0){
                    Clone.transform.localScale = new Vector3(-1.18f, 1.18f, 1.18f);
                }
                Clone.GetComponent<CamerWindowPin_Hunter>().enabled = false;
                Clone.transform.position = new Vector3(-56.3f + Addnum2, 8.3f, 19f);
                Addnum2 += 20;
                HunterList.Add(Clone);
            }
            Addnum2 = 0;
            isSpawn = true;         
        }
    }
}
