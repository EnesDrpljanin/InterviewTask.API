using InterviewTask.Domain;

namespace InterviewTask.Service.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyModel> GetAll();
        int CreateCompany(CompanyModel companyModel);

        CompanyModel UpdateCompany(CompanyModel companyModel);

        void DeleteCompany(int id);
    }
}
