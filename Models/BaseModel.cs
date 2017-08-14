using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DynamicModel.Models
{
    public class BaseModel<T>
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public CustomModels CurrentModel { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            XmlSerializer serializer = new XmlSerializer(this.GetType(), null, new Type[0], null, null);
            serializer.Serialize(stringWriter, this);
            return stringBuilder.ToString();
        }
    }

}