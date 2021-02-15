using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject levelNode;
    [SerializeField] GameObject levelNodeContainer;
    int totalLevel;
    int currentLevel;

    List<LevelNode> ListOfLevelNode = new List<LevelNode>();

    public void AttachLevelNode(int _idNode, int _currentLevel, Vector2 _position)
    {
        GameObject newNode = Instantiate(levelNode, levelNodeContainer.transform);
        newNode.GetComponent<RectTransform>().anchoredPosition = _position;
        //GameObject newItem = PhotonNetwork.InstantiateRoomObject("PrefabItem", _position, Quaternion.identity, 0);
        newNode.GetComponent<LevelNode>().SetupLevelNode(_idNode, _currentLevel);
        ListOfLevelNode.Add(newNode.GetComponent<LevelNode>());
    }

    public LevelNode GetNode(int _index)
    {
        return (ListOfLevelNode[_index]) as LevelNode;
    }


    void Start()
    {
        totalLevel = 13;
        currentLevel = 5;
        int segment = 3;
        float yPos = 100;
        float xPos = 100;
        int offset = 150;
        int id = 0;
        for (int i = 0; i < System.Math.Ceiling((double)totalLevel / segment); i++)
        {
            Debug.Log(System.Math.Ceiling((double)totalLevel / segment));

            if(i % 2 == 0)
            {
                for (int j = segment; j > 0; j--)
                {
                    if (ListOfLevelNode.Count < totalLevel)
                    {
                        id++;
                        AttachLevelNode(id, currentLevel, new Vector2(xPos, yPos));
                        xPos += offset;
                        if (j > 1)
                        {
                            GetNode(ListOfLevelNode.Count - 1).SetLine(1);
                        }
                        else
                        {
                            GetNode(ListOfLevelNode.Count - 1).SetLine(3);
                        }
                    }
                    
                }
                xPos -= offset;
            }
            else //row ganjil
            {
                for (int j = 0; j < segment; j++)
                {
                    if (ListOfLevelNode.Count < totalLevel)
                    {
                        id++;
                        AttachLevelNode(id, currentLevel, new Vector2(xPos, yPos));
                        xPos -= offset;
                        if (j < segment - 1)
                        {
                            GetNode(ListOfLevelNode.Count - 1).SetLine(2);
                        }
                        else
                        {
                            GetNode(ListOfLevelNode.Count - 1).SetLine(3);
                        }
                    }
                    
                }
                xPos += offset;
            }
            yPos += offset;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
