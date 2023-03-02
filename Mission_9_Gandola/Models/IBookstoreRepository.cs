using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_9_Gandola.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Books> Books { get; }
    }
}
