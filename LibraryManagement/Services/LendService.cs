using LibraryManagement.BusinessObject;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class LendService : ILendService
    {
        private readonly ILendRepo _lendService;

        public LendService()
        {
            _lendService = new LendRepo();
        }
        public void AddLend(Lend lend)
        {
            _lendService.AddLend(lend);
        }

        public List<Lend> GetLend()
        {
            return _lendService.GetLend();
        }

        public List<Lend> GetLendByUserId(int Id)
        {
            return _lendService.GetLendByUserId(Id);
        }

        public void UpdateLendReturnDate(int id, DateOnly returnDate)
        {
            _lendService.UpdateLendReturnDate(id, returnDate);
        }
    }
}
