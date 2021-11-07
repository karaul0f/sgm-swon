using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country
{
    public Country()
    {
        Transfers = new Dictionary<string, Transfer>();
        Hotels = new Dictionary<string, Hotel>();
        Excursions = new Dictionary<string, Excursion>();
    }

    public Dictionary<string, Transfer>   Transfers { get; set; }
    public Dictionary<string, Hotel>      Hotels { get; set; }
    public Dictionary<string, Excursion>  Excursions { get; set; }
    public string Name { get; set; }
}
