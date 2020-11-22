using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace InformesProduccion.Core
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Collections;
    using System.Xml.Linq;
    public class RegistroMeritos: ICollection<Merito>
    {
        public const string ArchivoXml = "meritos.xml";
        public const string EtqMeritos = "meritos";
        public const string EtqMerito = "merito";
        public const string EtqDoi = "DOI";
        public const string EtqIssn = "ISSN";
        public const string EtqAno = "ANO";
        public const string EtqPagina = "PAGINA";
        public const string EtqAutor = "AUTOR";

        public RegistroMeritos()
        {
            this.meritos = new List<Merito>();
        }

        public RegistroMeritos(IEnumerable<Merito> meritos)
        {
            this.meritos.AddRange(meritos);
        }

        public void Add(Merito item)
        {
           this.meritos.Add(item);
        }

        public void Clear()
        {
            this.meritos.Clear();
        }

        public bool Contains(Merito item)
        {
            return this.meritos.Contains(item);
        }

        public void CopyTo(Merito[] array, int arrayIndex)
        {
            this.meritos.CopyTo(array, arrayIndex);
        }

        public bool Remove(Merito item)
        {
            return this.meritos.Remove(item);
        }

        public void RemoveAt(int i)
        {
            this.meritos.RemoveAt(i);
        }

        public void AddRange(IEnumerable<Merito> ms)
        {
            this.meritos.AddRange(ms);
        }

        public int Count
        {
            get { return this.meritos.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
        

        private List<Merito> meritos;
        public IEnumerator<Merito> GetEnumerator()
        {
            foreach (var v in this.meritos)
            {
                yield return v;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var v in this.meritos)
            {
                yield return v;
            }
        }

        public static RegistroMeritos RecuperaXml(string f)
        {
            var toret = new RegistroMeritos();

            try
            {
                var doc = XDocument.Load(f);
                if (doc.Root != null && doc.Root.Name == EtqMeritos)
                {
                    var meritos = doc.Root.Elements(EtqMerito);
                    foreach (XElement meritoXml in meritos)
                    {
                        toret.Add(new Merito(
                            (int) meritoXml.Element(EtqDoi),
                            (int) meritoXml.Element(EtqIssn),
                            (int) meritoXml.Element(EtqAno),
                            (string) meritoXml.Element(EtqPagina),
                            (string) meritoXml.Element(EtqAutor)
                        ));
                    }
                }
            }
            catch (XmlException)
            {
                toret.Clear();
            }
            catch (IOException)
            {
                toret.Clear();
            }

            return toret;
        }

        public static RegistroMeritos RecuperaXml()
        {
            return RecuperaXml(ArchivoXml);
        }
        
       
    }
}