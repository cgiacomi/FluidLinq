# FluidLinq

FluidLinq is a small Linq extension library that makes it very easy to parse XML.

The library is meant to be used to deserialize objects from XML. It reduces the code that needs to be written and ensures that you do not run into unforseen errors.

The library was created to make it easy to work with Linq to XML queries. The extension methods provided allow the developer to use a fluid, type safe, elegant syntax to create Linq queries. The library removes a lot of boiler plate code and casting that is normally associated with Linq to XML queries.

The extension methods can also be used in isolation when you are working with XmlNode or XmlDocument objects and you can easily cast them to XDocument and XElement objects so that you can read the values of elements and attributes you need.


Thanks goes to [runeapetersen](https://github.com/runeapetersen) who helped convert an idea into implementation.


## Requirements

FluidLinq requires .NET4 runtime as it makes use of Linq to XML, Extension methods, Generics, Lambda expressions and Delegates.

The project requires Visual Studio 2010


## Installation

FluidLinq is available for download from [NuGet](http://nuget.org/packages/FluidLinq) or if you prefer you can download the source and compile it directly.



## Use

The following is a simplified Linq to XML example where you want to deserialize an XML document to an object.

To better understand how simple and elegant FluidLinq is we will first define a sample XML file

    <?xml version="1.0" encoding="utf-8" ?>
    <Books>
      <Book isbn="978-0201616224">
        <Pages>352</Pages>
        <Author>Andrew Hunt</Author>
        <Title>
          The Pragmatic Programmer
        </Title>
        <Published>10/20/1999</Published>
        <Paperback>true</Paperback>
      </Book>
      <Book isbn="978-0201633610">
        <Pages>416</Pages>
        <Author>Gang of Four</Author>
        <Title>
          Design patterns : elements of reusable object-oriented software
        </Title>
        <Published>10/31/1994</Published>
      </Book>
    </Books>


And a simple Linq query to deserialize the XML shown above would look like this


    XDocument xmlDoc = XDocument.Load("file.xml");

    var books = from item in xmlDoc.Descendants("Book")
                select new Book()
                {
                  ISBN = item.Attribute("isbn").Value,
                  Pages = (int)item.Element("Pages").Value,
                  Author = item.Element("Author").Value,
                  Title = item.Element("Title").Value,
                  Published = DateTime.Parse(item.Element("Published").Value),
                  Paperback = item.Element("Paperback") != null ? (bool)item.Element("Paperback").Value : false,
                };


Although this is a simple example it suffers from several problems


- To convert values to .NET types we need to, for example, call `DateTime.Parse()` which could fail if the date is formatted incorrectly.

- Calling `(bool)item.Element("Paperback").Value` on an optional XML element could result in an Exception.

- Calling `(int)item.Element("Pages").Value` on a value that cannot be cast to an `int` will result in an Exception.

- For every property we have to type an extra `.Value` just to get the actual value from the element.



As you can see some of these issues require you to check for `null` and/or handle typecasting, making your code uggly and forcing you live with useless code duplication.

Although this may not seem like a huge burden it can lead to buggy and unstable code, especially when working with large and complex XML files.



With FluidLinq the code would look like


    XDocument xmlDoc = XDocument.Load("file.xml");

    var books = from item in xdoc.Descendants("Book")
            select new Book()
            {
                ISBN = item.AttributeValueOrDefault<string>("isbn"),
                Pages = item.ElementValueOrDefault<int>("Pages"),
                Author = item.ElementValueOrDefault<string>("Author"),
                Title = item.ElementValueOrDefault<string>("Title"),
                Published = item.ElementValueOrDefault<DateTime>("Published")
                Paperback = item.ElementValueOrDefault<bool>("Paperback")
            };


All that is needed is that you specify the `Type` and the `name` of the attribute or element whose value you are interested in.

If the value cannot be cast to the correct type, or if the element or attribute is null, then the extension method will return the `default(T)`



For more information on Linq to XML you can refer to the following article from Microsoft on [MSDN](http://msdn.microsoft.com/en-us/library/bb387061.aspx)

## License

FluidLinq is released under the Apache License, Version 2.0