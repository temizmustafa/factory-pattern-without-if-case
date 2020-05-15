## Factory Desing Pattern

You know what the factory design pattern is. If not, I found a good <a href="https://www.c-sharpcorner.com/article/factory-method-design-pattern-in-c-sharp/">explanation</a>. Thanks to the writer.

<i>"Factory Method is a Design Pattern which defines an interface for creating an object but lets the classes that implement the interface decide which class to instantiate. Factory Pattern lets a class postpone instantiation to sub-classes.
 
The factory pattern is used to replace class constructors, abstracting the process of object generation so that the type of the object instantiated can be determined at run-time."</i>

Shortly, we create a class depending on situation at run-time.

---

I setup a default factory pattern environment.

<p align="center">
  <img src="https://github.com/hebset/factory-pattern-without-if-case/blob/master/factory-pattern-without-if-case/Images/ProjectStructures.png" alt="Project Structure">
</p>

### Project Structure

- Console App(.NET Core)

### Interfaces and Classes

- Create a interface named **IDocument**

```csharp
// IDocument.cs

public interface IDocument
{
    void Open();
    void Close();
    string GetDocumentType();
}
```

- Create concrete classes named **PdfDocument** and **WordDocument**

```csharp
// PdfDocument.cs

public class PdfDocument : IDocument
{
    public void Open()
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public string GetDocumentType()
    {
        return "PDF";
    }
}


// WordDocument.cs

public class WordDocument : IDocument
{
    public void Open()
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        throw new NotImplementedException();
    }

    public string GetDocumentType()
    {
        return "WORD";
    }
}
```

- Create a factory class named **DocumentFactory**

```csharp
// DocumentFactory.cs

public class DocumentFactory
{
    public static IDocument CreateDocument(string documentType)
    {
        if (documentType == "PDF")
            return new PdfDocument();
        else if (documentType == "WORD")
            return new WordDocument();
        else
            return null;
    }
}
```

- Use this factory class to produce some documents

```csharp
// Program.cs

static void Main(string[] args)
{
    IDocument document = DocumentFactory.CreateDocument("PDF");
    Console.WriteLine("Created Document Type : " + document.GetDocumentType());

    document = DocumentFactory.CreateDocument("WORD");
    Console.WriteLine("Created Document Type : " + document.GetDocumentType());

    Console.ReadLine();
}
```

### Config

```xml
// App.config

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
</configuration>
```

---


We see that the factory method creates classes according to the conditions in "main method".

Let's change the structure, factory method looks for configuration not condition. As a result, our code does not need to compile again if we read the condition from the config file.

### Changes

1. Change the config file. Be sure that class name and document type name must be the same.

```xml
// New App.config

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="use-doc-type" value="PdfDocument"/>
  </appSettings>
</configuration>
```
2. Change existing method or add a new method in factory class. I prefered second one. Using "GetType" method is the key. 
"GetType" takes one parameter. It is fullname of type name. It means that parameter is full assembly name. 

<**ProjectName.Folder.Folder...ClassName**>

Activator.CreateInstance creates a desired class with this parameter.

```csharp
// DocumentFactory.cs

public class DocumentFactory
{
    public static IDocument CreateDocument(string documentType)
    {
        if (documentType == "PDF")
            return new PdfDocument();
        else if (documentType == "WORD")
            return new WordDocument();
        else
            return null;
    }
    
    public static IDocument CreateDocument()
    {
        try
        {
            Type type = Type.GetType("factory_pattern_without_if_case.Concrete." + ConfigurationManager.AppSettings["use-doc-type"].ToString());
            var instance = (IDocument)Activator.CreateInstance(type);

            return instance;
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }
}
```
So, if you use this structure, you don't need to use if or switch statements, only change the config file.

### License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)
- **[MIT license](http://opensource.org/licenses/mit-license.php)**
