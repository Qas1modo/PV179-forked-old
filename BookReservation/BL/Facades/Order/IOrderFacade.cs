using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace BL.Facades
{
    public interface IOrderFacade
    {
        bool MakeOrder(int userId);

        bool ReturnBook(int reservationId, RentState rentSate);
    }
}
