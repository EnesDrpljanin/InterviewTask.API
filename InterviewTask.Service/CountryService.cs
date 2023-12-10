using InterviewTask.Data;
using InterviewTask.Domain;
using InterviewTask.Domain.Mappers;
using InterviewTask.Service.Exceptions;
using InterviewTask.Service.Interfaces;

namespace InterviewTask.Service
{
    public class CountryService : ICountryService
    {
        private InterviewTaskDbContext _interviewTaskDbContext;

        public CountryService(InterviewTaskDbContext InterviewTaskDbContext)
        {
            _interviewTaskDbContext = InterviewTaskDbContext;
        }
        public List<CountryModel> GetAll()
        {
            var countries = _interviewTaskDbContext.Countries.ToList();
            var countryModel = countries.Select(x => CountryMapper.ToModel(x)).ToList();

            return countryModel;
        }
        public int CreateCountry(CountryModel countryModel)
        {
            var countryEntity = CountryMapper.ToEntity(countryModel);
            _interviewTaskDbContext.Countries.Add(countryEntity);

            return _interviewTaskDbContext.SaveChanges();
        }

        public CountryModel UpdateCountry(CountryModel countryModel)
        {
            var countryEntity = _interviewTaskDbContext.Countries.FirstOrDefault(x => x.Id == countryModel.Id);

            if (countryEntity != null)
            {
                countryEntity.Name = countryModel.Name;

                _interviewTaskDbContext.Update(countryEntity);
                _interviewTaskDbContext.SaveChanges();

                var result = CountryMapper.ToModel(countryEntity);

                return result;
            }
            else
            {
                throw new NotFoundException($"Country with {countryModel.Id} not found ");
            }
        }

        public void DeleteCountry(int id)
        {
            var countryEntity = _interviewTaskDbContext.Countries.FirstOrDefault(x => x.Id == id);

            if (countryEntity != null)
            {
                _interviewTaskDbContext.Countries.Remove(countryEntity);
                _interviewTaskDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException($"Country with {id} not found ");
            }
        }
    }
}
