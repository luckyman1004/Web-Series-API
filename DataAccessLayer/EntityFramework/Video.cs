//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Video
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Video()
        {
            this.Archives = new HashSet<Archive>();
            this.Mywatchlists = new HashSet<Mywatchlist>();
            this.UserReviews = new HashSet<UserReview>();
        }
    
        public int Id { get; set; }
        public string VideoTitle { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Nullable<int> UserId { get; set; }
        public string VideoPath { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Archive> Archives { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mywatchlist> Mywatchlists { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserReview> UserReviews { get; set; }
    }
}
