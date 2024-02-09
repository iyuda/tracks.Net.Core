using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TracsBusinessLogic;
using Tracs.Common.Enumeration;
using Tracs.Common.Models;
using StaticHttpContextAccessor.Helpers;

namespace TRACSPortal.Areas.Shipping.Services
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly ILogger<IShippingRepository> _logger;
        private IHostingEnvironment _evn;

        public List<ShippingModel> GetShipList(string SearchColumn = null, string SearchValue = null)
        {
            return TracsBusinessLogic.Shipping.GetShipList(SearchColumn, SearchValue);
        }
        public List<ReceivingModel> GetReceiveList(string SearchColumn = null, string SearchValue = null)
        {
            return TracsBusinessLogic.Shipping.GetReceiveList(SearchColumn, SearchValue);
        }
        public object ShipItem(string RmaID, string TrackingNumber)
        {
            return TracsBusinessLogic.Shipping.ShipItem(RmaID, TrackingNumber);
        }
        public object ReceiveItem(string RmaID)
        {
            return TracsBusinessLogic.Shipping.ReceiveItem(RmaID);
        }
        #region Private Functions



        #endregion
    }

}
