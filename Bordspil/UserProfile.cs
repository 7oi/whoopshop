//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bordspil
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.Games = new HashSet<Game>();
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Points { get; set; }
        public Nullable<int> Game_gameID { get; set; }
        public string ProfilePicUrl { get; set; }
    
        public virtual ICollection<Game> Games { get; set; }
        public virtual Game Game { get; set; }
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}
