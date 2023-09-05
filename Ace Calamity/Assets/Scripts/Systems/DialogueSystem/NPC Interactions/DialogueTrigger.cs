using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject interactionImage;
    public GameObject dialogeBox;
    public Dialogue dialogue;
    bool isActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            if (dialogeBox.activeInHierarchy)
            {
                dialogeBox.SetActive(false);
                interactionImage.SetActive(false);
            }
            else
            {
                dialogeBox.SetActive(true);
                interactionImage.SetActive(false);
                TriggerDialogue();

            }
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isActive = true;
            interactionImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isActive = false;
            interactionImage.SetActive(false);
            dialogeBox.SetActive(false);
        }
    }
}
