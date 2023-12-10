using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Data.Entities;

namespace InterviewTask.Domain.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyModel ToModel(this Company entity)
        {
            return new CompanyModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Company ToEntity(this CompanyModel model)
        {
            return new Company()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
