using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country
{
    public List<Transfer>   Transfers { get; set; }
    public List<Hotel>      Hotels { get; set; }
    public List<Excursion>  Excursions { get; set; }
    public string Name { get; set; }
}
