using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerBlockManager : MonoBehaviour
{
    public GameObject block;

    void Update()
    {
        if (FollowingManager.instance == null || !FollowingManager.instance.isFollowing) {
            block.SetActive(false);
        } else {
            block.SetActive(true);
        }
    }
}