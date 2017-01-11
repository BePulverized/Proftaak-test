using System.Collections.Generic;
using ICT4Rails.Models;

namespace ICT4Rails.Contexts
{
    public class GenericKeyValueMemoryContext : IGenericKeyValueContext
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public GenericKeyValueMemoryContext()
        {
            GetAll();
        }

        public List<GenericKeyValueModel> GenericKeyValues { get; private set; }

        public void Delete(GenericKeyValueModel genericKeyValueModel)
        {
            GenericKeyValues.Remove(genericKeyValueModel);
        }

        public void Create(GenericKeyValueModel genericKeyValueModel)
        {
            GenericKeyValues.Add(genericKeyValueModel);
        }

        public List<GenericKeyValueModel> GetAll()
        {
            GenericKeyValues = new List<GenericKeyValueModel>()
            {
                new GenericKeyValueModel()
                {
                    Id = 0,
                    Name = "Cleaning"
                },
                new GenericKeyValueModel()
                {
                    Id = 1,
                    Name = "Repair"
                }
            };
            return GenericKeyValues;
        }

        public void Update(GenericKeyValueModel genericKeyValueModel)
        {

        }
    }
}