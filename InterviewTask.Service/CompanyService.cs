using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewTask.Data;
using InterviewTask.Domain;
using InterviewTask.Domain.Mappers;
using InterviewTask.Service.Exceptions;
using InterviewTask.Service.Interfaces;

namespace InterviewTask.Service
{
    public class CompanyService : ICompanyService
    {
        private InterviewTaskDbContext _interviewTaskDbContext;

        public CompanyService(InterviewTaskDbContext InterviewTaskDbContext)
        {
            _interviewTaskDbContext = InterviewTaskDbContext;
        }
        public List<CompanyModel> GetAll()
        {
            var companies =  _interviewTaskDbContext.Companies.ToList();
            var companyModels = companies.Select(x => x.ToModel()).ToList();

            return companyModels;
        }
        public int CreateCompany(CompanyModel companyModel)
        {
            var companyEntity = companyModel.ToEntity();
            _interviewTaskDbContext.Companies.Add(companyEntity);

            return _interviewTaskDbContext.SaveChanges();
        }

        public CompanyModel UpdateCompany(CompanyModel companyModel)
        {
            var companyEntity = _interviewTaskDbContext.Companies.FirstOrDefault(x => x.Id == companyModel.Id);

            if (companyEntity != null)
            {
                companyEntity.Name = companyModel.Name;

                _interviewTaskDbContext.Update(companyEntity);
                _interviewTaskDbContext.SaveChanges();

                return companyEntity.ToModel();
            }
            else
            {
                throw new NotFoundException($"Company with {companyModel.Id} not found ");
            }
        }

        public void DeleteCompany(int id)
        {
            var companyEntity = _interviewTaskDbContext.Companies.FirstOrDefault(x => x.Id == id);

            if (companyEntity != null)
            {
                _interviewTaskDbContext.Companies.Remove(companyEntity);
                _interviewTaskDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException($"Company with {id} not found ");
            }
        }
    }
}
