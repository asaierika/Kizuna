using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eri_caslte1st : Interactable
{
    public Conversation convo;
    public Choice choice1, choice2;
    public VectorValue playerPosition;

    void Update()
    {
        TryInteract();
    }

    public override void Interact()
    {
        DialogueManager.StartConversation(convo);
        ChoiceManager.instance.StartChoice(choice1, choice2);
    }

    public void Choice1()
    {
        playerPosition.initialValue = new Vector2(1.2f, -1f);
        FollowingManager.instance.StartFollowing();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Castle_1stHall");
    }
}