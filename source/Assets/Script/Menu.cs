using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private Button resume;
    [SerializeField] private Button quit;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
        resume.onClick.AddListener(Resume);
        quit.onClick.AddListener(Quit);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    private void Resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    private void Quit()
    {
        PausePanel.SetActive(false);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}