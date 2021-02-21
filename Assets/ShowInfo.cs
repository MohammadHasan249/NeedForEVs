using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowInfo : MonoBehaviour
{

    // [SerializeField] private GameObject canvas = null;
    // [SerializeField] private Camera camera = null;
    // [SerializeField] private GameObject[] objects = null;

    // public void OnMouseDown()
    // {
    //     foreach (GameObject obj in objects)
    //     {
    //         obj.SetActive(false);
    //     }
    //     canvas.SetActive(true);
    //     camera.transform.position = new Vector3(2.7f, 6.1f, -385f);
    //     camera.transform.rotation = Quaternion.identity;
    // }

    private int stage = 0;
    public GameObject next;
    public GameObject back;
    public GameObject[] texts;

    void Start(){

        back.GetComponent<Button>().onClick.AddListener(BackButtonClicked);
        next.GetComponent<Button>().onClick.AddListener(NextButtonClicked);

        for(int i = 0; i < 5; i++){
            texts[i].SetActive(true);
        }
        texts[4].SetActive(false);
        texts[5].SetActive(false);
    }

    void NextButtonClicked(){
        next.SetActive(false);
        for(int i = 1; i < 5; i++){
            texts[i].SetActive(false);
        }
        texts[4].SetActive(true);
        texts[5].SetActive(true);
        stage = 1;
    }

    void BackButtonClicked(){
        if(stage == 1){
            next.SetActive(true);
            for(int i = 1; i < 5; i++){
                texts[i].SetActive(true);
            }
            texts[4].SetActive(false);
            texts[5].SetActive(false);
            stage = 0;
        } else {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
