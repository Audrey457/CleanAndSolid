using CleanAndSolid.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace CleanAndSolid.Domain
{
    public class LeaveType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
