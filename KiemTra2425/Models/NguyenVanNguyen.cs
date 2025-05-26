using System.ComponentModel.DataAnnotations;

namespace KiemTra2425.Models
{
    public class NguyenVanNguyen
    {
        [Key]
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        
    }
}