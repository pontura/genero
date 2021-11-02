using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Animation character_anim;
    public Animation mouth_anim;
    public float minSensibilityValue = .001f;
    bool isTalking;
    AudioSpectrum audioSpectrum;

    void Start()
    {
        audioSpectrum = Data.Instance.audioSpectrum;
        Shutup();
        LoopTalk();
    }
    public void Shutup()
    {
        print("_________Shutup");
        mouth_anim.Play("shutup");
        isTalking = false;
    }
    public void Talk()
    {
        print("Talk");
        if (!isTalking)
            mouth_anim.Play("talk");
        isTalking = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!isTalking)
                Events.PlaySound("voices", "voices/test", false);
            else
                Events.PlaySound("voices", "", false); 
        }
    }
    void LoopTalk()
    {
        if (audioSpectrum.result > minSensibilityValue)
            Talk();
        else if (isTalking)
            Shutup();

        Invoke("LoopTalk", 0.1f);
    }
}
