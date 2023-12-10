using InterviewTask.Domain;
using InterviewTask.Domain.ContactModels;

namespace InterviewTask.Service.Interfaces
{
    public interface IContactService
    {
        List<ContactModel> GetAll();

        int CreateContact(ContactCreateModel contactModel);

        ContactUpdateModel UpdateContact(ContactUpdateModel contactModel);

        void DeleteContact(int id);

        List<ContactExpandedModel> GetContactsWithCompanyAndCountry();

        List<ContactExpandedModel> FilterContacts(int? countryId, int? companyId);
    }
}
