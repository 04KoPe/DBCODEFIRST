using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BAITAP_BUIVINHTHAI.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public required string Sex { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

       
    }
}
