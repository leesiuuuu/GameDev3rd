using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

public class CameraPin : MonoBehaviour
{
    private bool Cameramove;
    public GameObject Ray;
    public GameObject Camera;
    public GameObject Enemy;
    public List<GameObject> EnemyList = new List<GameObject>();
    private float Addnum;
    private bool SpawnEnemy = false;
    public bool isPinned = false;
    public bool isEnd = false;
    public bool StartBefore = false;
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
            Invoke("Spawn", 0.6f);
            DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, 8.5f, 0.8f);
            isPinned = true;
            Camera.GetComponent<SmoothCameraFollow>().enabled = false;
            gameObject.GetComponent<CamerWindowPin>().enabled = true;
            Camera.transform.DOMove(this.transform.position, 0.8f, false);
            for(int i = EnemyList.Count -1; i >= 0; i--){
                if(EnemyList[i] == null || !EnemyList[i].activeInHierarchy){
                    EnemyList.RemoveAt(i);
                }
            }
            if(EnemyList.Count == 0 && StartBefore){
                Debug.Log("Enemy is None!");
                isEnd = true;
                Camera.GetComponent<SmoothCameraFollow>().enabled = true;
                GetComponent<CamerWindowPin>().enabled = false;
                GetComponent<CameraPin>().enabled = false;
                Ray.GetComponent<Raycast>().Come = false;
                Destroy(GameObject.Find("Ray"));
                DOTween.To(() => camera.orthographicSize, x => camera.orthographicSize = x, 5.65f, 0.8f).SetDelay(0.7f);
            }
        }
    }
    void Spawn(){
        if(!SpawnEnemy){
            for(int i = 1; i <= 4; i++){
                GameObject Clone = Instantiate(Enemy);
                Clone.name = "Enemy" + i;
                Clone.transform.position = new Vector3(34f + Addnum, -2.03f, 19);
                Addnum += 5;
                EnemyList.Add(Clone);
            }
            for(int i = 0; i < EnemyList.Count; i++){
                if(!EnemyList[i].GetComponent<CameraWindowPin_Slime>().enabled)
                    EnemyList[i].GetComponent<CameraWindowPin_Slime>().enabled = true;
            }
            SpawnEnemy = true;
            StartBefore = true;
        }
    }
}
