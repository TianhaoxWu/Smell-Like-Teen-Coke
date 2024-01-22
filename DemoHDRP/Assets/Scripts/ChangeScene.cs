using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    private Button clickBtn;
    public int sceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        clickBtn = GetComponent<Button>();
        if (clickBtn != null)
        {
            clickBtn.onClick.AddListener(LoadScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
