using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



[CustomPropertyDrawer(typeof(StringIntDictionary))]
public class StringIntDictionaryPropertyDrawer :
SerializableDictionaryPropertyDrawer
{ }

[CustomPropertyDrawer(typeof(StringFloatDictionary))]
public class StringFloatDictionaryPropertyDrawer :
SerializableDictionaryPropertyDrawer
{ }

[CustomPropertyDrawer(typeof(StringBoolDictionary))]
public class StringBoolDictionaryPropertyDrawer :
SerializableDictionaryPropertyDrawer
{ }

