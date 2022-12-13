﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace BL.Facades.OrderFac
{
    public interface IOrderFacade
    {
        Task<bool> MakeOrder(int userId);
        Task<bool> ReserveBook(int reservationId, int userId);
        Task<bool> ReturnBook(int reservationId, int userId, RentState rentSate);
    }
}
