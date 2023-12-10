using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Data;
using InterviewTask.Domain;
using InterviewTask.Domain.ContactModels;
using InterviewTask.Domain.Mappers;
using InterviewTask.Service.Exceptions;
using InterviewTask.Service.Interfaces;

namespace InterviewTask.Service
{
    public class ContactService : IContactService
    {
        private InterviewTaskDbContext _interviewTaskDbContext;

        public ContactService(InterviewTaskDbContext InterviewTaskDbContext)
        {
            _interviewTaskDbContext = InterviewTaskDbContext;
        }
        public List<ContactModel> GetAll()
        {
            var contacts = _interviewTaskDbContext.Contacts.ToList();
            var contactModels = contacts.Select(x => ContactMapper.ToContactModel(x)).ToList();

            return contactModels;
        }
        public int CreateContact(ContactCreateModel contactModel)
        {
            var contactEntity = ContactMapper.ContactCreateModelToEntity(contactModel);

            _interviewTaskDbContext.Contacts.Add(contactEntity);

            return _interviewTaskDbContext.SaveChanges();
        }

        public ContactUpdateModel UpdateContact(ContactUpdateModel contactModel)
        {
            var contactEntity = _interviewTaskDbContext.Contacts.FirstOrDefault(x => x.Id == contactModel.Id);

            if (contactEntity != null)
            {
                contactEntity.Name = contactModel.Name;
                contactEntity.CompanyId = contactModel.CompanyId;
                contactEntity.CountryId = contactModel.CountryId;

                _interviewTaskDbContext.Update(contactEntity);
                _interviewTaskDbContext.SaveChanges();

                return ContactMapper.EntityToUpdateModel(contactEntity);
            }
            else
            {
                throw new NotFoundException($"Contact with {contactModel.Id} not found ");
            }
        }

        public void DeleteContact(int id)
        {
            var contactEntity = _interviewTaskDbContext.Contacts.FirstOrDefault(x => x.Id == id);

            if (contactEntity != null)
            {
                _interviewTaskDbContext.Contacts.Remove(contactEntity);
                _interviewTaskDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException($"Contact with {id} not found ");
            }
        }

        public List<ContactExpandedModel> GetContactsWithCompanyAndCountry()
        {
           return _interviewTaskDbContext.Contacts.Select(x => new ContactExpandedModel()
           {
                Id = x.Id,
                Name = x.Name,
                CountryId = x.CountryId,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.Name,
                CountryName = x.Country.Name
           }).ToList();
        }

        public List<ContactExpandedModel> FilterContacts(int? countryId , int? companyId)
        {
            var query = _interviewTaskDbContext.Contacts.AsQueryable();

            if(countryId != null)
            {
                query = query.Where(x => x.CountryId == countryId);
            }

            if(companyId != null)
            {
                query = query.Where(x => x.CompanyId == companyId);
            }

            return query.Select(x => new ContactExpandedModel()
            {
                Id = x.Id,
                Name = x.Name,
                CountryId = x.CountryId,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.Name,
                CountryName = x.Country.Name
            }).ToList();
        }
    }
}

