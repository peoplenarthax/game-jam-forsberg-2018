using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySerializableDictionary {

}


[Serializable]
public class StringIntDictionary : SerializableDictionary<string, int>
{ }

[Serializable]
public class StringFloatDictionary : SerializableDictionary<string, float>
{ }

[Serializable]
public class StringBoolDictionary : SerializableDictionary<string, bool>
{ }

