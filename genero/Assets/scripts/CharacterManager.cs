using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] float timeForVersion1;
    [SerializeField] float timeForVersion2;

    public Animation character_anim;
    public Animation mouth_anim;
    public float minSensibilityValue = .001f;
    bool isTalking;
    AudioSpectrum audioSpectrum;

    public int versionID;

    public GameObject splash;
    public GameObject uiTexts;

    void Start()
    {
        audioSpectrum = Data.Instance.audioSpectrum;
        Reset();
        Shutup();
        LoopTalk();
    }
    private void Init()
    {
        StopAllCoroutines();
        StartCoroutine(TalkingC());
        Events.PlaySound("voices", "voices/version" + versionID, false);
        splash.SetActive(false);
        uiTexts.SetActive(true);
        uiTexts.GetComponent<Animation>().Play("version" + versionID);
    }
    IEnumerator TalkingC()
    {
        float delay = timeForVersion1;
        if (versionID == 2)
            delay = timeForVersion2;

        print("anima hasta: " + delay);

        yield return new WaitForSeconds(delay);

        print("Reset");
        Reset();
    }
    public void Reset()
    {
        StopAllCoroutines();
        splash.SetActive(true);
        uiTexts.SetActive(false);
        Events.PlaySound("voices", "", false);
    }
    public void Shutup()
    {
        mouth_anim.Play("shutup");
        isTalking = false;
    }
    public void Talk()
    {
        if (!isTalking)
            mouth_anim.Play("talk");
        isTalking = true;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!isTalking)
            {
                Init();
            }
            else
            {
                Reset();
            }
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
