using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Feature3 : MonoBehaviour
{
    private int stage = 0;
    public GameObject back;
    public GameObject next;
    public GameObject panel;
    public GameObject minibox;
    public GameObject inputField;
    public GameObject[] textObjects;
    void Start()
    {
        back.SetActive(true);
        next.SetActive(true);

        back.GetComponent<Button>().onClick.AddListener(BackButtonClicked);
        next.GetComponent<Button>().onClick.AddListener(NextButtonClicked);

        inputField.GetComponent<InputField>().onEndEdit.AddListener(delegate {updateStats(); });

        panel.SetActive(true);
        minibox.SetActive(true);
        inputField.SetActive(false);
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
                next.SetActive(false);
                textObjects[0].SetActive(false);
                textObjects[1].SetActive(true);
                setStats(true);
                inputField.SetActive(true);
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
                // Disable any other text objects as well as input field here!
                // TODO: Complete this!
                textObjects[0].SetActive(true);
                next.SetActive(true);
                setStats(false);
                inputField.SetActive(false);
                break;
            default:
                // Incorrect stage value, set stage value back to 0
                stage = 0;
                break;
        }
    }

    void setStats(bool value){
        for(int i = 2; i < textObjects.Length; i++){
            textObjects[i].SetActive(value);
        }
    }

    void updateStats(){

        float distance = float.Parse(inputField.GetComponent<InputField>().text);

        float litres = distance / 16.2f;
        float timeGasRefueling = Mathf.Max((litres - 70) / 10, 0);
        float totalTimeGas = distance / (50f / 60f) + timeGasRefueling;
        float pollution = 2.3f * litres;

        float charge = distance / 6.4f;
        float timeEVRefueling = Mathf.Max((charge - 50), 0);
        float totalTimeEV = distance / (50f / 60f) + timeEVRefueling;

        textObjects[4].GetComponent<Text>().text = "Time: " + totalTimeEV + " minutes";
        textObjects[5].GetComponent<Text>().text = "Time: " + totalTimeGas + " minutes";

        textObjects[7].GetComponent<Text>().text = "Pollution: " + pollution + " kg of CO2";
    }
}
