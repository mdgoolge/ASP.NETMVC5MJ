namespace Mvc5My.Models.MyDb1Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MyTable1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyTable1()
        {
            MyTable3 = new HashSet<MyTable3>();
        }

        [Key]
        [StringLength(3)]
        public string KeChengID { get; set; }

        [Required]
        [StringLength(30)]
        public string KeChengName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MyTable3> MyTable3 { get; set; }
    }
}
