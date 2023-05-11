using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{   
    #region Definitons
    public static GameButtons Instance;
    public bool gameOver;
    public int score;
    private int star_;
    [SerializeField] private GameObject LosePopUp;
    [SerializeField] private List<GameObject> StarImages;

    #endregion
    private void Awake() 
    {
        if(Instance)
        {
            Destroy(Instance);
        }

        Instance = this;  

        QualitySettings.vSyncCount = 0;  
    }
    private void Start() 
    {
        gameOver = false;  
        score = 0; 
        star_ = 0; 
    }
    private void Update() 
    {
        if(gameOver)
        {
            doGameOver();
            starCreate();
        }
        
    }
    #region Methods
    private void doGameOver()// oyunu bitiren method
    {   
        LosePopUp.SetActive(true);
        Time.timeScale = 0;  
    }
    private void starNumber()//oyun sonunda score a göre ekranda belirecek yıldız sayısını ayarlayan method.
    {   
        if(score >= 300)
        {
            star_ = 5;
        }
        else if(score >= 150)
        {
            star_ = 4;
        }
        else if(score >= 60)
        {
            star_ = 3;
        }
        else if(score >= 30)
        {
            star_ = 2;
        }
        else
        {
            star_ = 1;
        }

    }
    public void starCreate()//oyun sonunda yıldızların belirlenmesi
    {   
        starNumber();
        for(int star = 0 ; star < star_ ; star++)
        {
            StarImages[star].SetActive(true);
        }
    }
     public void LoadScene(string sceneName)//sahne yüklemek gerektiğinde kullanılacak.
    {    
        SceneManager.LoadScene(sceneName);
    }
    
    #endregion
}
