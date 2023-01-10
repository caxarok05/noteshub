using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using UnityEngine.UI;

public class XMLReaderScript : MonoBehaviour
{
    [SerializeField] private TextAsset _xmlDocument;

    [Header("-----UI-----")]
    [SerializeField] private Dropdown _dropDown;

    [SerializeField] private InputField _NotesText;


    private XmlDocument xmlDocument = new XmlDocument();
    XmlElement rootElement;

    private void Start()
    {
        xmlDocument.LoadXml(_xmlDocument.text);
        rootElement = xmlDocument.DocumentElement;
        ChangeText();
        _dropDown.onValueChanged.AddListener(delegate { ChangeText(); });
    }

    private void ChangeText()
    {
        _NotesText.text = rootElement.ChildNodes.Item(_dropDown.value).SelectSingleNode("NoteText").InnerText;
    }


}
