using InterviewTask.Domain;

namespace InterviewTask.Service.Interfaces
{
    public interface ICountryService
    {
        int CreateCountry(CountryModel countryModel);
        void DeleteCountry(int id);
        List<CountryModel> GetAll();
        CountryModel UpdateCountry(CountryModel countryModel);
    }
}