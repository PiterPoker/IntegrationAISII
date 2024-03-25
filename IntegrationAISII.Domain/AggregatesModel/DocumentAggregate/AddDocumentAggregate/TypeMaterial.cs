using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate
{
    public class TypeMaterial
        : Enumeration
    {
        public static TypeMaterial Appendix = new TypeMaterial(1, "Приложения документа".ToLowerInvariant());
        public static TypeMaterial InformationAndReference = new TypeMaterial(2, "Информационно-справочные".ToLowerInvariant());
        public static TypeMaterial Link = new TypeMaterial(3, "Ссылка на другие документы".ToLowerInvariant());

        public TypeMaterial(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<TypeMaterial> List() =>
            new[] { Appendix, InformationAndReference, Link };

        public static TypeMaterial FromName(string name)
        {
            var typeMaterials = List()
                .SingleOrDefault(ts => string.Equals(ts.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (typeMaterials is null)
                throw new IntegrationAISIIDomainException($"Possible values for type material: {string.Join(",", List().Select(st => st.Name))}");

            return typeMaterials;
        }

        public static TypeMaterial From(int id)
        {
            var typeMaterials = List()
                .SingleOrDefault(ts => ts.Id == id);

            if (typeMaterials is null)
                throw new IntegrationAISIIDomainException($"Possible values for type material: {string.Join(",", List().Select(st => st.Name))}");

            return typeMaterials;
        }
    }
}
