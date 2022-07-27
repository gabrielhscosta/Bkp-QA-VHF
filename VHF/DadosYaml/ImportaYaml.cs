using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace VHF.DadosYaml
{
    public class ImportaYaml 
    {    
        public static DeserializedObject Deserialize(string nomeArquivo)
        {
            StreamReader arquivo = new StreamReader(nomeArquivo);
            string texto = arquivo.ReadToEnd();
            var entrada = new StringReader(texto);
            var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            DeserializedObject deserializeObject = deserializer.Deserialize<DeserializedObject>(entrada);
            return deserializeObject;
        }
    }
    public class DeserializedObject
    {
        public List<Tarifa> tarifa { get; set; }
        public class Tarifa
        {
            public string descricao { get; set; }
            public List<ValorUH> valorUHs { get; set; }
        }
        public class ValorUH
        {
            public string uh { get; set; }
            public float valorUmPax { get; set; }
            public float valorDoisPax { get; set; }
            public float valorTresPax { get; set; }
            public float valorQuatroPax { get; set; }
            public float valorCincoPax { get; set; }
            public float valorPaxAdicional { get; set; }
            public float valorFixoCri1 { get; set; }
            public float valorFixoCri2 { get; set; }
        }
    }
}
