using LibraryManagement.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public interface ILendRepo
    {
        List<Lend> GetLend();
        List<Lend> GetLendByUserId(int Id);
        void AddLend(Lend lend);
        void UpdateLendReturnDate(int id, DateOnly returnDate);
    }
}
