using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataExportToXl
{
    class Serializer
    {
        private string _pathXl;

        internal void SerializeToXml(List<Product> listOfObjects)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));

            using (FileStream fileStream = new FileStream(_pathXl + "products.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, listOfObjects);
            }

            Console.WriteLine("Serialization completed successfully.");
        }

        public Serializer(ConfigurationServices configuration, string keyPathXl)
        {
            while (String.CompareOrdinal(_pathXl, configuration.PathXl) == 0 || string.IsNullOrEmpty(_pathXl))
            {
                if (keyPathXl.Equals("PathXl", StringComparison.Ordinal))
                {
                    _pathXl = configuration.PathXl;
                    return;
                }

                Console.WriteLine("Unknown path to XML File. Please input correct key.");
                keyPathXl = Console.ReadLine();
            }
        }
    }
}
