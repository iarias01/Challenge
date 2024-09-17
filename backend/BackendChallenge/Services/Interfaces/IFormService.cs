using BackendChallenge.Models;

namespace BackendChallenge.Services.Interfaces
{    public interface IFormService
    {        Task<Form> CreateFormAsync(string email, string firstName, string secondName, string comment, IFormFile? file);
    }
}
