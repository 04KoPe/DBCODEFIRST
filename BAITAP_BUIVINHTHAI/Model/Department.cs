namespace BAITAP_BUIVINHTHAI.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public  virtual List<Employee> Employees { get; set;}
        public  virtual Company Company { get; set; }
    }
}
