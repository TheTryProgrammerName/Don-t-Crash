using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

public class LevelLoader
{
    private Queue<XElement> _cubesConditions;

    public LevelLoader()
    {
        _cubesConditions = new Queue<XElement>();
    }

    public void Load(int LevelNumber)
    {
        TextAsset levelFile = (TextAsset)Resources.Load("Levels\\Level" + LevelNumber, typeof(TextAsset)); //Получили файл
        XmlElement Level = GetHeaderElement(levelFile);
        Queue<XElement> Chunks = GetChunks(Level);

        Queue<XElement> chunkVersions = new Queue<XElement>();
        int chunksCount = Chunks.Count;

        for (int i = 0; i < chunksCount; i++)
        {
            XElement handleChunk = Chunks.Dequeue();
            XElement chunkVersion = GetRandomChunkVersion(handleChunk);
            chunkVersions.Enqueue(chunkVersion);
        }

        foreach (XElement Post in Chunks.Elements("Post"))
        {
            _cubesConditions.Enqueue(Post); //Заносим состояние всех столбов из всех полученных чанков в массив
        }
    }

    private XmlElement GetHeaderElement(TextAsset textAsset)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(textAsset.text);
        XmlElement header = xmlDocument.DocumentElement;

        return header;
    }

    private Queue<XElement> GetChunks(XmlElement level)
    {
        Queue<XElement> chunks = new Queue<XElement>();

        return chunks;
    }

    private XElement GetRandomChunkVersion(XElement chunk)
    {
        return null;
    }

    public Queue<bool> GetCubesCondition()
    {
        Queue<bool> CubesCondition = new Queue<bool>();

        foreach (XElement Cube in _cubesConditions.Dequeue().Elements("Cube"))
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