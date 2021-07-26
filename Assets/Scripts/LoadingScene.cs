using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public float waitToLoad;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitToLoad > 0)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                SceneManager.LoadScene(PlayerPrefs.GetString("Current_Scene"));
                GameManager.instance.transform.GetChild(0).gameObject.SetActive(true);
                GameManager.instance.transform.GetChild(1).gameObject.SetActive(true);
                GameManager.instance.LoadData();
                QuestManager.instance.LoadQuestData();
                


            }
        }
    }
}
