using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracs.Common.Models;

namespace TRACSPortal.Areas.Shipping.Services
{
    public interface IShippingRepository
    {
        List<ShippingModel> GetShipList(string SearchColumn = null, string SearchValue = null);
        List<ReceivingModel> GetReceiveList(string SearchColumn = null, string SearchValue = null);
        object ShipItem(string RmaID, string TrackingNumber);
        object ReceiveItem(string RmaID);
    }
}
