using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtProject.Model;

    public class Role
    {
        [Key]
        public int id_role { get; set; }
        public string name { get; set; }
    }