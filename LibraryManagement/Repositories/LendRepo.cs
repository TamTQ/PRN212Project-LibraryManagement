using LibraryManagement.BusinessObject;
using LibraryManagement.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repositories
{
    public class LendRepo : ILendRepo
    {
        public void AddLend(Lend lend) => LendDAO.AddLend(lend);

        public List<Lend> GetLend() => LendDAO.GetLends();

        public List<Lend> GetLendByUserId(int Id) => LendDAO.GetLendByUserId(Id);

        public void UpdateLendReturnDate(int id, DateOnly returnDate) => LendDAO.UpdateLendReturnDate(id, returnDate);
    }
}
