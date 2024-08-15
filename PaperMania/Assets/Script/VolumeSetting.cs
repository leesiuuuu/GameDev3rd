using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeSetting : MonoBehaviour
{
    public Volume volume;
    private ChromaticAberration CA;
    private DepthOfField DF;
    public GameObject Player;
    private bool isAttacked = true;
    void Start()
    {
        if(volume.profile.TryGet<ChromaticAberration>(out CA)){
            CA.intensity.value = 0.0f;
        }
        else{
            Debug.LogWarning("CA 효과를 찾을수 없다!");
        }
        if(volume.profile.TryGet<DepthOfField>(out DF)){
            DF.focalLength.value = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacked){
            CA.intensity.value = 1;
            DF.focalLength.value = 110;
            if(CA.intensity.value >= 1){
                for(int i = 0; i < 10; i++){
                    Invoke("inteensity", 0.2f);
                }
                volume.GetComponent<VolumeSetting>().enabled = false;
            }
        }
    }
    void inteensity(){
        CA.intensity.value -= 0.1f;
        DF.focalLength.value -= 11;
    }
}
