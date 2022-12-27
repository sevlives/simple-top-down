using Godot;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleTopDown.Scripts.Debug
{
    public class DebugOverlay : CanvasLayer
    {
        private List<(string, object, string, bool)> _stats = new List<(string, object, string, bool)>();

        public void AddStat(string statName, object obj, string statRef, bool isMethod)
        {
            _stats.Add((statName, obj, statRef, isMethod));
        }

        public void UpdateOverlay()
        {
            string labelText = "";
            foreach (var (statName, obj, statRef, isMethod) in _stats)
            {
                object value = null;
                if (obj != null)
                {
                    Type type = obj.GetType();
                    if (isMethod)
                    {
                        // Get a MethodInfo object for the method with the specified name.
                        MethodInfo method = type.GetMethod(statRef);
                        if (method != null)
                        {
                            // Invoke the method and get the return value.
                            value = method.Invoke(obj, null);
                        }
                    }
                    else
                    {
                        // Get a FieldInfo object for the field with the specified name.
                        PropertyInfo property = type.GetProperty(statRef);
                        if (property != null)
                        {
                            // Get the value of the field.
                            value = property.GetValue(obj);
                        }
                    }
                }
                labelText += $"{statName}: {value}\n";
            }
            GetNode<Label>("DebugLabel").Text = labelText;
        }
    }
}
