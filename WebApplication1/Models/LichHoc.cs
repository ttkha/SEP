//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LichHoc
    {
        public int ID { get; set; }
        public int MaKH { get; set; }
        public System.DateTime NgayTrongTuan { get; set; }
        public System.DateTime ThoiGianBatDau { get; set; }
        public System.DateTime ThoiGianKetThuc { get; set; }
    
        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
