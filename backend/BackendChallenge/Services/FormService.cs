using BackendChallenge.Models;
using BackendChallenge.Services.Interfaces;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BackendChallenge.Services
{
    public class FormService : IFormService
    {
        private readonly string _connectionString;

        public FormService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<Form> CreateFormAsync(string email, string firstName, string secondName, string comment, IFormFile? file)
        {
            Form newForm = new Form
            {
                Id = Guid.NewGuid(),
                Email = email,
                FirstName = firstName,
                SecondName = secondName,
                Comment = comment,
                File = file != null ? ConvertToBytes(file) : null
            };

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand("INSERT INTO Forms (Id, Email, FirstName, SecondName, Comment, File) VALUES (@Id, @Email, @FirstName, @SecondName, @Comment, @File)", connection))
                    {
                        command.Parameters.AddWithValue("@Id", newForm.Id);
                        command.Parameters.AddWithValue("@Email", newForm.Email);
                        command.Parameters.AddWithValue("@FirstName", newForm.FirstName);
                        command.Parameters.AddWithValue("@SecondName", newForm.SecondName);
                        command.Parameters.AddWithValue("@Comment", newForm.Comment);
                        command.Parameters.AddWithValue("@File", newForm.File != null ? (object)newForm.File : DBNull.Value);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al crear el formulario", ex);
            }

            return newForm;
        }


        private byte[] ConvertToBytes(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
