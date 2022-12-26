using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager instance;

    private void Awake() 
    {
        if (ChoiceManager.instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private Choice choice1;
    private Choice choice2;
    public GameObject choiceHolder;
    private Button[] buttons;
    public GameObject firstButton;
    private int choiceIndex = -1;
    private bool isActive;

    // Update is called once per frame
    void Update()
    {
        if (isActive && !DialogueManager.instance.inDialogue)
        {
            StartCoroutine(Choose());
            isActive = false;
        }
    }
    
    public void StartChoice(Choice choice1, Choice choice2)
    {
        isActive = true;
        this.choice1 = choice1;
        this.choice2 = choice2;
    }

    IEnumerator Choose()
    {
        UiStatus.OpenUI();
        yield return new WaitForSeconds(0.01f);
        choiceHolder.SetActive(true);
        buttons = choiceHolder.GetComponentsInChildren<Button>();
        buttons[0].GetComponentInChildren<Text>().text = choice1.choice;
        buttons[1].GetComponentInChildren<Text>().text = choice2.choice;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void SetChoice(int i)
    {
        choiceIndex = i;

        if (choiceIndex == 0)
        {
            choice1.TriggerEvent();
        }
        else if (choiceIndex == 1)
        {
            choice2.TriggerEvent();
        }

        choiceIndex = -1;
        closeUI();
        return;
    }

    public void closeUI()
    {
        // yield return new WaitForSeconds(0.01f);
        Debug.Log("Choice made closing UI.");
        choiceHolder.SetActive(false);
        UiStatus.CloseUI();
    }
}
