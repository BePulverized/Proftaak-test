using System.Collections.Generic;
using ICT4Rails.Models;

namespace ICT4Rails.Contexts
{
    public interface IGenericKeyValueContext
    {
        List<GenericKeyValueModel> GenericKeyValues
        {
            get;
        }

        void Create(GenericKeyValueModel genericKeyValueModel);
        List<GenericKeyValueModel> GetAll();
        void Update(GenericKeyValueModel genericKeyValueModel);
        void Delete(GenericKeyValueModel genericKeyValueModel);
    }
}