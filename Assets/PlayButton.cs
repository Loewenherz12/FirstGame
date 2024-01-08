using UnityEngine;

public class DeinSkriptName : MonoBehaviour
{
    public GameObject panel; // Weise dein Panel-GameObject im Unity-Editor zu

    void Update()
    {
        if (panel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            panel.SetActive(false);
        }
    }
}