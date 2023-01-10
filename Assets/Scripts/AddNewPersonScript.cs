using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class AddNewPersonScript : MonoBehaviour
{
    [SerializeField] private TextAsset _xmlDocument;

    [Header("-----UI-----")]
    [SerializeField] private Dropdown _dropDown;

    private XmlDocument xmlDocument = new XmlDocument();
    XmlElement rootElement;

    private void Start()
    {
        xmlDocument.LoadXml(_xmlDocument.text);
        rootElement = xmlDocument.DocumentElement;
        CreatePersonList();
    }

    private void CreatePersonList()
    {
        _dropDown.options.RemoveRange(0,_dropDown.options.Count);

        int NumberValue = 0;
        foreach (XmlElement xnode in rootElement)
        {
            _dropDown.options.Add(new Dropdown.OptionData(xnode.Attributes.GetNamedItem("Number").Value));
            NumberValue++;
        }

    }
}
