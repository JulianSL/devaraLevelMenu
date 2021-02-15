using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNode : MonoBehaviour
{
    // Start is called before the first frame update
    private int idNode;
    [SerializeField] GameObject BlockLocked;
    [SerializeField] GameObject BlockCurrent;
    [SerializeField] GameObject BlockUnlocked;
    [SerializeField] GameObject LineRight;
    [SerializeField] GameObject LineLeft;
    [SerializeField] GameObject LineTop;
    [SerializeField] Text TextLevel;

    public void SetupLevelNode(int _idNode, int _currentLevel)
    {

        idNode = _idNode;
        TextLevel.text = idNode.ToString();
        if(idNode < _currentLevel)
        {
            SetUnlocked();
        }
        else if(idNode == _currentLevel)
        {
            SetCurrentLevel();
        }
        else
        {
            SetLocked();
        }
    }

    private void SetLocked()
    {
        BlockLocked.SetActive(true);
    }

    private void SetUnlocked()
    {
        BlockUnlocked.SetActive(true);
    }

    private void SetCurrentLevel()
    {
        BlockCurrent.SetActive(true);
    }

    public void SetLine(int _idLine)
    {
        switch (_idLine)
        {
            case 1:
                LineRight.SetActive(true);
                break;
            case 2:
                LineLeft.SetActive(true);
                break;
            case 3:
                LineTop.SetActive(true);
                break;
            default:
                break;
        }
    }
    
}