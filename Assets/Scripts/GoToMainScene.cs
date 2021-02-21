using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToMainScene : MonoBehaviour
{

    [SerializeField] private Button button = null;

    private void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(backButtonClicked);   
    }

    public void backButtonClicked(){
        SceneManager.LoadScene("SampleScene");
    }
}
