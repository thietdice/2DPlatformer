using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private Text levelText;
    [SerializeField] private Button bt;
    
    void Start(){
        levelText.text = levelNumber.ToString();
        

    }
    void Update(){
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        if (levelAt < levelNumber) {
            bt.interactable = false;
        }

    }
    public void Select() 
    {
        SceneManager.LoadScene(levelNumber);
        
    }
}
