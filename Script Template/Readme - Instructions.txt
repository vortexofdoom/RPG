A good idea is to replace your default template script for unity. This will save you having to constantly add the namespace RPG at the start.

I also changed the default using statement to be "using System.Collection.Generic" instead of "using System.Collection". This is because
the .Generic version contains things such as lists and Dictionaries, whereas the standard collection only contains the interfaces. If people don't like this
It can be changed back.

To use this template find your unity install folder then follow the path "Data/Resources/ScriptTemplates/" and replace the NewBehaviousScript.cs with my copy. 
I'm not sure if the if yours will be exactly "81-C# script-NewBehaviourScript.cs", but look for one similar and override it. 