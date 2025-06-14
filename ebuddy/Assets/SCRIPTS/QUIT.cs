using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class QUIT : MonoBehaviour
{
    // This function will be called when the button is clicked.
    public void ExitGame()
    {
        // If running in the Unity editor, stop playing.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running as a standalone build, quit the application.
        Application.Quit();
#endif
    }
}