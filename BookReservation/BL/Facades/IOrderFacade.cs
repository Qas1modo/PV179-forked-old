using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Facades
{
    public interface IOrderFacade
    {
        public bool MakeOrder(int userId);

        public bool ReturnBook(int reservationId, bool cancel);
    }
}
