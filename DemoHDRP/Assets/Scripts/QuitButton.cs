using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button clickBtn;
    // Start is called before the first frame update
    void Start()
    {
        clickBtn = GetComponent<Button>();
        if (clickBtn != null)
        {
            clickBtn.onClick.AddListener(OnQuit);
        }
    }

    private void OnQuit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
