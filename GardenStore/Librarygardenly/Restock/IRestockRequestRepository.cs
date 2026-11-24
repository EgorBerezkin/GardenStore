using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarygardenly.Restock
{
    public interface IRestockRequestRepository
    {
        List<RestockRequest> GetRequests();

        List<RestockRequest> GetRequestsByUser(int userId);

        void AddRequest(RestockRequest request, List<RestockRequestItem> items);

        List<RestockRequestItem> GetRequestItems(int requestId);

        void UpdateRequestStatus(int requestId, string status);
    }
}
