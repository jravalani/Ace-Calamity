using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoreMarkers : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public GameObject interactionButton;

    [TextArea(3, 10)]
    public string diagloue;
    bool isActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
                interactionButton.SetActive(false);
            }
            else
            {
                dialogueBox.SetActive(true);
                dialogueText.text = diagloue;
                interactionButton.SetActive(false);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player in range");
            isActive = true;
            interactionButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited the range");
            isActive = false;
            interactionButton.SetActive(false);
            dialogueBox.SetActive(false);
        }
    }
}
