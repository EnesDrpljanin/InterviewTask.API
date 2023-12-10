using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Data.Entities;
using InterviewTask.Domain.ContactModels;

namespace InterviewTask.Domain.Mappers
{
    public static class ContactMapper
    {
        public static Contact ContactCreateModelToEntity(ContactCreateModel model)
        {
            return new Contact()
            {
                Name = model.Name,
                CompanyId = model.CompanyId,
                CountryId = model.CountryId,
                CreatedOn = DateTime.Now
            };
        }

        public static ContactModel ToContactModel(Contact entity)
        {
            return new ContactModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedOn = entity.CreatedOn
            };
        }

        public static ContactUpdateModel EntityToUpdateModel(Contact entity)
        {
            return new ContactUpdateModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                CompanyId = entity.CompanyId,
                CountryId = entity.CountryId,
            };
        }
    }
}
