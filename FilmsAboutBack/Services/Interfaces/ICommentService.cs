using FilmsAboutBack.DataAccess.DTO.Respones;
using FilmsAboutBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Services.Interfaces
{
    public interface ICommentService : ICRUDService<Comment>
    {
        Task<IEnumerable<Comment>> GetAllByFilmIdAsync(int id);
    }
}
