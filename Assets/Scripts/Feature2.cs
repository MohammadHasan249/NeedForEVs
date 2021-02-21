using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Feature2 : MonoBehaviour
{
    private int stage = 0;
    public GameObject pointer;
    public GameObject back;
    public GameObject next;
    public GameObject panel;
    public GameObject minibox;
    public GameObject[] textObjects;
    void Start()
    {
        pointer.SetActive(false);
        back.SetActive(true);
        next.SetActive(true);

        back.GetComponent<Button>().onClick.AddListener(BackButtonClicked);
        next.GetComponent<Button>().onClick.AddListener(NextButtonClicked);

        panel.SetActive(true);
        minibox.SetActive(true);
        foreach(GameObject textObject in textObjects){
            textObject.SetActive(false);
        }
        textObjects[0].SetActive(true);
    }

    void NextButtonClicked(){
        switch (stage)
        {
            case 0:
                stage = 1;
                textObjects[0].SetActive(false);
                textObjects[1].SetActive(true);
                break;
            case 1:
                stage = 2;
                textObjects[1].SetActive(false);
                // mini box and panel disable
                panel.SetActive(false);
                minibox.SetActive(false);
                next.SetActive(false);
                pointer.SetActive(true);
                break;
            case 2:
                // Do nothing
                break;
            default:
                // Incorrect stage value, set stage value back to 0
                stage = 0;
                break;
        }
    }

    void BackButtonClicked(){
        switch (stage)
        {
            case 0:
                // Go to previous scene
                // TODO: implement this!
                SceneManager.LoadScene("SampleScene");
                break;
            case 1:
                stage = 0;
                textObjects[1].SetActive(false);
                textObjects[0].SetActive(true);
                break;
            case 2:
                stage = 1;
                pointer.SetActive(false);
                textObjects[1].SetActive(true);
                panel.SetActive(true);
                minibox.SetActive(true);
                next.SetActive(true);
                break;
            default:
                // Incorrect stage value, set stage value back to 0
                stage = 0;
                break;
        }
    }
}
