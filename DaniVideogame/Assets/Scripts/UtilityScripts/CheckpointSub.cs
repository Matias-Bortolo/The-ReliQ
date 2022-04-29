using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSub
{
    GameObject[] _boxes;
    Transform[] _boxesPos;
    GameObject _currentCheckpoint;
    CharacterController _player;

    public CheckpointSub(GameObject[] b, Transform[] bP, CharacterController p, GameObject cC)
    {
        _currentCheckpoint = cC;
        _boxes = b;
        _boxesPos = bP;
        _player = p;
    }

    public void BackToCheckpoint()
    {
        for (int i = 0; i < _boxes.Length; i++)
        {
            _boxes[i].transform.position = _boxesPos[i].transform.position;
        }

        _player.enabled = false;
        _player.transform.position = _currentCheckpoint.transform.position;
        _player.enabled = true;
    }
}
