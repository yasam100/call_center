using PresentationLayer.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public enum PriorityType
    {
        HIGH,
        MEDIUM,
        LOW
    }
    public enum StatusType
    {
        OPEN,
        IN_PROGRESS,
        CLOSED
    }
    public class ServiceCall : IEquatable<ServiceCall>, IDirty<ServiceCall>
    {
        #region | Properties |
        public int Id { get; set; }

        public Nullable<int> CustomerId { get; set; }
        public Customer Caller { get; set; }
        public DateTime OpenDate { get; set; }

        public Nullable<int> OpenByAgentId { get; set; }
        public Employee OpenByAgent { get; set; }

        public Nullable<StatusType> Status { get; set; }

        public Nullable<PriorityType> Priority { get; set; }

        public DateTime CloseDate { get; set; }

        public Nullable<int> CloseByAgentId { get; set; }
        public Employee CloseByAgent { get; set; }

        public string Issue { get; set; }

        public string Solution { get; set; }
        #endregion | Properties |

        #region | Constructor |
        public ServiceCall(ServiceCall serviceCall = null)
        {
            if (serviceCall != null)
            {
                Id = serviceCall.Id;
                CustomerId = serviceCall.CustomerId;
                Caller = serviceCall.Caller;
                OpenByAgentId = serviceCall.OpenByAgentId;
                OpenByAgent = serviceCall.OpenByAgent;
                OpenDate = serviceCall.OpenDate;
                Priority = serviceCall.Priority;
                Status = serviceCall.Status;
                CloseDate = serviceCall.CloseDate;
                CloseByAgentId = serviceCall.CloseByAgentId;
                CloseByAgent = serviceCall.CloseByAgent;
                Issue = serviceCall.Issue;
                Solution = serviceCall.Solution;
            }
        }
        #endregion | Constructor |

        #region | Methods |
        public static bool Equals(ServiceCall first, ServiceCall second)
        {
            bool isEqual = false;
            if(first == null)
            {
                isEqual = second == null ? true : false;
            }
            else
            {
                isEqual = first.Equals(second);
            }
            return isEqual;
        }

        public static bool Dirty(ServiceCall data, ServiceCall cache)
        {
            bool isDirty = false;
            if (Equals(data, cache) && data != null)
            {
                isDirty = data.Dirty(cache);
            }

            return isDirty;
        }
        public bool Equals(ServiceCall other)
        {
            bool isEquals = false;
            if (other != null
                && Id == other.Id)
                isEquals = true;
            return isEquals;
        }

        public bool Dirty(ServiceCall cache)
        {
            bool isDirty = false;
            if (Equals(cache)
                && (!Nullable<int>.Equals(CustomerId, cache.CustomerId)
                || !DateTime.Equals(OpenDate, cache.OpenDate)
                || !Nullable<int>.Equals(OpenByAgentId, cache.OpenByAgentId)
                || !Nullable<StatusType>.Equals(Status, cache.Status)
                || !Nullable<PriorityType>.Equals(Priority, cache.Priority)
                || !DateTime.Equals(CloseDate, cache.CloseDate)
                || !Nullable<int>.Equals(CloseByAgentId, cache.CloseByAgentId)
                || string.Compare(Issue, cache.Issue) != 0
                || string.Compare(Solution, cache.Solution) != 0))
                isDirty = true;
            return isDirty;
        }
        #endregion | Methods |
    }
}
