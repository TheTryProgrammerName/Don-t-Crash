using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class LevelLoader
{
    private Queue<XElement> _posts = new Queue<XElement>();

    public void Load(int LevelNumber)
    {
        TextAsset levelFile = (TextAsset)Resources.Load("Levels\\Level" + LevelNumber, typeof(TextAsset)); //�������� ����

        XDocument LevelDocument = XDocument.Parse(levelFile.text); //���������� � XDocument
        XElement Level = LevelDocument.Element("Level");

        List<XElement> Chunks = new List<XElement>();

        for (int i = 0; i < Level.Elements().Count();)
        {
            i++;

            XElement Chunk = Level.Element("Chunk" + i); //�������� ��� ����
            Chunks.Add(Chunk.Element("Version" + Random.Range(1, Chunk.Elements().Count()))); //�������� ��������� ��� ������ � ��������� � ������ ������
        }

        foreach (XElement Post in Chunks.Elements("Post"))
        {
            _posts.Enqueue(Post); //������� ��������� ���� ������� �� ���� ���������� ������ � ������
        }
    }

    public Queue<bool> GetCubesCondition(int PostNumber)
    {
        Queue<bool> CubesCondition = new Queue<bool>();

        foreach (XElement Cube in _posts.Dequeue().Elements("Cube"))
        {
            if (Cube.Attribute("isActive").Value != "")
            {
                CubesCondition.Enqueue(true);
            }
            else
            {
                CubesCondition.Enqueue(false);
            }
        }

        return CubesCondition;
    }
}