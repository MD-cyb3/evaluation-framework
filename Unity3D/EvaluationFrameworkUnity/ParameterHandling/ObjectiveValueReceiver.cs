﻿/*
© Siemens AG, 2020
Author: Michael Dyck (m.dyck@gmx.net)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

<http://www.apache.org/licenses/LICENSE-2.0>.

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;

public class ObjectiveValueReceiver
{
    protected GameObject sourceGameObject;
    protected Component sourceComponent;
    protected string sourceVariableName;

    public ObjectiveValueReceiver(GameObject _gameObject,
                                  Component _component,
                                  string _variableName)
    {
        sourceGameObject = _gameObject;
        sourceComponent = _component;
        sourceVariableName = _variableName;
    }

    public object RetrieveObjectiveValue()
    {
        try
        {
            return sourceComponent.GetType().GetField(sourceVariableName).GetValue(sourceComponent);
        }
        catch (System.NullReferenceException)
        {
            return sourceComponent.GetType().GetProperty(sourceVariableName).GetValue(sourceComponent);
        }
    }
}
