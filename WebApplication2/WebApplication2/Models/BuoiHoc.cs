//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuoiHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BuoiHoc()
        {
            this.DiemDanhs = new HashSet<DiemDanh>();
        }
    
        public int ID_BH { get; set; }
        public Nullable<System.DateTime> NgayHoc { get; set; }
        public string MaKH { get; set; }
        public Nullable<int> Buoi_thu { get; set; }
    
        public virtual KhoaHoc KhoaHoc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }
    }
}
