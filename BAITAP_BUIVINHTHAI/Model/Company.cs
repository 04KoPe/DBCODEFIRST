namespace BAITAP_BUIVINHTHAI.Model
{
    public class Company
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string Address { get; set; }
        public  virtual List<Department> Departments { get; set; }
    }
}
