using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class NewItemCreation : MonoBehaviour
{
    
    [SerializeField] private TextAsset _xmlDocument;

    [Header("-----UI-----")]

    [SerializeField] private Text _NoteText;
    [SerializeField] private Dropdown _noteDropdown;


    private XmlDocument xmlDocument = new XmlDocument();
    XmlElement rootElement;

    private void Start()
    {
        xmlDocument.LoadXml(_xmlDocument.text);
        rootElement = xmlDocument.DocumentElement;
    }

    public void LoadNewItem()
    {
        XmlElement KeyElem = xmlDocument.CreateElement("Key");

        XmlAttribute numberAttr = xmlDocument.CreateAttribute("Number");

        XmlElement NoteTextElem = xmlDocument.CreateElement("NoteText");


        int nextItemNumber = rootElement.ChildNodes.Count + 1;
        XmlText NumberText = xmlDocument.CreateTextNode(nextItemNumber.ToString());
        XmlText NoteText = xmlDocument.CreateTextNode("");

        numberAttr.AppendChild(NumberText);
        NoteTextElem.AppendChild(NoteText);


        KeyElem.Attributes.Append(numberAttr);
        KeyElem.AppendChild(NoteTextElem);

        rootElement?.AppendChild(KeyElem);

        xmlDocument.Save(@"D:\My Projects\Repository\NotesHub\Assets\Resources\NotesHub.xml");
    }

    public void SaveItem()
    {
        rootElement.ChildNodes.Item(_noteDropdown.value).SelectSingleNode("NoteText").InnerText = _NoteText.text;
        xmlDocument.Save(@"D:\My Projects\Repository\NotesHub\Assets\Resources\NotesHub.xml");
    }

    public void DeleteItem()
    {
        Debug.Log(1);
        XmlNode firstNode = rootElement.FirstChild;
        rootElement.RemoveChild(firstNode);
    }
}
