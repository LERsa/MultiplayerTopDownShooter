using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility 
{
    public static string RemoveQuotes(this string Value)
    {
        return Value.Replace("\"", "");
    }
}
